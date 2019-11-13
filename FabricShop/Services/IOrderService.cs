using FabricShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricShop.Services
{
    interface IOrderService
    {
        List<Order> GetOrders();

    }
}
