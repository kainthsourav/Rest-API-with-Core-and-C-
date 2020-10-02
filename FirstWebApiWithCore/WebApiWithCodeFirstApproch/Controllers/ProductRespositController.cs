using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiWithCodeFirstApproch.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiWithCodeFirstApproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductRespositController : ControllerBase
    {
        private IProducts _productsResposit;
        public ProductRespositController(IProducts productsResposit)
        {
            _productsResposit = productsResposit;
        }
        // GET: api/<ProductRespositController>
        [HttpGet]
        public IEnumerable<Products> Get()
        {
           return _productsResposit.GetProducts();
        }

        // GET api/<ProductRespositController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product= _productsResposit.GetProducts(id);
            if(product==null)
            {
                return NotFound("No records found");
            }
            return Ok(product);
        }

        // POST api/<ProductRespositController>
        [HttpPost]
        public IActionResult Post([FromBody] Products products)
        {
            if(ModelState.IsValid)
            {
                _productsResposit.AddProduct(products);
                return Ok("Added");
            }
            return BadRequest(ModelState);
        }

        // PUT api/<ProductRespositController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Products products)
        {
           if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           if(id!=products.productID)
            {
                return BadRequest();
            }
            try
            {
                _productsResposit.UpdateProduct(products);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("No records found against this id");
            }
            return Ok("Updated");
        }

        // DELETE api/<ProductRespositController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productsResposit.DeleteProducts(id);
            return Ok("Deleted");
        }
    }
}
