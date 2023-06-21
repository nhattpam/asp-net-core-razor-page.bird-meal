using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.UserRepository;
using ViewModel;

namespace BirdMeal.Pages
{
    public class MyWalletModel : PageModel
    {
        private IUserRepository userRepository { get; set; }
        [BindProperty]
        public UserViewModel EditUser { get; set; }

        public MyWalletModel()
        {
            userRepository = new UserRepository();
            EditUser = new UserViewModel();
        }
        public IActionResult OnGet(int id)
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("CUSTOMER"))
                {
                    var user = userRepository.GetUserById(id);
                    if (user != null)
                    {
                        EditUser = new UserViewModel()
                        {
                            UserId = user.UserId,
                            Password = user.Password,
                            FullName = user.FullName,
                            Email = user.Email,
                            Phone = user.Phone,
                            Address = user.Address,
                            Wallet = MapWalletToViewModel(user.Wallet)
                        };

                        return Page();
                    }
                    else
                    {
                        return RedirectToPage("/Error");
                    }
                }
            }
            else
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Error");
        }

        private WalletViewModel MapWalletToViewModel(Wallet wallet)
        {
            return new WalletViewModel()
            {
                WalletId = wallet.WalletId,
                Balance = wallet.Balance,
                TransactionDate = wallet.TransactionDate
            };
        }
    }
}
