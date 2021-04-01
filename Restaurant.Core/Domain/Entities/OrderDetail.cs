using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class OrderDetail: BaseEntity
    {
        public Meal Meal { get; set; }

        public Order Order { get; set; }

        public int OrderCount { get; set; }

        public string Note { get; set; }
    }
}
