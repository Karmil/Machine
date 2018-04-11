using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adneom.Distributeur.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class BaseApiController : Controller
    {
    }
}
