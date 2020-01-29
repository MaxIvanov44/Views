using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Views.Models;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GetMessage()
        {
            return PartialView("_GetMessage");
        }


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> countries = new List<string> { "Бразилия", "Аргентина", "Уругвай", "Чили" };
            return View(countries);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string[] phones)
        {
            string result = "";
            foreach (string p in phones)
            {
                result += p;
                result += ";";
            }
            result = "Вы выбрали: " + result;
            return Content(result);
        }
    }
}
