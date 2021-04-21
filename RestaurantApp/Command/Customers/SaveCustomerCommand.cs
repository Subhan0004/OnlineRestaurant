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
            
            else if (viewModel.CurrentSituation == (int)Situation.SELECTED)
            {
                viewModel.CurrentSituation = (int)Situation.EDIT;
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
                        Customer customer = customerMapper.Map(viewModel.CurrentCustomer);
                        customer.Creator = Kernel.CurrentUser;

                        // STEP 3: SAVE CustomerEntity to database
                        if (customer.Id != 0)
                        {
                            DB.CustomerRepository.Update(customer);
                        }
                        else
                        {
                           viewModel.CurrentCustomer.Id = DB.CustomerRepository.Add(customer);
                           viewModel.CurrentCustomer.No = viewModel.Customers.Count + 1;
                           viewModel.Customers.Add(viewModel.CurrentCustomer);
                        }

                        // STEP 4: SET Situation TO NORMAL
                        viewModel.SelectedCustomer = null;
                        viewModel.CurrentCustomer = new CustomerModel();
                        viewModel.CurrentSituation = (int)Situation.NORMAL;
                       
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
