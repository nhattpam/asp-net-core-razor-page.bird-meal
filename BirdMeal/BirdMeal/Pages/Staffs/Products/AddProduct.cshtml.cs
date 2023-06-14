using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.UserRepository;

namespace BirdMeal.Pages.Staffs.Products
{
    public class AddProductModel : PageModel
    {
        private IUserRepository userRepository { get; set; }
        public AddProductModel()
        {
            userRepository = new UserRepository();
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
    }
}
