using RestaurantApp.Models;
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
            CheckServer();
        }

        public /*async*/ void CheckServer()
        {
            //Kernel.DB = await DbFactory.CreateSqlDatabase(DbSettings.Get().GetConnectionString(), Server.EntityFramework);

            DbSettings settins = DbSettings.Get();

            //Kernel.DB = DbFactory.Create(ServerType.SqlServer);

            //if (Kernel.DB == null)
            //{
            //    firstPanel.Visibility = Visibility.Hidden;
            //    secondPanel.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    //await Task.Delay(2500);
            //    LoginViewModel LoginVM = new LoginViewModel();
            //    LoginPage login = new LoginPage(LoginVM);
            //    Close();
            //    login.ShowDialog();
            //}
        }

        private void btnConfigClick(object sender, RoutedEventArgs e)
        {
            //SqlConfiguration config = new SqlConfiguration();
            //config.ShowDialog();
            //firstPanel.Visibility = Visibility.Visible;
            //secondPanel.Visibility = Visibility.Hidden;
            //CheckServer();
        }
    }
}
