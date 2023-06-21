using BusinessObjects.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.ProductRepository;
using Repository.UserRepository;
using System;
using System.IO;
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

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return the current page with the validation errors
                return Page();
            }
            if (Image != null && Image.Length > 0)
            {
                // Generate a unique file name for the image
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);

                // Set the path where you want to save the image
                string imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                string fullPath = Path.Combine(imagePath, fileName);

                // Create the directory if it doesn't exist
                Directory.CreateDirectory(imagePath);

                // Save the image file to the specified path
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    Image.CopyTo(fileStream);
                }

                // Set the image file name in the product object
                AddProduct.Image = fileName;
            }

            var product = new Product()
            {
                ProductName = AddProduct.ProductName,
                Price = AddProduct.Price,
                Description = AddProduct.Description,
                Image = AddProduct.Image,
                Status = AddProduct.Status,
                Weight = AddProduct.Weight,
                Quantity = AddProduct.Quantity
            };

            bool check = _productRepository.AddProduct(product);
            if (check)
            {
                return RedirectToPage("/Staffs/Products/ListProduct");
            }
            else
            {
                return RedirectToPage("/Staffs/Products/ListProduct");
            }
        }
    }
}
