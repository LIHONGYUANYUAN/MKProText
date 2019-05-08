using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NETCORE.TokenBaseAuth.Controllers
{
    [Route("api/[controller]")] 
    public class ValuesController : ControllerBase
    {

        [HttpGet]
        [Authorize("Bearer")]
        public string Get()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            var id = claimsIdentity.Claims.FirstOrDefault(c => c.Type == "ID").Value;

            return $"Hello! {HttpContext.User.Identity.Name}, your ID is:{id}";
        }

    }
}
