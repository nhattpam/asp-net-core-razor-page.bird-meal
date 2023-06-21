using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.UserRepository;
using ViewModel;

namespace BirdMeal.Pages.Staffs.Meals
{
    public class DeleteProductModel : PageModel
    {
        public IUserRepository userRepository { get; set; }
        public DeleteProductModel()
        {
            userRepository = new UserRepository();
        }
        public IActionResult OnGet(string productId)
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

      
    }
}
