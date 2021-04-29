using RestaurantApp.Command.Customers;
using RestaurantApp.Enums;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.ViewModels.UserControls
{
    public class CustomersViewModel : BaseControlViewModel
    {
        public CustomersViewModel()
        {
           
        }

        public override string Header => "Customers";

        private CustomerModel currentCustomer = new CustomerModel();
        public CustomerModel CurrentCustomer
        {
            get => currentCustomer;
            set
            {
                currentCustomer = value;
                OnPropertyChanged(nameof(CurrentCustomer));
            }
        }

        private List<CustomerModel> allCustomers;
        public List<CustomerModel> AllCustomers
        {
            get => allCustomers;
            set
            {
                allCustomers = value;
                OnPropertyChanged(nameof(AllCustomers));
            }
        }

        private CustomerModel selectedCustomer;
        public CustomerModel SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));

                CurrentCustomer = SelectedCustomer?.Clone();

                if(SelectedCustomer != null)
                {
                    CurrentSituation = (int)Situation.SELECTED;
                }
                
            }
        }

        private string searchText = string.Empty;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
                UpdateDataFiltered();

            }
        }

        private ObservableCollection<CustomerModel> _customer;
        public ObservableCollection<CustomerModel> Customers
        {
            get => _customer;
            set
            {
                _customer = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public SaveCustomerCommand Save => new SaveCustomerCommand(this);

        public RejectCustomerCommand Reject => new RejectCustomerCommand(this);

        public DeleteCustomerCommand Delete => new DeleteCustomerCommand(this);

        public ExportExcelCustomerCommand ExportExcel => new ExportExcelCustomerCommand(this);

        public void UpdateDataFiltered()
        {
            IEnumerable<CustomerModel> filteredCustomers = null;

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                filteredCustomers = AllCustomers;
            }
            else
            {
                string lowerSearchText = SearchText.ToLower();

                filteredCustomers = AllCustomers.Where(x =>
                    x.Name.ToLower().Contains(lowerSearchText) ||
                    x.Surname.ToLower().Contains(SearchText) ||
                    x.Phone.ToLower().Contains(SearchText) ||
                    (x.Note != null &&  x.Note.ToLower().Contains(SearchText)));

                Customers.Clear();

                foreach (var item in filteredCustomers)
                {
                    Customers.Add(item);
                }
            }

            
        }
    }
}
