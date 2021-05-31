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
    public class MealController : BaseController
    {
        public MealController(IUnitOfWork db) : base(db) { }

        [HttpGet]
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

        [HttpGet]
        public  IActionResult SaveMeal(int id)
        {
            MealModel model = new MealModel();
           
            if (id != 0)
            {
                Meal meal = DB.MealRepository.FindById(id);

                if (meal == null)
                    Content("Meal not found!");

                MealMapper mapper = new MealMapper();

                model = mapper.Map(meal);
            }

            List<Category> categories = DB.CategoryRepository.Get();

            List<SelectListItem> categoryModels = new List<SelectListItem>();
           
            foreach(var category in categories)
            {
                categoryModels.Add(new SelectListItem(category.Name, category.Id.ToString()));
                
            }

            model.Categories = categoryModels;

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveMeal(MealModel model)
        {
            if (!ModelState.IsValid)
            {
                return Content("Model is invalid");
            }

            MealMapper mapper = new MealMapper();

            Meal meal = mapper.Map(model);

            meal.Creator = Startup.CurrentUser;

            if(meal.Id != 0)
            {
                DB.MealRepository.Update(meal);
            }
            else
            {
                DB.MealRepository.Add(meal);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(MealViewModel viewModel)
        {
            Meal meal = DB.MealRepository.FindById(viewModel.DeletedId);

            if (meal == null)
                Content("Current meal not found");


            meal.Creator = Startup.CurrentUser;
           
            meal.LastModifiedDate = DateTime.Now;
           
            meal.IsDeleted = true;

            DB.MealRepository.Update(meal);

            return RedirectToAction("Index");
            
        }
    }
}
