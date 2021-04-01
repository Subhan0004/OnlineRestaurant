using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Customers : BaseEntity 
    {
        int Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        string Note { get; set; }
        Users Creator { get; set; }
        DateTime LastModifiedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
