using FizzBuzz_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FizzBuzz_MVC.Controllers
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

        [HttpGet]
        public IActionResult FizzBuzzPage()
        {
            FizzBuzz fbModel = new FizzBuzz();

            return View(fbModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FizzBuzzPage(FizzBuzz fbModel)
        {
            for (int fbNumber = fbModel.StartRange; fbNumber <= fbModel.EndRange; fbNumber++)
            {
                // true if fbNumber is divisible by FizzValue
                bool isFizz = fbNumber % fbModel.FizzValue == 0;
                
                // true if fbNumber is divisible by BuzzValue
                bool isBuzz = fbNumber % fbModel.BuzzValue == 0;
                
                // Ternary operator to determine if fbNumber is divisible by both FizzValue and BuzzValue, FizzValue, BuzzValue,
                // or neither FizzValue nor BuzzValue and add the appropriate string to the Results list in the FizzBuzz model object fbModel.
                fbModel.Results.Add(isFizz && isBuzz ? "FizzBuzz" : isFizz ? "Fizz" : isBuzz ? "Buzz" : fbNumber.ToString());
            }

            return View(fbModel);
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