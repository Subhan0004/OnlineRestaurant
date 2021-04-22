using RestaurantApp.Enums;
using RestaurantApp.Models;
using RestaurantApp.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Command.Categories
{
    public class RejectCategoryCommand : BaseCategoryCommand
    {
        public RejectCategoryCommand(CategoriesViewModel viewModel) : base(viewModel)
        {
        }

        public override void Execute(object parameter)
        {
            viewModel.SelectedCategory = null;
            viewModel.CurrentSituation = (int)Situation.NORMAL;
            viewModel.CurrentCategory = new CategoryModel();
        }

    }
}
