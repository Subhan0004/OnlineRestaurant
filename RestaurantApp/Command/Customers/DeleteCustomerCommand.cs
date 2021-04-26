using Restaurant.Core;
using Restaurant.Core.Domain.Entities;
using RestaurantApp.Enums;
using RestaurantApp.Helpers;
using RestaurantApp.Mapper;
using RestaurantApp.Models;
using RestaurantApp.ViewModels;
using RestaurantApp.ViewModels.UserControls;
using RestaurantApp.Views.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantApp.Command.Customers
{
    public class DeleteCustomerCommand : BaseCustomerCommand
    {
        public DeleteCustomerCommand(CustomersViewModel viewModel) : base(viewModel)
        {

        }

        public string UIMessage { get; private set; }

        public override void Execute(object parameter)
        {
            SureDialogViewModel sureDialogViewModel = new SureDialogViewModel();
            sureDialogViewModel.DialogText = UIMessages.DeleteSureMessage;

            SureDialog dialog = new SureDialog();
            dialog.DataContext = sureDialogViewModel;
            dialog.ShowDialog();

            if(dialog.DialogResult == true)
            {
                CustomerMapper mapper = new CustomerMapper();

                Customer customer = mapper.Map(viewModel.CurrentCustomer);
                customer.IsDeleted = true;
                customer.Creator = Kernel.CurrentUser;

                DB.CustomerRepository.Update(customer);

                int no = viewModel.SelectedCustomer.No;

                viewModel.CurrentSituation = (int)Situation.NORMAL;
                viewModel.Customers.Remove(viewModel.SelectedCustomer);

                List<CustomerModel> modelList = viewModel.Customers.ToList();
                EnumerationUtil.Enumerate(modelList, no - 1);
                viewModel.Customers = new ObservableCollection<CustomerModel>(modelList);

                viewModel.SelectedCustomer = null;
                viewModel.CurrentCustomer = new CustomerModel();

                MessageBox.Show(UIMessages.OperationSuccessMessage, "Ínformation", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
