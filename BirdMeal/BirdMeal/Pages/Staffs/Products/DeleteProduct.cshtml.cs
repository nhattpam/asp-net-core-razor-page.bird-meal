using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.ProductRepository;
using Repository.UserRepository;
using ViewModel;

namespace BirdMeal.Pages.Staffs.Products
{
    public class DeleteProductModel : PageModel
    {
        private IProductRepository _productRepository { get; set; }
        private IUserRepository _userRepository { get; set; }
        [BindProperty]
        public Product ProductDelete { get; set; }
        public DeleteProductModel()
        {
            _productRepository = new ProductRepository();
            _userRepository = new UserRepository();
            ProductDelete = new Product();
        }
        public IActionResult OnGet(int id)
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = _userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("STAFF"))
                {
                    ProductDelete = _productRepository.GetProductById(id);
                    if (ProductDelete == null)
                    {
                        return RedirectToPage("/Error");
                    }

                    return Page();
                }
            }

            return RedirectToPage("/Error");
        }

        public IActionResult OnPost()
        {
            if (ProductDelete == null)
            {
                return RedirectToPage("/Error");
            }
            
            bool check = _productRepository.DeleteProductById(ProductDelete.ProductId);
            if(check)
            {
                return RedirectToPage("/Staffs/Products/ListProduct");
            }
            return Page();

        }
    }
}
