using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiWithCodeFirstApproch.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiWithCodeFirstApproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductsDBContext productsDBContext;
        public ProductsController(ProductsDBContext ProductsDBContext)
        {
            productsDBContext = ProductsDBContext;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Products> Get()
        {
            return productsDBContext.Products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product=productsDBContext.Products.SingleOrDefault(m => m.productID == id);
            if(product==null)
            {
                return NotFound("Not Records Exists");
            }

            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Products products)
        {
            if (ModelState.IsValid)
            {
                productsDBContext.Products.Add(products);
                productsDBContext.SaveChanges(true);
                return Ok("Records added");
            }
            return BadRequest(ModelState);
           
        }

        // PUT api/<ProductsController>/5
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
            productsDBContext.Products.Update(products);
            productsDBContext.SaveChanges(true);
            return Ok("Updated");
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product=productsDBContext.Products.SingleOrDefault(m => m.productID == id);
            if(product==null)
            {
                return NotFound("Cannot Delete : Record does not exist");
            }
            productsDBContext.Products.Remove(product);
            productsDBContext.SaveChanges(true);
            return Ok("Deleted");
        }
    }
}
