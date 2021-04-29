using ClosedXML.Excel;
using Microsoft.Win32;
using RestaurantApp.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Helpers
{
    public static class ExcelExport
    {
        public static void WriteToExcel<T>(IEnumerable<T> list) 
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Title = "Export",
                Filter = ".xlsx",
            };

            bool? dr = sfd.ShowDialog();

            if (dr==true) 
            {
                using (var wb = new XLWorkbook())
                {
                    DataTable dt = new DataTable();

                    Type type = typeof(T);
                    Type attributeType = typeof(ExportAttribute);

                    PropertyInfo[] allPropInfos = type.GetProperties();

                    List<PropertyInfo> exportedPropInfos = new List<PropertyInfo>();

                    foreach (var propertyInfo in allPropInfos)
                    {
                        ExportAttribute attribute = (ExportAttribute)propertyInfo.GetCustomAttribute(attributeType);

                        if (attribute != null)
                        {
                            exportedPropInfos.Add(propertyInfo);
                            dt.Columns.Add(attribute.Name);
                        }
                    }

                    foreach (var item in list)
                    {
                        List<object> values = new List<object>();

                        foreach (var propertyInfo in exportedPropInfos)
                        {
                            object value = propertyInfo.GetValue(item);
                            values.Add(value);
                        }

                        dt.Rows.Add(values.ToArray());
                    }

                    var worksheet = wb.Worksheets.Add(dt, "Categories");

                    worksheet.Rows().AdjustToContents();
                    worksheet.Columns().AdjustToContents();

                    wb.SaveAs(sfd.FileName);
                }
            }


        }
    }
}
