using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Razor.Models;

namespace Razor.Controllers
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
            return View(new Persoon { Voornaam = "Eddy", Familienaam = "Wally"});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ActionName("Werknemerslijst")]
        public IActionResult AlleWerknemers()
        {
            var werknemers = new List<Werknemer>();

            werknemers.Add(new Werknemer
            {
                Voornaam = "Steven",
                Wedde = 1000,
                InDienst = DateTime.Today
            });

            werknemers.Add(new Werknemer
            {
                Voornaam = "Prosper",
                Wedde = 2000,
                InDienst = DateTime.Today.AddDays(2)
            });

            return View("AlleWerknemers" ,werknemers);
        }

        public IActionResult Palindroom(string woord)
        {
            char[] omgekeerd = woord.ToCharArray();
            Array.Reverse(omgekeerd);
            string achterstevoren = new string(omgekeerd);

            if (woord == achterstevoren)
                ViewBag.palindroom = true;
            else
                ViewBag.palindroom = false;

            ViewBag.ingetiktwoord = woord;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
