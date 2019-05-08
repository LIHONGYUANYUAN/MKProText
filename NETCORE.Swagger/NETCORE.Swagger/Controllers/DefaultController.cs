using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NETCORE.Swagger.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        //https://localhost:44328/swagger/index.html

         [HttpGet]
        public string Getss(int id)
        {
            return "ss"; 
        }
    }
}