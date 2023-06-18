using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.MealRepository;
using Repository.ProductRepository;
using Repository.UserRepository;
using ViewModel;

namespace BirdMeal.Pages.Staffs.Meals
{
    public class ListMealModel : PageModel
    {
        private IUserRepository userRepository { get; set; }
        public IEnumerable<MealViewModel> ListMeals { get; set; }  
        private IMealRepository mealRepository { get; set; }
        public ListMealModel()
        {
            userRepository = new UserRepository();
            mealRepository = new MealRepository();
        }
        public IActionResult OnGet()
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("STAFF"))
                {
                    ListMeals = List();
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Error");
        }

        private IEnumerable<MealViewModel> List()
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
