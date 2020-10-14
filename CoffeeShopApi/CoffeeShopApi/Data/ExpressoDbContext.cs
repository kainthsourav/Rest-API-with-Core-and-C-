using CoffeeShopApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopApi.Data
{
    public class ExpressoDbContext : DbContext
    {
        public ExpressoDbContext(DbContextOptions<ExpressoDbContext>options):base(options)
        {

        }
        public DbSet<Menus> Menus{ get; set; }
        public DbSet<Reservation> Reservations { get; set; }


    }
}
