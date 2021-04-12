using Restaurant.Core;
using RestaurantApp.Helpers;
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

            MainWindow = new StartWindow();
            MainWindow.Show();

            DispatcherUnhandledException += AppDispatcherUnhandledException;

            MainWindow.Show();
        }

        private void AppDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Helper.Log(e.Exception);
           
            MessageBox.Show("Unknown exception occured", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            
            e.Handled = true;
        }
    }
}
