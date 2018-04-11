using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adneom.Distributeur.Web.Controllers
{
    public class CommandeController : Controller
    {
        // GET: Command
        public ActionResult Index()
        {
            return View();
        }

        // GET: Command/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Command/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Command/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: Command/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Command/Edit/5
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

        // GET: Command/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Command/Delete/5
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