﻿using RestaurantApp.ViewModels;
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

        private void rdbChecked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;

            grdSqlServer.IsEnabled = button != rdbWindows;
        }

        private void btnCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            ConfigurationViewModel viewModel = (ConfigurationViewModel)DataContext;

            viewModel.DBSettings.SaveConfig();

            Close();

        }
    }
}
