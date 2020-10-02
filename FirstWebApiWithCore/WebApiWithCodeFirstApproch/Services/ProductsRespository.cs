using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithCodeFirstApproch.Data;

namespace WebApiWithCodeFirstApproch.Services
{
    public class ProductsRespository : IProducts
    {
        private ProductsDBContext _productsDBContext;

        public ProductsRespository(ProductsDBContext productsDBContext)
        {
            _productsDBContext = productsDBContext;
        }

        public void AddProduct(Products products)
        {
            _productsDBContext.Products.Add(products);
            _productsDBContext.SaveChanges(true);
        }

        public void DeleteProducts(int id)
        {
             var product= _productsDBContext.Products.Find(id);
            _productsDBContext.Products.Remove(product);
            _productsDBContext.SaveChanges(true);
            
        }

        public IEnumerable<Products> GetProducts()
        {
            return _productsDBContext.Products;
        }

        public Products GetProducts(int id)
        {
            return _productsDBContext.Products.SingleOrDefault(m => m.productID == id);
        }

        public void UpdateProduct(Products products)
        {
            _productsDBContext.Products.Update(products);
            _productsDBContext.SaveChanges(true);
        }
    }
}
