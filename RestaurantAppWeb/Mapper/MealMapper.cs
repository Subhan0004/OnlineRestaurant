using Restaurant.Core.Domain.Entities;
using RestaurantAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAppWeb.Mapper
{
    public class MealMapper : BaseMapper<Meal, MealModel>
    {
        public override Meal Map(MealModel mealModel)
        {
            if (mealModel == null)
                return null;

            CategoryMapper categoryMapper = new CategoryMapper();

            Meal meal = new Meal()
            {
                Id = mealModel.Id,
                Name = mealModel.Name,
                Price = mealModel.Price,
                Quantity = mealModel.Quantity,
                Note = mealModel.Note
            };

            meal.Category = categoryMapper.Map(mealModel.Category);

            return meal;
        }

        public override MealModel Map(Meal meal)
        {
            if (meal == null)
                return null;

            CategoryMapper categoryMapper = new CategoryMapper();

            MealModel mealModel = new MealModel()
            {
                Id = meal.Id,
                Name = meal.Name,
                Price = meal.Price,
                Quantity = meal.Quantity,
                Note = meal.Note
            };

            mealModel.Category = categoryMapper.Map(meal.Category);

            return mealModel;
        }
    }
}
