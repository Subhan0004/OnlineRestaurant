﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Couriers : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Note { get; set; }
    }
}
