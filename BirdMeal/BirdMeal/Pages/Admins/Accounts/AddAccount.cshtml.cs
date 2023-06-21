using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.UserRepository;
using Repository.WalletRepository;
using System.IO;
using ViewModel;

namespace BirdMeal.Pages.Admins.Accounts
{
    public class AddAccountModel : PageModel
    {
        private IUserRepository userRepository { get; set; }
        public IWalletRepository walletRepository { get; set; }

        [BindProperty]
        public UserViewModel AddUser { get; set; }   
        public AddAccountModel()
        {
            userRepository = new UserRepository();
            AddUser = new UserViewModel();
            walletRepository = new WalletRepository();
        }
        public IActionResult OnGet()
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("ADMIN"))
                {
                    
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Error");
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
                Role = AddUser.Role,
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
                    ViewData["MessageSuccess"] = "Tao tai khoan thanh cong.";
                    return Page();
                }
                else
                {
                    ViewData["MessageFailed"] = "Email da ton tai";
                }
            }
            else
            {
                ViewData["MessageFailed"] = "Lam on nhap day du du lieu va khong chua khoang trang ";
            }
            return Page();
        }
    }
}
