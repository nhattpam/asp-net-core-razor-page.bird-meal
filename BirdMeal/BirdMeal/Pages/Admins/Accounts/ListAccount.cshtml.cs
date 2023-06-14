using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.UserRepository;
using ViewModel;

namespace BirdMeal.Pages.Admins.Accounts
{
    public class ListAccountModel : PageModel
    {
        private IUserRepository userRepository { get; set; }
        public IEnumerable<UserViewModel> ListUsers { get; set; }
        public ListAccountModel()
        {
            userRepository = new UserRepository();
        }
        public IActionResult OnGet()
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("ADMIN"))
                {
                    ListUsers = List();
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Error");
        }

        private IEnumerable<UserViewModel> List()
        {
            var cuses = userRepository.GetUsersList();

            var dtos = cuses.Select(c => new UserViewModel()
            {
                UserId = c.UserId,
                FullName = c.FullName,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                Role = c.Role
            });

            return dtos;
        }

    }
}
