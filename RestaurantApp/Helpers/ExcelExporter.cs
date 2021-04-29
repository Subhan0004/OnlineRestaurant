using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Helpers
{
    public static class ExcelExporter
    {
        public static void WriteToExcel<T>(IEnumerable<T> list)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                FileName = "Information.xlsx",
                Title = "RestaurantApp Application"
            };

            bool? dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == true)
            {
                using (var workBook = new XLWorkbook())
                {
                    DataTable dataTable = new DataTable();

                    Type type = typeof(T);
                    PropertyInfo[] propertyInfos = type.GetProperties();

                    foreach(var propertyInfo in propertyInfos)
                    {
                        dataTable.Columns.Add(propertyInfo.Name);
                    }
                    
                    foreach (var item in list)
                    {
                        List<object> values = new List<object>();
                        foreach(var propertyInfo in propertyInfos)
                        {
                            object value = propertyInfo.GetValue(item);
                            values.Add(value);
                        }
                       
                        dataTable.Rows.Add(values.ToArray());
                    }

                    var workSheet = workBook.Worksheets.Add(dataTable, "Information");

                    workSheet.Columns().AdjustToContents();
                    workSheet.Rows().AdjustToContents();

                    workBook.SaveAs(saveFileDialog.FileName);
                }
            }
        }
    }
}
