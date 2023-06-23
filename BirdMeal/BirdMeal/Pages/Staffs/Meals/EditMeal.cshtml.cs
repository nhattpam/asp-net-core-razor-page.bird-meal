using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.MealRepository;
using Repository.UserRepository;
using System.IO;
using ViewModel;

namespace BirdMeal.Pages.Staffs.Meals
{
    public class EditMealModel : PageModel
    {

        private IUserRepository _userRepository { get; set; }
        private IMealRepository _mealRepository { get; set; }

        public EditMealModel()
        {
            _userRepository = new UserRepository(); 
            _mealRepository = new MealRepository();
        }
        [BindProperty]
        public MealViewModel EditMeal { get; set; }

        public IActionResult OnGet(string id)
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = _userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("STAFF"))
                {
                    var meal = _mealRepository.GeMealById(id);
                    if (meal != null)
                    {
                        EditMeal = new MealViewModel()
                        {
                            MealId = meal.MealId,
                            Description = meal.Description,
                            RoutingTime = meal.RoutingTime,
                            TotalCost = meal.TotalCost
                        };
                        return Page();
                    }
                    else
                    {
                        return RedirectToPage("/Error");
                    }
                }
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

            Meal existingMeal = _mealRepository.GeMealById(EditMeal.MealId);

            if (existingMeal == null)
            {
                return RedirectToPage("/Error");
            }

            // Perform additional validation checks
            if (string.IsNullOrWhiteSpace(EditMeal.Description))
            {
                ModelState.AddModelError("EditMeal.Description", "Description is required.");
                return Page();
            }


            if (EditMeal.TotalCost <= 0)
            {
                ModelState.AddModelError("EditMeal.TotalCost", "Total cost must be greater than 0.");
                return Page();
            }

            existingMeal.Description = EditMeal.Description;
            existingMeal.RoutingTime = EditMeal.RoutingTime;

            bool success = _mealRepository.UpdateMeal(existingMeal);
            if (success)
            {
                TempData["EditSuccessMessage"] = "Meal updated successfully.";
            }
            else
            {
                TempData["EditErrorMessage"] = "Failed to update the meal.";
                return Page();
            }

            return RedirectToPage("/Staffs/Meals/ListMeal");
        }

    }
}
