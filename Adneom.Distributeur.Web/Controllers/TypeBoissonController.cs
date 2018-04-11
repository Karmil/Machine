using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adneom.Distributeur.ApplicationCore.Entities;
using Adneom.Distributeur.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adneom.Distributeur.Web.Controllers
{
    public class TypeBoissonController : Controller
    {
        private readonly IMachineService machineService;

        public TypeBoissonController(IMachineService machineService)
        {
            this.machineService = machineService;
        }

        // GET: TypeBoisson
        public async Task<IActionResult> Index()
        {
            return View(await machineService.ListAllTypeBoisson());
        }

        // GET: TypeBoisson/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TypeBoisson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeBoisson/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoissonType boissonType)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TypeBoisson/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TypeBoisson/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TypeBoisson/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TypeBoisson/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}