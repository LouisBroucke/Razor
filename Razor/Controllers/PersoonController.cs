using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Razor.Models;
using Razor.Services;

namespace Razor.Controllers
{
    public class PersoonController : Controller
    {
        private PersoonService _persoonService;
        public PersoonController(PersoonService persoonService)
        {
            _persoonService = persoonService;
        }

        public IActionResult Index()
        {
            return View(_persoonService.FindAll());
        }

        [HttpGet]
        public IActionResult VerwijderForm(int id)
        {
            return View(_persoonService.FindByID(id));
        }

        [HttpPost]
        public IActionResult Verwijderen(int id)
        {
            _persoonService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Opslag()
        {
            OpslagViewModel opslagViewModel = new OpslagViewModel();
            opslagViewModel.Percentage = 10;
            return View(opslagViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Opslag(OpslagViewModel opslagViewModel)
        {
            if (this.ModelState.IsValid)
            {
                _persoonService.Opslag(opslagViewModel.VanWedde.Value,
                opslagViewModel.TotWedde.Value, opslagViewModel.Percentage);
                return RedirectToAction("Index");
            }
            else
            {
                return View(opslagViewModel);
            }            
        }

        [HttpGet]
        public IActionResult VanTotWedde()
        {
            var form = new VanTotWeddeViewModel();
            return View(form);
        }

        [HttpGet]
        public IActionResult VanTotWeddeResultaat(VanTotWeddeViewModel form)
        {
            if (this.ModelState.IsValid)
            {
                var lijst = _persoonService.VanTotWedde(
                    form.VanWedde.Value, form.TotWedde.Value);
                if (lijst.Count <= 3)
                {
                    form.Personen = lijst;
                }
                else
                    this.ModelState.AddModelError("", "Te veel resultaten");
            }

            return View("VanTotWedde", form);
        }

        [HttpGet]
        public IActionResult Toevoegen()
        {
            var persoon = new Persoon();
            persoon.Score = 1;

            return View(persoon);
        }

        [HttpPost]
        public IActionResult Toevoegen(Persoon p)
        {
            if (this.ModelState.IsValid)
            {
                _persoonService.Add(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }

        [HttpGet]
        public IActionResult EditForm(int id)
        {
            return View(_persoonService.FindByID(id));
        }

        [HttpPost]
        public IActionResult Edit(Persoon p)
        {
            if (this.ModelState.IsValid)
            {
                _persoonService.Update(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditForm", p);
            }
        }
    }
}