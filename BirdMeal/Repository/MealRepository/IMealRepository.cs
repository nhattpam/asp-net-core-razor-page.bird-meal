using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MealRepository
{
    public interface IMealRepository
    {
        public IEnumerable<Meal> GetMealList();
        public IEnumerable<Meal> GetMealListHot();
        public Meal GeMealById(string mealId);

        public bool UpdateMeal(Meal meal);
        public bool AddMeal(Meal meal);
    }
}
