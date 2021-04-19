using RestaurantApp.Command.Customers;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.ViewModels.UserControls
{
    public class CustomersViewModel : BaseControlViewModel
    {
        public CustomersViewModel()
        {
           
        }

        public override string Header => "Customers";

        private CustomerModel currentCustomer = new CustomerModel();
        public CustomerModel CurrentCustomer
        {
            get => currentCustomer;
            set
            {
                currentCustomer = value;
                OnPropertychanged(nameof(CurrentCustomer));
            }
        }


        public SaveCustomerCommand Save => new SaveCustomerCommand(this);

        public RejectCustomerCommand Reject => new RejectCustomerCommand(this);

        public DeleteCustomerCommand Delete => new DeleteCustomerCommand(this);


    }
}
