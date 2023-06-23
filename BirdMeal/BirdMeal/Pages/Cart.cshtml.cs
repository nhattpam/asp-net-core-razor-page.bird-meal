using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.UserRepository;
using System.Windows;
using ViewModel;

namespace BirdMeal.Pages
{
    public class CartModel : PageModel
    {
		private IUserRepository userRepository { get; set; }
		[BindProperty]
		public UserViewModel UserCart { get; set; }

		public CartModel()
		{
			userRepository = new UserRepository();
            UserCart = new UserViewModel();
        }
		public IActionResult OnGet()
		{
			string loginMem = HttpContext.Session.GetString("loginMem");
			if (loginMem != null)
			{
				User u = userRepository.GetUserByEmail(loginMem);
				if (u != null && u.Role.Equals("CUSTOMER"))
				{
					UserCart = new UserViewModel()
					{
						UserId = u.UserId,
						Phone= u.Phone,
						Email = u.Email,
						Address = u.Address,
						Wallet = MapWalletToViewModel(u.Wallet),
						FullName = u.FullName
					};
					return Page();
				}
			}
			else
			{
				return RedirectToPage("/Login");
			}
			return RedirectToPage("/Login");
		}

        public IActionResult OnPostAddToCart(int userId, string mealId, float? total)
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("CUSTOMER"))
                {
                    UserCart = new UserViewModel()
                    {
                        UserId = u.UserId,
                        Phone = u.Phone,
                        Email = u.Email,
                        Address = u.Address,
                        Wallet = MapWalletToViewModel(u.Wallet),
                        FullName = u.FullName
                    };
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Login");
            }
            return RedirectToPage("/Login");
        }

        private WalletViewModel MapWalletToViewModel(Wallet wallet)
        {
            return new WalletViewModel()
            {
               WalletId = wallet.WalletId,
			   TransactionDate = wallet.TransactionDate,
			   Balance= wallet.Balance,
            };
        }
    }
}
