﻿using Microsoft.AspNetCore.Mvc;
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
    public class CustomerController : BaseController
    {
        
        public CustomerController(IUnitOfWork db): base(db) { }
        
        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
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
            CustomerModel model = new CustomerModel();

            if(id != 0)
            {
                Customer customer = DB.CustomerRepository.Get(id);
                
                if (customer == null)
                {
                    return Content("Current customer not found!");
                }

                CustomerMapper mapper = new CustomerMapper();

               model = mapper.Map(customer);

            }
            
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveCustomer(CustomerModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                return Content("Model is invalid");
            }

            CustomerMapper mapper = new CustomerMapper();

            Customer customer = mapper.Map(customerModel);

            customer.Creator = Startup.CurrentUser;
            
            if(customer.Id != 0)
            {
                DB.CustomerRepository.Update(customer);
            }

            else
            {
                DB.CustomerRepository.Add(customer);
            }

            TempData["Message"] = "Saved successfully";
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Delete(CustomerViewModel customerViewModel)
        {
            Customer customer = DB.CustomerRepository.Get(customerViewModel.DeletedId);

            if(customer == null)
            {
                return Content("Current customer not found!");
            }

            customer.Creator = Startup.CurrentUser;

            customer.LastModifiedDate = DateTime.Now;

            customer.IsDeleted = true;

            DB.CustomerRepository.Update(customer);

            return RedirectToAction("Index");
        }
    }
}
