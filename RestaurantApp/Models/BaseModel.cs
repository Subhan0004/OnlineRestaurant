using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Attributes;

namespace RestaurantApp.Models
{
    public class BaseModel
    {
        [Export(Name = "№", ColumnNo = 0)]
        public int No { get; set; }

        public int Id { get; set; }
    }
}
