using RestaurantApp.ViewModels;
using RestaurantApp.ViewModels.UserControls;
using RestaurantApp.Views.Windows.UserControls;
using System;
using System.Collections.Generic;
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
            CustomersViewModel customersViewModel = new CustomersViewModel();

            CustomersControl customersControl = new CustomersControl();

            customersControl.DataContext = customersViewModel;

            MainWindow mainWindow = (MainWindow)mainViewModel.Window;

            mainWindow.GrdCenter.Children.Clear();

            mainWindow.GrdCenter.Children.Add(customersControl);

        }
    }
}
