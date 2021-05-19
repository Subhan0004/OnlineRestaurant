using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAppWeb.Models
{
    public class MealModel : BaseModel
    {
        public string Name { get; set; }

        public CategoryModel Category { get; set; }

        public decimal Price { get; set; }
        
        public int Quantity { get; set; }

        public string Note { get; set; } 
    }
}
