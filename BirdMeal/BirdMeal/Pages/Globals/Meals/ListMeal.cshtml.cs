using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.MealRepository;
using ViewModel;

namespace BirdMeal.Pages.Globals.Meals
{
    public class ListMealModel : PageModel
    {
        private IMealRepository mealRepository { get; set; }
        public IEnumerable<MealViewModel> ListMeals { get; set; }
        public ListMealModel()
        {
            mealRepository = new MealRepository();  
        }
        public void OnGet()
        {
            ListMeals = ListMeal();
        }

        public IEnumerable<MealViewModel> ListMeal()
        {
            var meals = mealRepository.GetMealList();

            var dtos = meals.Select(pro => new MealViewModel()
            {
                MealId = pro.MealId,
                Description = pro.Description,
                RoutingTime = pro.RoutingTime,
                TotalCost = pro.TotalCost
            });

            return dtos;
        }
    }
}
