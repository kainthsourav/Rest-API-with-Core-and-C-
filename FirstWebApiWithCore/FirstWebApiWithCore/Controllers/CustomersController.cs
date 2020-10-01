using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApiWithCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApiWithCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        static List<Customers> _customers = new List<Customers>()
        {
            new Customers(){customerID=10,customerName="Sourav",customerEmail="sourav@xml.com",customePhone="+91-8427-XXXX-XX"},
             new Customers(){customerID=20,customerName="Sourav",customerEmail="souravkai@xml.com",customePhone="+91-8426-XXXX-XX"}
        };

        public IActionResult Get()
        {
            return Ok(_customers);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Customers customers)
        {
            if (ModelState.IsValid) //To check validtion we gave in Model 
            {
                _customers.Add(customers);
                return StatusCode(201);
            }
            else
                return BadRequest(ModelState);
            
        }
    }
}
  