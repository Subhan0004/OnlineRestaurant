using RestaurantApp.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Command.Customers
{
    public class DeleteCustomerCommand : BaseCustomerCommand
    {
        public DeleteCustomerCommand(CustomersViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
