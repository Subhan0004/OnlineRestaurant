﻿using RestaurantApp.Command.Customers;
using RestaurantApp.Enums;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.ViewModels.UserControls
{
    public class CustomersViewModel : BaseControlViewModel
    {
        public CustomersViewModel()
        {
           
        }

        public override string Header => "Customers";

        private CustomerModel currentCustomer = new CustomerModel();
        public CustomerModel CurrentCustomer
        {
            get => currentCustomer;
            set
            {
                currentCustomer = value;
                CurrentSituation = (int)Situation.SELECTED;

                OnPropertychanged(nameof(CurrentCustomer));
            }
        }

        private ObservableCollection<CustomerModel> _customer;
        public ObservableCollection<CustomerModel> Customers
        {
            get => _customer;
            set
            {
                _customer = value;
                OnPropertychanged(nameof(Customers));
            }
        }



        public SaveCustomerCommand Save => new SaveCustomerCommand(this);

        public RejectCustomerCommand Reject => new RejectCustomerCommand(this);

        public DeleteCustomerCommand Delete => new DeleteCustomerCommand(this);


    }
}
