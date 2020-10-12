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

        [HttpGet]
        [ResponseCache(Duration = 60,Location =ResponseCacheLocation.Client)]
        public IEnumerable<Products> Get()
        {
            return productsDBContext.Products;
        }
        // GET: api/<ProductsController>
        [HttpGet("Sorting")]
        public IEnumerable<Products> Get(string sorting) //https://localhost:44325/api/Products?sorting=desc
        {
            IQueryable<Products> products;
            switch (sorting)
            {
                case "desc":
                    products = productsDBContext.Products.OrderByDescending(p=>p.productPrice);
                    break;
                case "asce":
                    products = productsDBContext.Products.OrderBy(p => p.productPrice);
                    break;
                default:
                    products = productsDBContext.Products;
                    break;

            }
            return products;
        }

        [HttpGet("Paging")]
        public IEnumerable<Products> Get(int ? pageNumber,int ? pageSize) 
        {
            int currentpage= pageNumber ?? 1;
            int PageSize = pageSize ?? 5;
            var product = from p in productsDBContext.Products.OrderBy(p => p.productID) select p;
           return product.Skip((currentpage - 1) * PageSize).Take(PageSize).ToList();
        }

        [HttpGet("Search")]
        public IEnumerable<Products> GetSearch(string keyword)
        {
          
            if(string.IsNullOrEmpty(keyword))
            {
                var product = productsDBContext.Products;
                return product;
            }
            var SearchResult = productsDBContext.Products.Where(p => p.productName.StartsWith(keyword));
            return SearchResult;
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
