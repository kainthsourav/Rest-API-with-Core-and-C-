using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace FirstWebApiWithCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        static List<Products> _products = new List<Products>()
       {
           new Products(){productID=10,productName="Laptop",productPrice="20000"},
           new Products(){productID=20,productName="Phone",productPrice="1500"}
       };

        [HttpGet]
        public IActionResult Get() //by default it has httpget verb as Getis used  
        {
            return Ok(_products);
        }

        [HttpGet("Welcome")] // this method will be accessed by Welcome as defined
        public IActionResult GetWelcome()
        {
            return Ok("welocme to Project");
        }
        [HttpPost]
        public IActionResult Post([FromBody] Products products)
        {
            _products.Add(products);
            return StatusCode(201); //created 201 code

        }

        [HttpPut("{productID}")]
        public IActionResult Put(int productID, [FromBody] Products products)
        {
            _products[productID] = products;
            return StatusCode(200);
        }

        [HttpDelete("{productID}")]
        public IActionResult Delete(int productID)
        {
            _products.RemoveAt(productID);
            return StatusCode(200);
        }
   
   }
}
    
