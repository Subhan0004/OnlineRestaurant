using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantApp.ViewModels
{
    public  abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertychanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public abstract class BaseControlViewModel : BaseViewModel
    {

    }

    public abstract class BaseWindowViewModel : BaseViewModel
    {
        public Window Window;
    }
}
