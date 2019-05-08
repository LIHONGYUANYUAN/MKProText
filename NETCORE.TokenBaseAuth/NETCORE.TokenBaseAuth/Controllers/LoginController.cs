using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NETCORE.TokenBaseAuth.Controllers
{
 
    [Route("[controller]/[action]")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}