using RestaurantApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class CategoryModel : BaseModel
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                message = UIMessages.GetRequiredMessage("Ad");
                return false;
            }

            if (Name.Length > 50)
            {
                message = UIMessages.GetLenghtMessage("Ad", 50);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(Note))
            {
                if (Note.Length > 250)
                {
                    message = UIMessages.GetLenghtMessage("Qeyd", 250);
                    return false;
                }
            }

            message = string.Empty;
            return true;
        }
        public CategoryModel Clone()
        {
            CategoryModel cloneModel = new CategoryModel();

            cloneModel.No = No;
            cloneModel.Name = Name;
            cloneModel.Id = Id;

            return cloneModel;

        }
    }
}
