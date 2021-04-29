using Restaurant.Core;
using Restaurant.Core.Domain.Entities;
using RestaurantApp.Enums;
using RestaurantApp.Helpers;
using RestaurantApp.Mapper;
using RestaurantApp.Models;
using RestaurantApp.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantApp.Command.Categories
{
    public class SaveCategoryCommand : BaseCategoryCommand
    {
        public SaveCategoryCommand(CategoriesViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            if (viewModel.CurrentSituation == (int)Situation.NORMAL)
            {
                viewModel.CurrentSituation = (int)Situation.ADD;
            }
            else if (viewModel.CurrentSituation == (int)Situation.SELECTED)
            {
                viewModel.CurrentSituation = (int)Situation.EDIT;
            }
            else
            {
                if (viewModel.CurrentSituation == (int)Situation.ADD || viewModel.CurrentSituation == (int)Situation.EDIT)
                {
                    // STEP 1: VALIDATE MODEL DATA
                    if (viewModel.CurrentCategory.IsValid(out string message))
                    {
                        // STEP 2: CREATE CategoryEntity FROM CategoryModel
                        CategoryMapper categoryMapper = new CategoryMapper();
                        Category category = categoryMapper.Map(viewModel.CurrentCategory);
                        category.Creator = Kernel.CurrentUser;

                        // STEP 3: SAVE CategoryEntity to database
                        if (category.Id != 0)
                        {
                            DB.CategoryRepository.Update(category);
                            viewModel.Categories[viewModel.CurrentCategory.No - 1] = viewModel.CurrentCategory;
                        }
                        else
                        {
                            viewModel.CurrentCategory.Id = DB.CategoryRepository.Add(category);
                            viewModel.CurrentCategory.No = viewModel.Categories.Count + 1;
                            viewModel.AllCategories.Add(viewModel.CurrentCategory);
                        }
                        viewModel.UpdateDataFiltered();

                        // STEP 4: SET Situation TO NORMAL
                        viewModel.SelectedCategory = null;
                        viewModel.CurrentCategory = new CategoryModel();
                        viewModel.CurrentSituation = (int)Situation.NORMAL;

                        MessageBox.Show(UIMessages.OperationSuccessMessage, "Məlumat", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show(message, UIMessages.ValidationCommonMessage, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
