using Restaurant.Core.Domain.Entities;
using RestaurantApp.Helpers;
using RestaurantApp.Mapper;
using RestaurantApp.Models;
using RestaurantApp.ViewModels;
using RestaurantApp.ViewModels.UserControls;
using RestaurantApp.Views.Windows.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            List<Category> categories = DB.CategoryRepository.Get();
            List<CategoryModel> categoryModels = new List<CategoryModel>();
            CategoryMapper mapper = new CategoryMapper();

            foreach (var category in categories)
            {
                CategoryModel model = mapper.Map(category);

                categoryModels.Add(model);
            }

            EnumerationUtil.Enumerate(categoryModels);

            CategoriesViewModel categoriesViewModel = new CategoriesViewModel();
            categoriesViewModel.Categories = new ObservableCollection<CategoryModel>(categoryModels);

            CategoriesControl categoriesControl = new CategoriesControl();
            categoriesControl.DataContext = categoriesViewModel;
           
            MainWindow mainWindow =(MainWindow)mainViewModel.Window;
            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(categoriesControl);
        }
    }
}
