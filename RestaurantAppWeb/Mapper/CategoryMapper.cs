using Restaurant.Core.Domain.Entities;
using RestaurantAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAppWeb.Mapper
{
    public class CategoryMapper : BaseMapper<Category, CategoryModel>
    {
        public override Category Map(CategoryModel categoryModel)
        {
            if (categoryModel == null)
                return null;

            Category category = new Category();
            category.Id = categoryModel.Id;
            category.Name = categoryModel.Name;
            category.Note = categoryModel.Note;

            return category;
        }

        public override CategoryModel Map(Category category)
        {
            if (category == null)
                return null;

            CategoryModel categoryModel = new CategoryModel();

            categoryModel.Id = category.Id;
            categoryModel.Name = category.Name;
            categoryModel.Note = category.Note;

            return categoryModel;
        }
    }
}
