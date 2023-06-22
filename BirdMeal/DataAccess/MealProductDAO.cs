using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MealProductDAO
    {

        private static MealProductDAO instance;
        private static object instanceLock = new object();

        public static MealProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MealProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<MealProduct> GetMealProductByMealId(string mealId)
        {
            IEnumerable<MealProduct> os = null;

            try
            {

                var context = new BirdMealContext();
                os = context.MealProducts.Include(pro => pro.Product)
                    .Include(k => k.Meal)
                    .Where(c => c.MealId.Equals(mealId));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return os;
        }

        public bool DeleteMealProduct(MealProduct mealProduct)
        {
            try
            {
                var context = new BirdMealContext();
                context.MealProducts.Remove(mealProduct);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                return false;
            }
        }
        public bool AddMealProduct(MealProduct mealProduct)
        {
            if (mealProduct == null)
                throw new ArgumentNullException(nameof(mealProduct));

            try
            {
                using (var context = new BirdMealContext())
                {
                    context.MealProducts.Add(mealProduct);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the product: {ex.Message}");
                return false;
            }
        }

    }
}
