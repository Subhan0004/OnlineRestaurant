using Restaurant.Core;
using Restaurant.Core.Domain.Entities;
using RestaurantApp.Enums;
using RestaurantApp.Mapper;
using RestaurantApp.Models;
using RestaurantApp.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantApp.Command.Customers
{
    public class SaveCustomerCommand : BaseCustomerCommand
    {
        public SaveCustomerCommand(CustomersViewModel viewModel): base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            if(viewModel.CurrentSituation == (int)Situation.NORMAL)
            {
                viewModel.CurrentSituation = (int)Situation.ADD;
            }
            else
            {
                if(viewModel.CurrentSituation==(int)Situation.ADD || viewModel.CurrentSituation == (int)Situation.EDIT)
                {
                    // STEP 1: VALIDATE MODEL DATA
                    if(viewModel.CurrentCustomer.IsValid(out string message))
                    {

                        // STEP 2: CREATE CustomerEntity FROM CustomerModel
                        CustomerMapper customerMapper = new CustomerMapper();
                        Customer customer = customerMapper.Create(viewModel.CurrentCustomer);
                        customer.Creator = Kernel.CurrentUser;

                        // STEP 3: SAVE CustomerEntity to database
                        DB.CustomerRepository.Add(customer);

                        // STEP 4: SET Situation TO NORMAL
                        viewModel.CurrentSituation = (int)Situation.NORMAL;
                        viewModel.CurrentCustomer = new CustomerModel();

                        // STEP 5: REFRESH LIST VIEW
                    }
                    else
                    {
                        MessageBox.Show(message, "Validasiya xətası", MessageBoxButton.OK, MessageBoxImage.Error);
                    }




                }
            }
        }
    }
}
