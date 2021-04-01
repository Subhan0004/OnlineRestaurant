using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Meal : BaseEntity
    {
        public Categorie Categorie { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Note { get; set; }
    }
}
