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
                    .Where(c => c.MealId.Equals(mealId));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return os;
        }
    }
}
