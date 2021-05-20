using Microsoft.AspNetCore.Mvc;
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
    public class MealController : BaseController
    {
        public MealController(IUnitOfWork db) : base(db) { }

        public IActionResult Index()
        {
            List<Meal> meals = DB.MealRepository.Get();
            MealViewModel viewModel = new MealViewModel();

            MealMapper mapper = new MealMapper();

            foreach(var meal in meals)
            {
                MealModel mealModel = mapper.Map(meal);
                viewModel.Meals.Add(mealModel);
            }

            EnumerationUtil.Enumerate(viewModel.Meals);

            return View(viewModel);
        }
    }
}
