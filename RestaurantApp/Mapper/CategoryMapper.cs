using Restaurant.Core.Domain.Entities;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Mapper
{
    public class CategoryMapper : BaseMapper<Category, CategoryModel>
    {
        public override Category Map(CategoryModel categoryModel)
        {
            Category category = new Category();
            category.Id = categoryModel.Id;
            category.Name = categoryModel.Name;
            category.Note = categoryModel.Note;
           
            return category;
        }

        public override CategoryModel Map(Category category)
        {
            CategoryModel categoryModel = new CategoryModel();

            categoryModel.Id = category.Id;
            categoryModel.Name = category.Name;
            categoryModel.Note = category.Note;

            return categoryModel;
        }
    }
}
