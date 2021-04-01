using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Customer Customer { get; set; }

        public Courier Courier { get; set; }

        public string Address { get; set; }

        public string Note { get; set; }
    }
}
