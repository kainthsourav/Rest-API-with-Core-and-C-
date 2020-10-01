using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithCodeFirstApproch.Data
{
    public class ProductsDBContext :DbContext
    {
        public ProductsDBContext(DbContextOptions<ProductsDBContext>options):base(options)
        {

        }
        public DbSet<Products> Products { get; set; }

    }
}
