using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAppWeb.Models
{
    public class CategoryModel : BaseModel
    {
        public string Name { get; set; }

        public string Note { get; set; }
    }
}
