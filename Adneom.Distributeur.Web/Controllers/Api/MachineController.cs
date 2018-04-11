using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Adneom.Distributeur.ApplicationCore.Entities;
using Adneom.Distributeur.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Adneom.Distributeur.Web.Controllers.Api
{
    [Produces("application/json")]
    //[Route("api/Machine")]
    public class MachineController : BaseApiController
    {
        private readonly IMachineService machineService;

        public MachineController(IMachineService machineService)
        {
            this.machineService = machineService;
        }
        // GET: api/Machine
        [HttpGet]
        public IActionResult  Get()
        {
            return Json(machineService.ListAllTypeBoisson().Result);
        }
        
        /// <summary>
        /// Creation commande
        /// </summary>
        /// <param name="IdTypeBoisson"></param>
        /// <param name="Mug"></param>
        /// <param name="Quantite"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(string IdTypeBoisson,bool Mug,int Quantite)
        {
            var message = "";
            var custumMachine = new CustumMachine
            {

                Quantite = Quantite,
                IdType = IdTypeBoisson,
                Mug = Mug,
                Login = HttpContext.User.Identity.Name
            };

            var machine= await machineService.ConstructionCafe(custumMachine);
            if(machine!=null)
            {
                message = machine.IdTypeBoissonNavigation.DescriptionType;
            }
            return Json(message);
        }

        // PUT: api/Machine/5
        [HttpPut("Put/{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
        }
    }
}
