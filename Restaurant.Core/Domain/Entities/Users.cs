﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Users : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool CanOperateCrm { get; set; }

    }
}
