using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricShop.Data;
using FabricShop.Data.Entities;
using FabricShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FabricShop.Pages
{
    public class OrdersModel : PageModel
    {
        private readonly IOrderService _service;

        public OrdersModel(IOrderService service)
        {
            _service = service;
        }
        public IList<Order> Orders { get; set; }
        public void OnGet()
        {
            Orders = _service.GetOrders();
        }

    }
}