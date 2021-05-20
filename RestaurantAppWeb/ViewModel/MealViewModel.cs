using RestaurantAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAppWeb.ViewModel
{
    public class MealViewModel
    {
       public List<MealModel> Meals { get; set; } = new List<MealModel>();
    }
}
