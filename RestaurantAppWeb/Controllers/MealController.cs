using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Domain.Abstract;
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
            return View();
        }
    }
}
