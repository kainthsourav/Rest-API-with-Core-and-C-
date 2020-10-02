using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithCodeFirstApproch.Services
{
    public interface IProducts
    {
        //CRUD Operation

        IEnumerable<Products> GetProducts();
        Products GetProducts(int id);
        void AddProduct(Products products);
        void UpdateProduct(Products products);
        void DeleteProducts(int id);
    }
}
