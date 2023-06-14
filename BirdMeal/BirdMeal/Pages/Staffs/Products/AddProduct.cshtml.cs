using BusinessObjects.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.ProductRepository;
using Repository.UserRepository;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;

namespace BirdMeal.Pages.Staffs.Products
{
    public class AddProductModel : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private IProductRepository _productRepository { get; set; }
        private IUserRepository _userRepository { get; set; }

        [BindProperty]
        public ProductViewModel AddProduct { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public AddProductModel(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _productRepository = new ProductRepository();
            _userRepository = new UserRepository();
        }

        public IActionResult OnGet()
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = _userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("STAFF"))
                {
                    return Page();
                }
            }

            return RedirectToPage("/Error");
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Image != null && Image.Length > 0)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(fileStream);
                }

                AddProduct.Image = uniqueFileName;
            }

            var product = new Product()
            {
                ProductName = AddProduct.ProductName,
                Price = AddProduct.Price,
                Description = AddProduct.Description,
                Image = AddProduct.Image,
                Status = AddProduct.Status,
                Weight = AddProduct.Weight
            };

            bool check = _productRepository.AddProduct(product);
            if (check)
            {
                MessageBox.Show("THANH CONG");
            }
            else
            {
                MessageBox.Show("FAILED");
            }

            return RedirectToPage("/Staffs/Products/Index");
        }
    }
}
