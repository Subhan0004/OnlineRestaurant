using ClosedXML.Excel;
using Microsoft.Win32;
using RestaurantApp.Helpers;
using RestaurantApp.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Command.Customers
{
    public class ExportExcelCustomerCommand : BaseCustomerCommand
    {
        public ExportExcelCustomerCommand(CustomersViewModel viewModel): base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            ExcelExporter.WriteToExcel(viewModel.Customers);
        }
    }
}
