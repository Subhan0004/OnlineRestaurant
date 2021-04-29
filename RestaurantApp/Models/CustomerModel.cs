using RestaurantApp.Attributes;
using RestaurantApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class CustomerModel : BaseModel
    {
        [Export(Name ="Ad", ColumnNo = 1)]
        public string Name { get; set; }

        [Export(Name = "Soyad", ColumnNo = 2)]
        public string Surname { get; set; }

        [Export(Name = "Telefon", ColumnNo = 3)]
        public string Phone { get; set; }

        [Export(Name = "Ünvan", ColumnNo = 4)]
        public string Address { get; set; }

        [Export(Name = "Qeyd", ColumnNo = 5)]
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

            if (string.IsNullOrWhiteSpace(Surname))
            {
                message = UIMessages.GetRequiredMessage("Soyad");
                return false;
            }

            if (Surname.Length > 75)
            {
                message = UIMessages.GetLenghtMessage("Soyad", 75);
                return false;
            }

            if (string.IsNullOrWhiteSpace(Address))
            {
                message = UIMessages.GetRequiredMessage("Ünvan adı");
                return false;
            }

            if (Address.Length > 125)
            {
                message = UIMessages.GetLenghtMessage("Ünvan adı", 125);
                return false;
            }

            if (string.IsNullOrWhiteSpace(Phone))
            {
                message = UIMessages.GetRequiredMessage("Telefon nömrəsi");
                return false;
            }

            if (!ModelValidatorHelper.ValidatePhone(Phone))
            {
                message = UIMessages.ErrorMessage;
                return false;
            }

            if (!string.IsNullOrWhiteSpace(Note))
            {
                if(Note.Length > 250)
                {
                    message = UIMessages.GetLenghtMessage("Qeyd", 250);
                    return false;
                }
            }

            message = string.Empty;
            return true;

        }

        public CustomerModel Clone()
        {
            CustomerModel cloneModel = new CustomerModel();
            
            cloneModel.No = No;
            cloneModel.Name = Name;
            cloneModel.Surname = Surname;
            cloneModel.Phone = Phone;
            cloneModel.Address = Address;
            cloneModel.Id = Id;

            return cloneModel;

        }

    }
}
