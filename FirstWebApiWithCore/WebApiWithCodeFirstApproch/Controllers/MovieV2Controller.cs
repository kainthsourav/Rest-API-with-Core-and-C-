using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiWithCodeFirstApproch.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiWithCodeFirstApproch.Controllers
{
    [ApiVersion("2.0")]
  //  [Route("api/movie")]  // https://localhost:44325/api/movie?api-version=2.0 --Versioning Via Query String
    [Route("api/v{version:apiVersion}/movie")]     // Versioning via Url Path https://localhost:44325/api/v2/Movie
    [ApiController]
    public class MovieV2Controller : ControllerBase
    {
        static List<MovieV2> _movieV2 = new List<MovieV2>()
        {
            new MovieV2(){movieId=100,movieName="Iron Man",movieDescription="Marvel Superhero",Type="Action"},
             new MovieV2(){movieId=120,movieName="Iron Man 3",movieDescription="Marvel Superhero",Type="Action"},
        };

        // GET: api/<MovieV2Controllerr
        [HttpGet]
        public IEnumerable<MovieV2> Get()
        {
            return _movieV2;
        }

    }
}
