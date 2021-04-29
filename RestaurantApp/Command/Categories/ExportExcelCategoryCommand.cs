using RestaurantApp.Helpers;
using RestaurantApp.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Command.Categories
{
    public class ExportExcelCategoryCommand : BaseCategoryCommand
    {
        public ExportExcelCategoryCommand(CategoriesViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            ExcelExport.WriteToExcel(viewModel.Categories);
        }
    }
}
