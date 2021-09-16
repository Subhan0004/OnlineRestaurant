using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Core.Domain.Abstract
{
    public interface IOrderRepository
    {
        int Add(Order order);
        bool Update(Order order);
        List<Order> Get();
        Order FindById(int id);
    }
}
