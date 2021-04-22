using Restaurant.Core;
using RestaurantApp.Enums;
using RestaurantApp.Mapper;
using RestaurantApp.Models;
using RestaurantApp.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Command.Categories
{
    public class DeleteCategoryCommand : BaseCategoryCommand
    {
        public DeleteCategoryCommand(CategoriesViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();

        }
    }
}
