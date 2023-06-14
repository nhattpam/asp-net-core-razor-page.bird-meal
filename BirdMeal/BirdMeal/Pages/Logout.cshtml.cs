using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdMeal.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
			// Clear session
			HttpContext.Session.Clear();

			// Perform additional logout tasks if needed

			// Redirect to a desired page
			return RedirectToPage("/Login");
		}
    }
}
