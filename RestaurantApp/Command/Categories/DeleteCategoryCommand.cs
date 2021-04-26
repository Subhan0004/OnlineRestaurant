using Restaurant.Core;
using Restaurant.Core.Domain.Entities;
using RestaurantApp.Enums;
using RestaurantApp.Helpers;
using RestaurantApp.Mapper;
using RestaurantApp.Models;
using RestaurantApp.ViewModels;
using RestaurantApp.ViewModels.UserControls;
using RestaurantApp.Views.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantApp.Command.Categories
{
    public class DeleteCategoryCommand : BaseCategoryCommand
    {
        public DeleteCategoryCommand(CategoriesViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            SureDialogViewModel sureViewModel = new SureDialogViewModel();
            sureViewModel.DialogText = UIMessages.DeleteSureMessage;

            SureDialog dialog = new SureDialog();
            dialog.DataContext = sureViewModel;
            dialog.ShowDialog();


            if (dialog.DialogResult == true)
            {
                CategoryMapper mapper = new CategoryMapper();

                Category category = mapper.Map(viewModel.CurrentCategory);
                category.IsDeleted = true;
                category.Creator = Kernel.CurrentUser;

                DB.CategoryRepository.Update(category);

                int no = viewModel.SelectedCategory.No;

                viewModel.CurrentSituation = (int)Situation.NORMAL;
                viewModel.Categories.Remove(viewModel.SelectedCategory);

                List<CategoryModel> modelList = viewModel.Categories.ToList();

                EnumerationUtil.Enumerate(modelList, no - 1);
                viewModel.Categories = new ObservableCollection<CategoryModel>(modelList);

                viewModel.SelectedCategory = null;
                viewModel.CurrentCategory = new CategoryModel();

                MessageBox.Show(UIMessages.OperationSuccessMessage, "Məlumat", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
