using Restaurant.Core;
using RestaurantApp.ViewModels;
using RestaurantApp.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {


            LoginViewModel viewModel = new LoginViewModel();
            MainWindow = new LoginWindow();

            viewModel.Window = MainWindow;
            MainWindow.DataContext = viewModel;

            MainWindow.Show();
        }

    }
}
