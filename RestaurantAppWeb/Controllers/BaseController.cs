using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAppWeb.Controllers
{
    public class BaseController : Controller
    {
       protected IUnitOfWork DB;
       public BaseController(IUnitOfWork db)
       {
            DB = db;
       }
    }
}
