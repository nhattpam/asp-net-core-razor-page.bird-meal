using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.UserRepository;
using System.Windows;
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
        private Wallet MapVMToVWallet(WalletViewModel walletVM)
        {
            return new Wallet()
            {
                WalletId = EditUser.WalletId,
				Balance = walletVM.Balance,
                TransactionDate = walletVM.TransactionDate
            };
        }

        public IActionResult OnPost()
        {
            var userWallet = userRepository.GetUserById(EditUser.UserId);
            if (userWallet != null)
            {
                userWallet = new User()
                {
                    UserId = userWallet.UserId,
                    Address = userWallet.Address,
                    FullName = userWallet.FullName,
                    Email = userWallet.Email,
                    Phone = userWallet.Phone,
                    Role = userWallet.Role,
                    Password = userWallet.Password,
                    WalletId = userWallet.WalletId,
                    Wallet = userWallet.Wallet
                };
                userWallet.Wallet.Balance = EditUser.Wallet.Balance;
                bool success = userRepository.UpdateUser(userWallet);
                if (success)
                {
                    TempData["EditSuccessMessage"] = "Balance updated successfully.";
                }
                TempData["EditErrorMessage"] = "Balance updated failed.";

            }

            return RedirectToPage(new { id = EditUser.UserId });
        }
    }
}
