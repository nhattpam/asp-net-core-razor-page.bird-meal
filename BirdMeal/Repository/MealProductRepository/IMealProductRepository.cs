using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MealProductRepository
{
    public interface IMealProductRepository
    {
        public IEnumerable<MealProduct> GetMealProductByMealId(string mealId);

        public bool DeleteMealProduct(MealProduct mealProduct);
        public bool AddMealProduct(MealProduct mealProduct);

    }
}
