using PasteryShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace PasteryShop.Data
{
    public class PasteryShopContext : DbContext
    {

        private readonly IConfiguration _config;

        public PasteryShopContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:PasteryShopContextDb"]);
        }       
    }
}
