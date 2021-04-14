using RestaurantApp.ViewModels;
using RestaurantApp.Views.Windows.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Command.MainPage
{
    public class OpenCategoriesCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;
        public OpenCategoriesCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
       
        public override void Execute(object parameter)
        {
            CategoriesControl categoriesControl = new CategoriesControl();

            MainWindow mainWindow =(MainWindow)mainViewModel.Window;

            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(categoriesControl);


        }
    }
}
