using Microsoft.AspNetCore.Mvc;
using Restaurant.Core;
using Restaurant.Core.Domain.Abstract;
using Restaurant.Core.Domain.Entities;
using RestaurantApp.Helpers;
using RestaurantAppWeb.Mapper;
using RestaurantAppWeb.Models;
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

        [HttpGet]
        public IActionResult SaveCustomer(int id)
        {
            if(id != 0)
            {
                Customer customer = DB.CustomerRepository.Get(id);
                
                if (customer == null)
                {
                    return Content("Belə bir müştəri tapılmadı!");
                }

                CustomerMapper mapper = new CustomerMapper();

                CustomerModel customerModel = mapper.Map(customer);

                return View(customerModel);
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult SaveCustomer(CustomerModel customerModel)
        {
            CustomerMapper mapper = new CustomerMapper();
            Customer customer = mapper.Map(customerModel);

            customer.Creator = Kernel.CurrentUser;
            
            if(customer.Id != 0)
            {
                DB.CustomerRepository.Update(customer);
            }

            else
            {
                DB.CustomerRepository.Add(customer);
            }
           
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Delete(CustomerViewModel customerViewModel)
        {
            Customer customer = DB.CustomerRepository.Get(customerViewModel.DeletedId);

            if(customer == null)
            {
                return Content("Silinmək üçün belə bir müştəri tapılmadı!");
            }

            customer.Creator = Kernel.CurrentUser;

            customer.IsDeleted = true;

            DB.CustomerRepository.Update(customer);

            return RedirectToAction("Index");
        }
    }
}
