﻿using Microsoft.AspNetCore.Hosting;
using PasteryShop.Data.Entities;
using PasteryShop.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PasteryShop.Data
{
    public class PasteryShopSeeder
    {
        private readonly PasteryShopContext _ctx;
        private readonly IWebHostEnvironment _env;

        public PasteryShopSeeder(PasteryShopContext ctx,IWebHostEnvironment env)
        {
            _ctx = ctx;
            _env = env;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Products.Any())
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Data/art.json");
                //need to create sample data
                var json = File.ReadAllText(filePath);
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);

                _ctx.Products.AddRange(products);

                var order = new Order()
                {
                    OrderDate = DateTime.Today,
                    OrderNumber = "10000",

                    Items = new List<OrderItem>()
                    {
                         new OrderItem()
                         {
                             Product= products.First(),
                             Quantity=5,
                             UnitPrice=products.First().Price
                         }

                    }
                };
                _ctx.Orders.Add(order);
                _ctx.SaveChanges();

            }
        }


    }
}
