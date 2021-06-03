﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAppWeb.Models
{
    public class MealModel : BaseModel
    {
        [Required(ErrorMessage = "The name must be entered!")]
        [StringLength(100, ErrorMessage = "The name can't be longer than 10 characters")]
        public string Name { get; set; }

        public CategoryModel Category { get; set; }

        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "The note must be entered!")]
        public string Note { get; set; }

        public List<SelectListItem> Categories;
    }
}
