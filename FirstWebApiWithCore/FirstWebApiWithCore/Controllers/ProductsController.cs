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
        public IActionResult Get() => Ok(_products);


        [HttpPost]
        public void Post([FromBody] Products products) => _products.Add(products);

        [HttpPut("{productID}")]
        public void Put(int productID, [FromBody] Products products) => _products[productID] = products;

        [HttpDelete("{productID}")]
        public void Delete(int productID) => _products.RemoveAt(productID);
   
   }
}
    
