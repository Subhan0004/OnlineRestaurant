using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Attributes
{
    public class ExportAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
