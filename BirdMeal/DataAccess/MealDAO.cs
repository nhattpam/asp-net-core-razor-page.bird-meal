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



    }
}
