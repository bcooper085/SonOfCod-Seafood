using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SonOfCodSeafood.Models;

namespace SonOfCodSeafood.Controllers
{
    public class MailingListController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MailingListController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MailingList mailingList)
        {
            _db.MailingLists.Add(mailingList);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
