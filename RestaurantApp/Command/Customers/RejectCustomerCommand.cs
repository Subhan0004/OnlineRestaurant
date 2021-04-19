using RestaurantApp.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Command.Customers
{
    public class RejectCustomerCommand : BaseCustomerCommand
    {
        public RejectCustomerCommand(CustomersViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
