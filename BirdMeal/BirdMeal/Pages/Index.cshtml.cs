using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Windows;

namespace BirdMeal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if((HttpContext.Session.GetString("loginMemId") != null))
                {
                int userId = Int32.Parse(HttpContext.Session.GetString("loginMemId"));
                if (userId != null)
                {
                    MessageBox.Show(userId.ToString());
                }
            }
            
            
        }
    }
}