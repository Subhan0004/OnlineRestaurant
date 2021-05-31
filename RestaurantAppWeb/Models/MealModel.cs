using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAppWeb.Models
{
    public class MealModel : BaseModel
    {
        [Required(ErrorMessage = "The name must be entered!")]
        [StringLength(100,ErrorMessage = "The name can't be longer than 10 characters")]
        public string Name { get; set; }

        public CategoryModel Category { get; set; }

        public decimal Price { get; set; }
        
        [MaxLength(short.MaxValue, ErrorMessage ="The quantity can not more than 32767!")]
        public int Quantity { get; set; }

        [Required(ErrorMessage ="The note must be entered!")]
        public string Note { get; set; }

        public List<SelectListItem> Categories;
    }
}
