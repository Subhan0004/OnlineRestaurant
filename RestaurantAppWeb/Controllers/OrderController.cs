using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class OrderController : BaseController
    {
        public OrderController(IUnitOfWork db, UserManager<User> userManager) : base(db, userManager) { }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            List<Order> orders = DB.OrderRepository.Get();
            OrderViewModel viewModel = new OrderViewModel();

            OrderMapper mapper = new OrderMapper();

            foreach (var order in orders)
            {
                OrderModel orderModel = mapper.Map(order);
                viewModel.Orders.Add(orderModel);
            }

            EnumerationUtil.Enumerate(viewModel.Orders);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult SaveOrder(int id)
        {
            OrderModel model = new OrderModel();

            if (id != 0)
            {
                Order order = DB.OrderRepository.FindById(id);

                if (order == null)
                    Content("Order not found!");

                OrderMapper mapper = new OrderMapper();

                model = mapper.Map(order);
            }

            List<Customer> customers = DB.CustomerRepository.Get();
            List<SelectListItem> customerModels = new List<SelectListItem>();

            foreach (var customer in customers)
            {
                customerModels.Add(new SelectListItem(customer.Name, customer.Id.ToString()));

            }

            List<Courier> couriers = DB.CourierRepository.Get();

            List<SelectListItem> courierModels = new List<SelectListItem>();

            foreach (var courier in couriers)
            {
                courierModels.Add(new SelectListItem(courier.Name, courier.Id.ToString()));

            }

            model.Customers = customerModels;
            model.Couriers = courierModels;

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveOrder(OrderModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return Content("Model is invalid");
            }

            OrderMapper mapper = new OrderMapper();

            Order order = mapper.Map(orderModel);

            order.Creator = CurrentUser;

            if (order.Id != 0)
            {
                DB.OrderRepository.Update(order);
            }
            else
            {
                DB.OrderRepository.Add(order);
            }

            TempData["Message"] = "Saved successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(OrderViewModel viewModel)
        {
            Order order = DB.OrderRepository.FindById(viewModel.DeletedId);

            if (order == null)
                Content("Current order not found");


            order.Creator = CurrentUser;

            order.LastModifiedDate = DateTime.Now;

            order.IsDeleted = true;

            DB.OrderRepository.Update(order);

            return RedirectToAction("Index");

        }
    }
}
