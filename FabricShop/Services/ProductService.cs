using FabricShop.Data;
using FabricShop.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricShop.Services
{
    public class ProductService:IProductService
    {
        private readonly Db _db;
        public ProductService(Db db)
        {
            _db = db;
        }
        
        public List<Product> GetAll(string userName)
        {
            return _db.Products.Where(e => e.VendorName.Trim() == userName).ToList();
        }
        public Product GetProduct(string ProdId)
        {
            return _db.Products.SingleOrDefault(f => f.ProductId.Trim() == ProdId.Trim());
        }
        public void AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChangesAsync();
        }
        public void DeleteProduct(Product product)
        {
            _db.Products.Remove(product);
            _db.SaveChangesAsync();
        }
        public void EditProduct(Product product)
        {

        }
        public bool ProductExists(string id)
        {
            return _db.Products.Any(e => e.ProductId == id);
        }
    }
}
