using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Domain.Abstract;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAppWeb.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork DB;
        protected readonly UserManager<User> UserManager;

        public BaseController(IUnitOfWork db, UserManager<User> userManager)
        {
            DB = db;
            UserManager = userManager;
        }

        public User CurrentUser => UserManager.GetUserAsync(User).Result;

    }
}
