using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MealRepository
{
    public class MealRepository : IMealRepository
    {
        public IEnumerable<Meal> GetMealList()
        {
            return MealDAO.Instance.GetMealList();
        }

        public IEnumerable<Meal> GetMealListHot()
        {
            return MealDAO.Instance.GetMealListHot();
        }

        public Meal GeMealById(string mealId)
        {
            return MealDAO.Instance.GeMealById(mealId);
        }
        public bool UpdateMeal(Meal meal)
        {
            return MealDAO.Instance.UpdateMeal(meal);
        }

        public bool AddMeal(Meal meal)
        {
            return MealDAO.Instance.AddMeal(meal);
        }

    }
}
