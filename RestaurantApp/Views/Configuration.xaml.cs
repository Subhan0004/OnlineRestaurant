﻿using System;
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

namespace RestaurantApp
{
    /// <summary>
    /// Interaction logic for Configuration.xaml
    /// </summary>
    public partial class Configuration : Window
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void rbWindows_Checked(object sender, RoutedEventArgs e)
        {
            grdSqlServer.IsEnabled = false; 
        }

        private void rbSqlServer_Checked(object sender, RoutedEventArgs e)
        {
            grdSqlServer.IsEnabled = true;
        }
    }
}
