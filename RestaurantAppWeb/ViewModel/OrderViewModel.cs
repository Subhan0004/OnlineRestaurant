using RestaurantAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAppWeb.ViewModel
{
    public class OrderViewModel
    {
        public List<OrderModel> Orders { get; set; } = new List<OrderModel>();

        public int DeletedId { get; set; }

    }
}
