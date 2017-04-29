using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SonOfCodSeafood.Models;
using Microsoft.AspNetCore.Identity;

namespace SonOfCodSeafood.Controllers
{
    public class MailingListController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;

        public MailingListController(UserManager<User> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MailingList mailingList)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            mailingList.User = currentUser;
            _db.MailingLists.Add(mailingList);
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }

        public IActionResult Details()
        {
            return View(_db.MailingLists.ToList());
        }
    }
}
