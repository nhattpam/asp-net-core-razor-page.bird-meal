using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.MealRepository;
using Repository.UserRepository;
using System.IO;
using ViewModel;

namespace BirdMeal.Pages.Staffs.Meals
{
    public class AddMealModel : PageModel
    {
        private IUserRepository userRepository { get; set; }
        private IMealRepository mealRepository { get; set; }
        [BindProperty]
        public MealViewModel AddMeal { get; set; }
        public AddMealModel()
        {
            userRepository = new UserRepository();
            mealRepository = new MealRepository();
            AddMeal = new MealViewModel();
        }
        public IActionResult OnGet()
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("STAFF"))
                {
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Error");
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return the current page with the validation errors
                return Page();
            }
            var mealExist = mealRepository.GeMealById(AddMeal.MealId);
            if(mealExist == null)
            {
                var meal = new Meal()
                {
                    MealId = AddMeal.MealId,
                    Description = AddMeal.Description,
                    TotalCost = 0,
                    RoutingTime = AddMeal.RoutingTime
                };

                bool check = mealRepository.AddMeal(meal);
                if (check)
                {
                    return RedirectToPage("/Staffs/Meals/ListMeal");
                }
                else
                {
                    return RedirectToPage("/Staffs/Meals/ListMeal");
                }
            }
            else
            {
                TempData["DeleteErrorMessage"] = "MealId da ton tai!";
                return Page();
            }
            
        }
    }
}
