using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Core.Domain.Abstract
{
    public interface IMealRepository
    {
        int Add(Meal meal);
        bool Update(Meal meal);
        List<Meal> Get();
        Meal FindById(int id);
    }
}
