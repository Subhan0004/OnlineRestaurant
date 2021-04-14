using RestaurantApp.Command.MainPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantApp.ViewModels
{
    public class MainViewModel : BaseWindowViewModel
    {
        public OpenCategoriesCommand OpenCategories => new OpenCategoriesCommand(this);

    }
}
