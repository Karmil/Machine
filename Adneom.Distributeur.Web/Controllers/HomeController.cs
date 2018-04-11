using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Adneom.Distributeur.Web.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Adneom.Distributeur.ApplicationCore.Interfaces;
using Adneom.Distributeur.Web.ViewModel;
using Newtonsoft.Json;
using Adneom.Distributeur.ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Adneom.Distributeur.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMachineService machineService;

        public HomeController(IMachineService machineService)
        {
            this.machineService = machineService;
        }

        public async Task<IActionResult> Index()
        {
            // Execution service rest pour initailisé le drop down 

            //HttpClient client = new HttpClient();
            //var url = "https://" + HttpContext.Request.Host.ToString();
            //client.BaseAddress = new Uri(url);
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //HttpResponseMessage response = client.GetAsync("/api/Machine").Result;

            // Une autre facon d'initailisation plus simple  
            var vw = new MachineViewModel();
            var listeTypeBoisson = await machineService.ListAllTypeBoisson();
            var dernierChoix = new CustumMachine();
            if (!String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                dernierChoix = machineService.SectionDernierChoix(HttpContext.User.Identity.Name);
            }
            var selectTypeBoison = listeTypeBoisson.Select(a => new SelectListItem()
            {
                Value = a.Id.ToString(),
                Text = a.DescriptionType,
                Selected = (dernierChoix != null && a.Id == dernierChoix.IdType) ? true : false

            }).ToList();

            ViewBag.ListeTypeBoisson = selectTypeBoison;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MachineViewModel machineViewModel)
        {
            try
            {
                var custumMachine = new CustumMachine
                {

                    Quantite = machineViewModel.Quantite ?? 0,
                    IdType = machineViewModel.IdTypeBoisson,
                    Mug = machineViewModel.Mug,
                    Login = HttpContext.User.Identity.Name
                };
                await machineService.ConstructionCafe(custumMachine);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(machineViewModel);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
