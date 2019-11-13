using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricShop.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FabricShop.Pages
{
    public class ProductsModel : PageModel
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Weave { get; set; }
        public string Composition { get; set; }
        public string Color { get; set; }
        public string Cate1 { get; set; }
        public string Cate2 { get; set; }
        public string Cate3 { get; set; }

        public IList<Product> Products { get; set; }
        public string CurrentFilter { get; set; }

        public void OnGet()
        {

        }
    }
}