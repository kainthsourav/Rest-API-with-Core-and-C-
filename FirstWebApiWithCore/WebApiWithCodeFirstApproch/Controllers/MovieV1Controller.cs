using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiWithCodeFirstApproch.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiWithCodeFirstApproch.Controllers
{
    [ApiVersion("1.0")]     // https://localhost:44325/api/movie?api-version=1.0
    [Route("api/movie")]
    [ApiController]
    public class MovieV1Controller : ControllerBase
    {
        static List<MovieV1> _moviev1 = new List<MovieV1>()
        {
            new MovieV1(){movieID=100,movieName="Kimi No WA"},
            new MovieV1(){movieID=102,movieName="3 Iron"}
        };
        // GET: api/<MovieController>
        [HttpGet]
        public IEnumerable<MovieV1> Get() 
        {
            return _moviev1;
        }
    }
}
