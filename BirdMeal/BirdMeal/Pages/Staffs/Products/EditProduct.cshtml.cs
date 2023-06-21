using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.ProductRepository;
using Repository.UserRepository;
using System.IO;
using ViewModel;

namespace BirdMeal.Pages.Staffs.Products
{
    public class EditProductModel : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private IProductRepository _productRepository { get; set; }
        private IUserRepository _userRepository { get; set; }
        [BindProperty]
        public ProductViewModel EditProduct { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public EditProductModel(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _productRepository = new ProductRepository();
            _userRepository = new UserRepository();
        }
        public IActionResult OnGet(int id)
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = _userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("STAFF"))
                {
                    var product = _productRepository.GetProductById(id);
                    if (product != null)
                    {
                        EditProduct = new ProductViewModel()
                        {
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                            Price = product.Price,
                            Quantity = product.Quantity,
                            Description = product.Description,
                            Status = product.Status,
                            Weight = product.Weight,
                            Image = product.Image,
                        };
                        return Page();
                    }
                    else
                    {
                        return RedirectToPage("/Error");
                    }
                }
            }

            return RedirectToPage("/Error");
        }

        public IActionResult OnPost()
        {
            
            Product existingProduct = _productRepository.GetProductById(EditProduct.ProductId);

            if (existingProduct == null)
            {
                return RedirectToPage("/Error");
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
                EditProduct.Image = fileName;
            }


            existingProduct.ProductName = EditProduct.ProductName;
            existingProduct.Price = EditProduct.Price;
            existingProduct.Description = EditProduct.Description;
            
            if(EditProduct.Image == null)
            {
                existingProduct.Image = existingProduct.Image;
            }
            else
            {
                existingProduct.Image = EditProduct.Image;
            }
            existingProduct.Status = EditProduct.Status;
            existingProduct.Weight = EditProduct.Weight;


            bool success = _productRepository.UpdateProduct(existingProduct);
            if (success)
            {
                TempData["EditSuccessMessage"] = "Product updated successfully.";
            }
            else
            {
                TempData["EditErrorMessage"] = "Failed to update the product.";
                return Page();
            }

            return RedirectToPage("/Staffs/Products/ListProduct");
        }
    }
}
