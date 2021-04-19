using RestaurantApp.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Command.Customers
{
    public abstract class BaseCustomerCommand : BaseCommand
    {
        protected readonly CustomersViewModel viewModel;
        public BaseCustomerCommand(CustomersViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

    }
}
