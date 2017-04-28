using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SonOfCodSeafood.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace SonOfCodSeafood.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;

        public NewsletterController(UserManager<User> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Newsletters.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var thisNewsletter = _db.Newsletters.FirstOrDefault(newsletters => newsletters.NewsletterId == id);
            return View(thisNewsletter);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Newsletter newsletter)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            newsletter.User = currentUser;
            _db.Newsletters.Add(newsletter);
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }

        public IActionResult Edit(int id)
        {
            var thisNewsletter = _db.Newsletters.FirstOrDefault(newsletters => newsletters.NewsletterId == id);
            return View(thisNewsletter);
        }

        [HttpPost]
        public IActionResult Edit(Newsletter newsletter)
        {
            _db.Entry(newsletter).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Delete(int id)
        {
            var thisNewsletter = _db.Newsletters.FirstOrDefault(newsletters => newsletters.NewsletterId == id);
            return View(thisNewsletter);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisNewsletter = _db.Newsletters.FirstOrDefault(newsletters => newsletters.NewsletterId == id);
            _db.Newsletters.Remove(thisNewsletter);
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }
    }
}
