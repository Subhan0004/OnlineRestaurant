using Restaurant.Core.Domain.Entities;
using RestaurantApp.Helpers;
using RestaurantApp.Mapper;
using RestaurantApp.Models;
using RestaurantApp.ViewModels;
using RestaurantApp.ViewModels.UserControls;
using RestaurantApp.Views.Windows.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Command.MainPage
{
    public class OpenCustomersCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;
        public OpenCustomersCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
       
        public override void Execute(object parameter)
        {
            List<Customer> customers = DB.CustomerRepository.Get();
            List<CustomerModel> customerModels = new List<CustomerModel>();
            CustomerMapper mapper = new CustomerMapper();

            foreach(var customer in customers)
            {
                CustomerModel model = mapper.Map(customer);
               
                customerModels.Add(model);

            }

            EnumerationUtil.Enumerate(customerModels);

            CustomersViewModel customersViewModel = new CustomersViewModel();

            customersViewModel.AllCustomers = customerModels;
            customersViewModel.Customers = new ObservableCollection<CustomerModel>(customerModels);

            CustomersControl customersControl = new CustomersControl();
            customersControl.DataContext = customersViewModel;

            MainWindow mainWindow = (MainWindow)mainViewModel.Window;
            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(customersControl);

        }
    }
}
