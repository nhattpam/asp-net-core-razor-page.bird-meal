using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.UserRepository;
using Repository.WalletRepository;
using ViewModel;

namespace BirdMeal.Pages
{
    public class RegisterModel : PageModel
    {
        public IUserRepository userRepository { get; set; }
        public IWalletRepository walletRepository { get; set; }

        [BindProperty]
        public UserViewModel AddUser { get; set; }

        public RegisterModel()
        {
            userRepository = new UserRepository();
            walletRepository = new WalletRepository();
            AddUser = new UserViewModel();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var cus = new User()
            {
                UserId = 0,
                FullName = AddUser.FullName,
                Email = AddUser.Email,
                Password = AddUser.Password,
                Phone = AddUser.Phone,
                Address = AddUser.Address,
                Role = "CUSTOMER",
                WalletId = walletRepository.AddWallet()
            };

            if (!string.IsNullOrWhiteSpace(AddUser.FullName)
                    && !string.IsNullOrWhiteSpace(AddUser.Password)
                    && !string.IsNullOrWhiteSpace(AddUser.Phone)
                    && !string.IsNullOrWhiteSpace(AddUser.Address)
                    && !string.IsNullOrWhiteSpace(AddUser.Email)
                    )
            {
                var cusEmailInDB = userRepository.GetUserByEmail(AddUser.Email);
                if (cusEmailInDB == null)
                {
                    
                    userRepository.AddUser(cus);
                    ViewData["MessageSuccess"] = "Dang ky thanh cong! Lam on dang nhap.";
                    return Page();
                }
                else
                {
                    ViewData["MessageFailed"] = "Email da ton tai";
                }
            }
            else
            {
                ViewData["MessageFailed"] = "Lam on nhap day du du lieu va khong chua khoang trang";
            }
            return Page();
        }
    }
}
