using Restaurant.Core.Domain.Abstract;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public static class Kernel
    {
        public static User CurrentUser;
        public static IUnitOfWork DB;
    }
}
