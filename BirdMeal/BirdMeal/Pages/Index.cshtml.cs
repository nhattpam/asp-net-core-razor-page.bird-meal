using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.ProductRepository;
using Repository.UserRepository;
using System.Windows;
using ViewModel;

namespace BirdMeal.Pages
{
    public class IndexModel : PageModel
    {
        private IUserRepository userRepository { get; set; }
        private readonly ILogger<IndexModel> _logger;
        public IProductRepository productRepository { get; set; }
        public IEnumerable<ProductViewModel> ListProducts { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            userRepository = new UserRepository();
            productRepository = new ProductRepository();
        }

        public IActionResult OnGet()
        {
            string loginMem = HttpContext.Session.GetString("loginMem");

            if (loginMem == null)
            {
                ListProducts = List();
                return Page();
            }
            else
            {
                User u = userRepository.GetUserByEmail(loginMem);
                if (u.Role.Equals("STAFF") || u.Role.Equals("ADMIN"))
                {
                    return RedirectToPage("/Error");
                }
            }
            ListProducts = List();
            return Page();
        }

		public IEnumerable<ProductViewModel> List()
		{
			var products = productRepository.GetProductList();

			var dtos = products.Select(pro => new ProductViewModel()
			{
				ProductId = pro.ProductId,
				ProductName = pro.ProductName,
				Price = pro.Price,
                Quantity = pro.Quantity,
                Description = pro.Description,
                Weight= pro.Weight,
				Image = pro.Image
			});

			return dtos;
		}
	}
}