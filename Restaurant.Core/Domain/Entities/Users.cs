using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Users : BaseEntity
    {
        int Id { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        bool CanOperateCrm { get; set; }
        Users Creator { get; set; }
        DateTime LastModifiedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
