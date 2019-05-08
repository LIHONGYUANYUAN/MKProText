using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NETCORE.Versioning.Controllers
{ 
    [Route("api/[controller]/[action]")] 
    public class ValuesController : ControllerBase
    {


        [HttpGet]
        public string Getss(int id)
        {
            return "ss";
        }
    }
}
