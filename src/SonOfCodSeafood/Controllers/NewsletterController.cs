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
        private readonly SignInManager<User> _signInManager;

        public NewsletterController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Newsletter.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Newsletter newsletter)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            newsletter.User = currentUser;
            _db.Newsletter.Add(newsletter);
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }

        public IActionResult Details(int id)
        {
            var thisNewsLetter = _db.Newsletter.FirstOrDefault(newsLetters => newsLetters.NewsletterId == id);
            return View(thisNewsLetter);
        }

        public IActionResult Edit(int id)
        {
            var thisNewsLetter = _db.Newsletter.FirstOrDefault(newsLetter => newsLetter.NewsletterId == id);
            return View(thisNewsLetter);
        }
        [HttpPost]
        public IActionResult Edit(Newsletter newsLetter)
        {
            _db.Entry(newsLetter).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }
        public ActionResult Delete(int id)
        {
            var thisNewsLetter = _db.Newsletter.FirstOrDefault(newsLetter => newsLetter.NewsletterId == id);
            return View(thisNewsLetter);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisNewsLetter = _db.Newsletter.FirstOrDefault(newsLetter => newsLetter.NewsletterId == id);
            _db.Newsletter.Remove(thisNewsLetter);
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }
    }
}
