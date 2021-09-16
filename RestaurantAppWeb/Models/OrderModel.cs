using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAppWeb.Models
{
    public class OrderModel : BaseModel
    {
        public CustomerModel Customer { get; set; }

        public CourierModel Courier { get; set; }
       
        [Required(ErrorMessage = "The Address must be entered!")]
        public string Address { get; set; }

        public string Note { get; set; }

        public List<SelectListItem> Customers;

        public List<SelectListItem> Couriers;

    }
}
