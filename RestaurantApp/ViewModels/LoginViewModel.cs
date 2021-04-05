﻿using RestaurantApp.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginCommand SingIn => new LoginCommand(this);
        
        public string Username { get; set; }

        private Visibility errorVisibility = Visibility.Collapsed;
        public Visibility ErrorVisibility
        {
            get => errorVisibility;
            set
            {
                errorVisibility = value;
                OnPropertychanged(nameof(ErrorVisibility));
            }
        }
        public Window Window;
    }
}
