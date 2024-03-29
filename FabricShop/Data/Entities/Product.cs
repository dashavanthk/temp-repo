﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FabricShop.Data.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Weave { get; set; }
        public string Composition { get; set; }
        public string Color { get; set; }
        public string Cate1 { get; set; }
        public string Cate2 { get; set; }
        public string Cate3 { get; set; }
        public string VendorName { get; set; }
    }
}
