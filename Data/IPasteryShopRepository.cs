using PasteryShop.Data.Entities;
using System.Collections.Generic;

namespace PasteryShop.Data
{
    public interface IPasteryShopRepository
    {
        IEnumerable<Product> GetAllProduct();
        IEnumerable<Product> GetProductsByGategory(string category);

        bool SaveAll();
    }
}