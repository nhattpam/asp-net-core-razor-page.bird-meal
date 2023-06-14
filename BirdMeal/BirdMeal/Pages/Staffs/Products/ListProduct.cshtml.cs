using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.ProductRepository;
using Repository.UserRepository;
using System.Windows;
using ViewModel;

namespace BirdMeal.Pages.Staffs.Products
{
    public class ListProductModel : PageModel
    {
        private IUserRepository userRepository { get; set; }
        private IProductRepository productRepository { get; set; }
        public IEnumerable<ProductViewModel> ListProducts { get; set; }
        public ListProductModel()
        {
            userRepository = new UserRepository();
            productRepository = new ProductRepository();
        }
         
        public IActionResult OnGet()
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("STAFF"))
                {
                    ListProducts = List();
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Error");
        }

        private IEnumerable<ProductViewModel> List()
        {
            var products = productRepository.GetProductList();

            var dtos = products.Select(pro => new ProductViewModel()
            {
                ProductId = pro.ProductId,
                ProductName = pro.ProductName,
                Price = pro.Price,
                Quantity = pro.Quantity,
                Description = pro.Description,
                Weight = pro.Weight,
                Image = pro.Image,
                Status = pro.Status
            });

            return dtos;
        }
    }
}
