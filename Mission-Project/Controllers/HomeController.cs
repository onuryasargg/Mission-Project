using Microsoft.AspNetCore.Mvc;
using Mission_Project.Models;
using System.Diagnostics;

namespace Mission_Project.Controllers
{
    public class HomeController : Controller
    {
        double percentage = 0; // global values
        bool confirmed = true;
        string resultText = "";

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            //Creating object of Person class
            Person person = new Person();
            //Adding items to the list
            List<Technology> technology = new List<Technology>()
            {
                new Technology { Text = "C#", IsChecked = true },
                new Technology { Text = "HTML", IsChecked = false },
                new Technology { Text = "JS", IsChecked = false },
                new Technology { Text = "MSSQL", IsChecked = false },
                new Technology { Text = "ALGORITHM", IsChecked = false },
                new Technology { Text = "DATA STRUCTURE", IsChecked = false },
            };
            //assigning records to the Technologies list
            person.Technologies = technology;
            return View(person);
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
            
            // Checking Technologies of person is a not null
            if (person.Technologies != null)
            {
                PercentageOfTechnologies(person.Technologies);
            }
            // Checking that the Identification Number is a real number
            CalculateIdentification(person.IdentificationNumber);
            // We are gonna send him/her a message about his/her result of job application
            Result(person,percentage,confirmed);
            ViewBag.Message = resultText;
            // After all procedures valid or not we are gonna see our page or information note about error in view.
            return View(person);
        }
        public double PercentageOfTechnologies(List<Technology> Technologies)
        {
            //checkboxes of each of the technologies is checked then percentage += 16.66666666666667
            foreach (var item in Technologies)
                {
                    if (item.IsChecked)
                    {
                        percentage += 16.66666666666667;
                    }
                }
            return percentage; // return, result double percentage 
        }
        public bool CalculateIdentification(long IdentificationNumber)
        {
            string TC = Convert.ToString(IdentificationNumber);
            int odd = 0; int even = 0;
            int tenth = Convert.ToInt32(TC[9].ToString()); // tenth equal to TC's 10th number
            int eleventh = Convert.ToInt32(TC[10].ToString()); // eleventh equal to TC's 11th number

            for (int i = 0; i < 10; i++) // the for loop foreach TC's numbers
            {
                if (i % 2 == 0) // if remainder is zero(0) then you are even or not
                {
                    if (i != 10) // if i is equal to TC's eleventh number then dont do this
                    {
                        odd = (odd + Convert.ToInt32(TC[i].ToString())); // 7 ile çarpılacak sayıları topluyoruz
                    }
                }
                else
                {
                    if (i != 9) // if i is equal to TC's tenth number then dont do this
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
            return confirmed; // return, result bool confirmed 
        }
        // We will see him/her message preliminary information about his/her job application
        public string Result(Person person, double percentage, bool confirmed)
        {
            if (person.Age < 18 && percentage < 25 && confirmed == false && person.Experience < 1)
            {
                resultText = "AutoRejected";
            }
            else if(person.Age < 18)
            {
                resultText = "TransferredToHR";
            }
            if (person.Age > 18 && percentage > 75 && confirmed == true && person.Experience > 1)
            {
                resultText = "AutoAccepted";
            }
            if (percentage >= 25 && percentage <= 50 && person.Experience >= 1 && person.Experience <= 2)
            {
                resultText = "TransferredToLead";
            }
            if (percentage >= 50 && percentage <= 75 && person.Experience > 2)
            {
                resultText = "TransferredToCTO";
            }
            return resultText; // return string message
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