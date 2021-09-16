using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Core.Domain.Abstract
{
    public interface ICourierRepository
    {
        int Add(Courier courier);
        bool Update(Courier courier);
        List<Courier> Get();
    }
}
