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
            throw new NotImplementedException();
        }

        public void DeleteProducts(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Products> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Products GetProducts(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Products products)
        {
            throw new NotImplementedException();
        }
    }
}
