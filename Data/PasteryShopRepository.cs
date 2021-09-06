using Microsoft.Extensions.Logging;
using PasteryShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasteryShop.Data
{
    public class PasteryShopRepository : IPasteryShopRepository
    {
        private readonly PasteryShopContext _ctx;
        private readonly ILogger<PasteryShopRepository> _logger;

        public PasteryShopRepository(PasteryShopContext ctx, ILogger<PasteryShopRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called...");

                return _ctx.Products
                           .OrderBy(p => p.Title)
                           .ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }



        public IEnumerable<Product> GetProductsByGategory(string category)
        {
            return _ctx.Products
                        .Where(p => p.Category == category)
                        .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
