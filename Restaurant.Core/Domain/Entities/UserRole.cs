using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Core.Domain.Entities
{
    public class UserRole
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Role Role { get; set; }

    }
}
