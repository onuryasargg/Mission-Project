using Microsoft.AspNetCore.Mvc;
using Mission_Project.Models;
using System.Diagnostics;

namespace Mission_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Person person)
        {
            // Teknoloji Hesaplama

            // Tc Kimlik Doğrulama 


            //if (person.age <= 18 && person.technologies < 25 && person.experienced < 1 && identity == false)
            //{
            //    ViewBag.Message =  "AutoRejected";
            //}
            //if(person.age >=18 person.technologies > 75 && person.experienced > 1 && identity == true)
            //{
            //    ViewBag.Message = "AutoAccepted";
            //}
            //if(person.age<=18)
            //{
            //    ViewBag.Message = "TransferredToHR";
            //}
            //if(person.technologies > 25 && person.technologies < 50  && person.experienced >= 1 && person.experienced <= 2)
            //{
            //    ViewBag.Message = "TransferredToLead";
            //}
            //if (person.technologies > 50 && person.technologies < 75 && person.experienced >= 2)
            //{
            //    ViewBag.Message = "TransferredToCTO";
            //}
            return View();
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
    }
}