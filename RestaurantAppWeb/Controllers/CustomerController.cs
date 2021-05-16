using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Domain.Abstract;
using Restaurant.Core.Domain.Entities;
using RestaurantApp.Helpers;
using RestaurantAppWeb.Mapper;
using RestaurantAppWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAppWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork DB;
        public CustomerController(IUnitOfWork db)
        {
            DB = db;
        }

        public IActionResult Index()
        {
            List<Customer> customers = DB.CustomerRepository.Get();

            CustomerViewModel viewModel = new CustomerViewModel();

            CustomerMapper customerMapper = new CustomerMapper();

            foreach(var customer in customers)
            {
               var customerModel = customerMapper.Map(customer);
               viewModel.Customers.Add(customerModel);
            }

            EnumerationUtil.Enumerate(viewModel.Customers);


            return View(viewModel);
        }
    }
}
