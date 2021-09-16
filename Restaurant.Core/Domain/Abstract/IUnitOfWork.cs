using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Abstract
{
    public interface IUnitOfWork
    {
        bool CheckServer();
        
        ICustomerRepository CustomerRepository { get; }

        IUserRepository UserRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IOrderRepository OrderRepository { get; }

        IMealRepository MealRepository { get; }

        ICourierRepository CourierRepository { get; }

    }
}
