using RestaurantApp.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Command.Categories
{
    public abstract class BaseCategoryCommand : BaseCommand
    {
        protected readonly CategoriesViewModel viewModel;
        public BaseCategoryCommand(CategoriesViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
