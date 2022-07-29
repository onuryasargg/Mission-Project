using Microsoft.AspNetCore.Mvc;
using Mission_Project.Models;
using System.Diagnostics;
using System.Text;

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
            ////Creating object of CheckBoxList model class
            //Person person = new Person();
            ////Adding items to the list
            //List<CheckBoxModel> technology = new List<CheckBoxModel>()
            //{
            //    new CheckBoxModel { Value = 1, Text = "C#", IsChecked = true },
            //    new CheckBoxModel { Value = 1, Text = "HTML", IsChecked = false },
            //    new CheckBoxModel { Value = 1, Text = "JS", IsChecked = false },
            //    new CheckBoxModel { Value = 1, Text = "MSSQL", IsChecked = false },
            //    new CheckBoxModel { Value = 1, Text = "ALGORITHM", IsChecked = false },
            //    new CheckBoxModel { Value = 1, Text = "DATA STRUCTURE", IsChecked = false },
            //};
           
            ////assigning records to the CheckBoxItems list
            //person.Technologies = technology;
            //return View(person);
            return View();
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
            //double percentage = 0;
            int[] numbers=person.identityNumber.ToString().ToCharArray().Select(Convert.ToInt32).ToArray();  
            bool idConfirmed = true;

            if (ModelState.IsValid)
            {
                // Teknoloji Hesaplama

                //if (person.Technologies != null)
                //{
                //    foreach (var item in person.Technologies) // toplam check olanların sayısı
                //    {
                //        if (item.IsChecked)
                //        {
                //            percentage += 16.66666666666667;
                //        }
                //    }
                //}
                // T.C Kimlik Numarası Doğrulama
                //İşlemler
                //if (person.Age < 18 && percentage < 25 && experience < 1 && idConfirmed == false)
                //{
                //    ViewBag.Loc("AutoRejected");
                //}
                //if (person.Age > 18 && percentage > 75 && experience > 1 && idConfirmed == true)
                //{
                //    ViewBag.Loc("AutoAccepted");
                //}
                //if (person.Age < 18)
                //{
                //    ViewBag.Message = "TransferredToHR";
                //    return View(person);
                //}
                //if (percentage > 25 && percentage < 50 && experience > 1 && experience < 2)
                //{
                //    ViewBag.Loc("TransferredToLead");
                //}
                //if (percentage > 50 && percentage < 75 && experience > 2)
                //{
                //    ViewBag.Loc("TransferredToCTO");
                //}
                return View(person);
            }
            return RedirectToAction("Index");
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