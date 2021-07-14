using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestProject2.Models;

namespace TestProject2.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyAppDBContext DbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MyAppDBContext DbContext)
        {

            _logger = logger;
            this.DbContext = DbContext;
        }




        public IActionResult Index()
        {
            ViewBag.Count = 9;
            ViewBag.Message = "Привет, практиканты!";
            ViewBag.Date = DateTime.Now;
            ViewBag.Names = new[] { "Арина", "Даниил", "Владимир", "Иван", "Арсений" };

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Group = DbContext.Students.ToList();
            return View();
        }

        public IActionResult Student()
        {

            var studentModel = DbContext.Students.Where(c => c.Age > 30);
            if (studentModel != null)
            {
                return View(studentModel);
            }
            else
            {
                return View("Error", new ErrorViewModel { });
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
