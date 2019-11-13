using FabricShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricShop.Services
{
    interface IProductService
    {
        List<Product> GetAll(string userName);
        Product GetProduct(string Id);
        void AddProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(Product product);
    }

}
