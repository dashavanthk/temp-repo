using FabricShop.Data;
using FabricShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricShop.Services
{
    public class OrderService:IOrderService
    {
        private readonly Db _db;
        public OrderService(Db db)
        {
            _db = db;
        }
        public List<Order> GetOrders()
        {
            var list = _db.Orders.ToList();
            var ret = list.Select(f => new Order
            {
                DeliveryDistance = f.DeliveryDistance,
                OrderId = f.OrderId,
                OrderType = f.OrderType,
                ProductCode = f.ProductCode,
                DeliveryTime = CalculateTime(f.OrderType, f.DeliveryDistance)
            }).ToList();

            return ret;
        }

        private string CalculateTime(string OrderType, string DeliveryDistance)
        {
            bool IsInt= Int32.TryParse(DeliveryDistance, out int IntDist);
            //---mins/Kms
            int MultiplyFactor = 0;
            if (IsInt)
            {
                if (IntDist > 2000)
                    MultiplyFactor = 1; //Air
                else
                    MultiplyFactor = 12;   //Land

                //Air -  1min/km,  Land 12min/km
                var time = (IntDist * MultiplyFactor);
                switch (OrderType.Trim())
                {
                    case "swatch":
                        //Add 1day= 24hours= 1440 mins
                        time += 1440; //In mins
                        time = time / (60 * 24);//mins tot hours into days
                        break;

                    case "sample":
                        //Add 3days = 72 hours = 4320 mins
                        time += 4320; //In mins
                        time = time / (60 * 24);//mins tot hours into days
                        break;

                    case "bulk":
                        // Add 15 days = 360 hours = 216000 mins
                        time += 216000; //In mins
                        time = time / (60 * 24);//mins tot hours into days
                        break;

                }
                return time == 0 ? "Arriving Today!" : "Arriving in " + time.ToString() + " days!";
            }
            else
            {

                return "Not route found!";
            }

        }
    }
}
