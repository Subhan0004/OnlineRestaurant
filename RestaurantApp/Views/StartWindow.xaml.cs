using Restaurant.Core;
using Restaurant.Core.Enums;
using Restaurant.Core.Factories;
using RestaurantApp.Models;
using RestaurantApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RestaurantApp.Views
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                CheckServer();
            });
        }
       
        public async void CheckServer()
        {
            DbSettings settings = DbSettings.Get();
            string connectionString = settings.GetConnectionString();
            Kernel.DB = DbFactory.Create(ServerType.SqlServer, connectionString);

            if (Kernel.DB == null) // configuration is incorrect
            {
                Application.Current.Dispatcher.Invoke(ShowErrorPanel);
            }
            else
            {
                bool connectionSucceed = Kernel.DB.CheckServer();

                if (connectionSucceed)
                {
                    await Task.Delay(2500);
                    LoginViewModel loginViewModel = new LoginViewModel();
                    LoginWindow loginWindow = new LoginWindow();

                    loginWindow.DataContext = loginViewModel;
                    loginViewModel.Window = loginWindow;

                    Close();
                    loginWindow.ShowDialog();
                }
                else
                {
                    Application.Current.Dispatcher.Invoke(ShowErrorPanel);
                }
            }
        }
        private void ShowErrorPanel()
        {
            firstPanel.Visibility = Visibility.Hidden;
            secondPanel.Visibility = Visibility.Visible;
        }

        private void btnConfigClick(object sender, RoutedEventArgs e)
        {
            ConfigurationViewModel configurationViewModel = new ConfigurationViewModel();
            configurationViewModel.DBSettings = DbSettings.Get();

            Configuration configWindow = new Configuration();
            configWindow.DataContext = configurationViewModel;
            configWindow.ShowDialog();

            firstPanel.Visibility = Visibility.Visible;
            secondPanel.Visibility = Visibility.Hidden;
            CheckServer();
        }
    }
}
