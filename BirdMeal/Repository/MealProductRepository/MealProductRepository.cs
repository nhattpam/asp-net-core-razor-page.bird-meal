using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MealProductRepository
{
    public class MealProductRepository : IMealProductRepository
    {
        public IEnumerable<MealProduct> GetMealProductByMealId(string mealId)
        {
            return MealProductDAO.Instance.GetMealProductByMealId(mealId);
        }

        public bool DeleteMealProduct(MealProduct mealProduct)
        {
            return MealProductDAO.Instance.DeleteMealProduct(mealProduct);
        }
        public bool AddMealProduct(MealProduct mealProduct)
        {
            return MealProductDAO.Instance.AddMealProduct(mealProduct);
        }
    }
}
