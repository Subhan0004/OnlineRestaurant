using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAppWeb.Models
{
    public class CourierModel : BaseModel
    {
        [Required(ErrorMessage = "The name must be entered!")]
        [StringLength(50, ErrorMessage = "The name can't be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The surname must be entered!")]
        [StringLength(50, ErrorMessage = "The surname cant't be longet than 50 characters")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The phone must be entered!")]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Phone number format is incorrect")]
        public string Phone { get; set; }

        public string Note { get; set; }

    }
}
