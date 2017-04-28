using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace SonOfCodSeafood.Controllers
{
    public class MailingListController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
