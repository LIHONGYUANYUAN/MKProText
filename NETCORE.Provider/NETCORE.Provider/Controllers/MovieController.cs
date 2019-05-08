using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NETCORE.Provider.Controllers
{
    [Route("movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IDataProtector protector;

        public MovieController(IDataProtectionProvider provider)
        {
            //this.protector = provider.CreateProtector("protect_my_query_string"); 
            this.protector = provider.CreateProtector("protect_my_query_string")
             .ToTimeLimitedDataProtector();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = GetMovies();

            var outputModel = model.Select(item => new
            {
                Id = this.protector.Protect(item.Id.ToString()),

                //Id = this.protector.Protect(item.Id.ToString(),TimeSpan.FromSeconds(10)),

                item.Title,
                //item.ReleaseYear,
                //item.Summary
            });

            return Ok(outputModel);
        }

        //[HttpGet("{id}")]
        //public IActionResult Get(string id)
        //{
        //    var orignalId = int.Parse(this.protector.Unprotect(id));

        //    var model = GetMovies();

        //    var outputModel = model.Where(item => item.Id == orignalId);

        //    return Ok(outputModel);


        //}


        [HttpGet("{id}")]
        [DecryptReference]
        public IActionResult Get(int id)
        {
            var model = GetMovies();

            var outputModel = model.Where(item => item.Id == id);

            return Ok(outputModel);
        }



        private List<Movie> GetMovies()
        {
            return new List<Movie>() {
                new Movie (1,"aaa") ,
                new Movie (2,"bbb") ,
                new Movie (3,"ccc") ,
            };
        }

    }
}