using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.UserRepository;
using System.Windows;

namespace BirdMeal.Pages
{
    public class CartModel : PageModel
    {
		private IUserRepository userRepository { get; set; }

		public CartModel()
		{
			userRepository = new UserRepository();	
		}
		public IActionResult OnGet()
		{
			string loginMem = HttpContext.Session.GetString("loginMem");
			if (loginMem != null)
			{
				User u = userRepository.GetUserByEmail(loginMem);
				if (u != null && u.Role.Equals("CUSTOMER"))
				{
					return Page();
				}
			}
			else
			{
				return RedirectToPage("/Login");
			}
			return RedirectToPage("/Login");
		}

		public void OnPost()
		{
			
		}
	}
}
