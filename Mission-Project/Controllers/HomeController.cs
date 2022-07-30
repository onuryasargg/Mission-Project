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
            //Creating object of Person class
            Person person = new Person();
            //Adding items to the list
            List<Technology> technology = new List<Technology>()
            {
                new Technology { Value = 1, Text = "C#", IsChecked = true },
                new Technology { Value = 1, Text = "HTML", IsChecked = false },
                new Technology { Value = 1, Text = "JS", IsChecked = false },
                new Technology { Value = 1, Text = "MSSQL", IsChecked = false },
                new Technology { Value = 1, Text = "ALGORITHM", IsChecked = false },
                new Technology { Value = 1, Text = "DATA STRUCTURE", IsChecked = false },
            };
            //assigning records to the CheckBoxItems list
            person.Technologies = technology;
            return View(person);
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
            double percentage = 0;
            bool confirmed = true;
            string TC = Convert.ToString(person.IdentificationNumber);
            int odd = 0; int even = 0;
            int tenth = Convert.ToInt32(TC[9].ToString());
            int eleventh = Convert.ToInt32(TC[10].ToString());

            if (ModelState.IsValid)
            {
                if (person.Technologies != null)
                {
                    foreach (var item in person.Technologies)
                    {
                        if (item.IsChecked)
                        {
                            percentage += 16.66666666666667;
                        }
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (i != 10)
                        {
                            odd = (odd + Convert.ToInt32(TC[i].ToString())); // 7 ile çarpılacak sayıları topluyoruz
                        }
                    }
                    else
                    {
                        if (i != 9)
                        {
                            even = (even + Convert.ToInt32(TC[i].ToString()));
                        }
                    }
                }

                if ((((odd * 7) + (even * 9)) % 10 == tenth) && ((odd * 8) % 10 == eleventh))
                {
                    confirmed = true;
                }
                else
                {
                    confirmed = false;
                }
                if (person.Age < 18 && percentage < 25 && person.Experience < 1 && confirmed == false)
                {
                    TempData["msg"] = "<script>alert('AutoRejected');</script>";
                }
                else if (person.Age > 18 && percentage > 75 && person.Experience > 1 && confirmed == true)
                {
                    TempData["msg"] = "<script>alert('AutoAccepted');</script>";
                }
                else if (person.Age < 18)
                {
                    TempData["msg"] = "<script>alert('TransferredToHR');</script>";
                }
                else if (percentage >= 25 && percentage <= 50 && person.Experience >= 1 && person.Experience <= 2)
                {
                    TempData["msg"] = "<script>alert('TransferredToLead');</script>";
                }
                else if (percentage >= 50 && percentage <= 75 && person.Experience > 2)
                {
                    TempData["msg"] = "<script>alert('TransferredToCTO');</script>";
                }
            }
            return View(person);
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