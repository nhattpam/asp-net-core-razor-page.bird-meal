using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MealDAO
    {
        private static MealDAO instance;
        private static object instanceLock = new object();

        public static MealDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MealDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Meal> GetMealList()
        {
            IEnumerable<Meal> meals = null;

            try
            {
                var context = new BirdMealContext();
                // Get From Database

                meals = context.Meals;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return meals;
        }

        public IEnumerable<Meal> GetMealListHot()
        {
            IEnumerable<Meal> meals = null;

            try
            {
                var context = new BirdMealContext();
                // Get From Database

                meals = context.Meals.Take(5);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return meals;
        }

        public Meal GeMealById(string mealId)
        {
            Meal p = null;

            try
            {

                var context = new BirdMealContext();
                p = context.Meals.SingleOrDefault(f => f.MealId.Equals(mealId)); 

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return p;
        }


        public bool UpdateMeal(Meal meal)
        {
            try
            {
                using (var context = new BirdMealContext())
                {
                    context.Meals.Update(meal);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the meal: {ex.Message}");
                return false;
            }
        }

        public bool AddMeal(Meal meal)
        {
            if (meal == null)
                throw new ArgumentNullException(nameof(meal));

            try
            {
                using (var context = new BirdMealContext())
                {
                    context.Meals.Add(meal);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the meal: {ex.Message}");
                return false;
            }
        }
    }
}
