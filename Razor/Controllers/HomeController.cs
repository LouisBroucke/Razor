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

        public IActionResult Vestigingen()
        {
            Hoofdzetel deHoofdzetel = new Hoofdzetel 
                { 
                Straat = "Keizerslaan", 
                HuisNr = "11", 
                PostCode = "1000", 
                Gemeente = "Brussel" 
                };
            ViewBag.deHoofdzetel = deHoofdzetel;

            List<Filiaal> deFilialen = new List<Filiaal>()
                 {
                 new Filiaal { ID = 1, Naam = "Antwerpen",
                 Gebouwd = new DateTime(2003, 1, 1), Waarde = 2000000, Eigenaar = Eigenaar.Eigendom },
                 new Filiaal { ID = 2, Naam = "Wondelgem",
                 Gebouwd = new DateTime(1979, 1, 1), Waarde = 2500000, Eigenaar = Eigenaar.Gehuurd },
                 new Filiaal { ID = 3, Naam = "Haasrode",
                 Gebouwd = new DateTime(1976, 1, 1), Waarde = 1000000, Eigenaar = Eigenaar.Gehuurd },
                 new Filiaal { ID = 4, Naam = "Wevelgem",
                 Gebouwd = new DateTime(1981, 1, 1), Waarde = 1600000, Eigenaar = Eigenaar.Eigendom },
                 new Filiaal { ID = 5, Naam = "Genk",
                 Gebouwd = new DateTime(1990, 1, 1), Waarde = 4000000, Eigenaar = Eigenaar.Gehuurd }
                 };

            return View(deFilialen);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
