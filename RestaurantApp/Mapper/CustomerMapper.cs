using Restaurant.Core.Domain.Entities;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Mapper
{
    public class CustomerMapper : BaseMapper<Customer,CustomerModel>
    {
        public override Customer Create(CustomerModel customerModel)
        {
            Customer customer = new Customer();

            customer.Name = customerModel.Name;
            customer.Surname = customerModel.Surname;
            customer.Phone = customerModel.Phone;
            customer.Address = customerModel.Address;
            customer.Note = customerModel.Note;

            return customer;
        }

        public override CustomerModel Create(Customer customer)
        {
            CustomerModel customerModel = new CustomerModel();

            customerModel.Name = customer.Name;
            customerModel.Surname = customer.Surname;
            customerModel.Phone = customer.Phone;
            customerModel.Address = customer.Address;
            customerModel.Note = customer.Note;

            return customerModel;

        }
    }
}
