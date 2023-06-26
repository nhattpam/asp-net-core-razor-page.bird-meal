using BirdMeal.Session;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.MealProductRepository;
using Repository.MealRepository;
using Repository.UserRepository;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Documents;
using ViewModel;

namespace BirdMeal.Pages
{
    public class CartModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IUserRepository userRepository { get; set; }
        private IMealRepository mealRepository { get; set; }
        public List<CartViewModel> CartItems { get; set; } = new List<CartViewModel>();
        private IMealProductRepository mealProductRepository { get; set; }
        [BindProperty]
        public UserViewModel UserCart { get; set; }

        public CartModel(IHttpContextAccessor httpContextAccessor)
        {
            mealProductRepository = new MealProductRepository();
            mealRepository = new MealRepository();
            userRepository = new UserRepository();
            UserCart = new UserViewModel();
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult OnGet()
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("CUSTOMER"))
                {
                    CartItems = _httpContextAccessor.HttpContext.Session.Get<List<CartViewModel>>("cart") ?? new List<CartViewModel>();
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

        public IActionResult OnPostAddToCart(int userId, string mealId, float? total, Dictionary<int, int> quantity, Dictionary<int, int> productQuantity)
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("CUSTOMER"))
                {
                    Meal meal = mealRepository.GeMealById(mealId);
                    var cartItems = _httpContextAccessor.HttpContext.Session.Get<List<CartViewModel>>("cart") ?? new List<CartViewModel>();

                    if (cartItems.Count == 0)
                    {
                        CartViewModel cart = new CartViewModel()
                        {
                            cartId = mealId,
                            price = total,
                            quantity = 1,
                            Meal = MapMealToViewModel(meal)
                        };
                        cartItems.Add(cart);
                        _httpContextAccessor.HttpContext.Session.Set("cart", cartItems);
                    }
                    else
                    {
                        int index = Exists(cartItems, mealId);
                        if(index == -1)
                        {
                            CartViewModel cart = new CartViewModel()
                            {
                                cartId = mealId,
                                price = total,
                                quantity = 1,
                                Meal = MapMealToViewModel(meal)
                            };
                            cartItems.Add(cart);
                        }
                        else
                        {
                            cartItems[index].quantity++;
                            cartItems[index].price = (float?) meal.TotalCost * cartItems[index].quantity;
                            //// Check if the quantity exceeds the product quantity
                            //// Retrieve the quantity and productQuantity dictionaries from the POST data
                            //var quantity = Request.Form["quantity"].ToDictionary(k => int.Parse(k.Key), v => int.Parse(v.Value));
                            //var productQuantity = Request.Form["productQuantity"].ToDictionary(k => int.Parse(k.Key), v => int.Parse(v.Value));
                            //int productId = Int32.Parse(cartItems[index].Meal.MealId); // Assuming the MealId property represents the product ID

                            //if (quantity.ContainsKey(productId) && productQuantity.ContainsKey(productId))
                            //{
                            //    int itemQuantity = quantity[productId];
                            //    int productQuantityAvailable = productQuantity[productId];

                            //    if (cartItems[index].quantity * itemQuantity > productQuantityAvailable)
                            //    {
                            //        ModelState.AddModelError(string.Empty, "Exceeded quantity");
                            //        // Display the "exceeded quantity" message or handle the situation accordingly
                            //        return Page();
                            //    }
                            //}
                        }
                        _httpContextAccessor.HttpContext.Session.Set("cart", cartItems);
                    }
                    UserCart = new UserViewModel()
                    {
                        UserId = u.UserId,
                        Phone = u.Phone,
                        Email = u.Email,
                        Address = u.Address,
                        Wallet = MapWalletToViewModel(u.Wallet),
                        FullName = u.FullName
                    };
                    return RedirectToPage("/Cart");
                }
            }
            else
            {
                return RedirectToPage("/Login");
            }
            return RedirectToPage("/Login");
        }
        private MealViewModel MapMealToViewModel(Meal meal)
        {
            return new MealViewModel()
            {
                MealId = meal.MealId,
                Description = meal.Description,
                RoutingTime = meal.RoutingTime,
                TotalCost = meal.TotalCost
            };
        }
        public IEnumerable<MealProductViewModel> List(string mealid)
        {
            var orderDetailsByOrderId = mealProductRepository.GetMealProductByMealId(mealid);
            var dtos = orderDetailsByOrderId.Select(oo => new MealProductViewModel()
            {
                MealProductId = oo.MealProductId,
                MealId = oo.MealId,
                Product = MapProductToViewModel(oo.Product),
                Quantity = oo.Quantity,
                ProductId = oo.ProductId,
                Meal = MapMealToViewModel(oo.Meal)
            });
            return dtos;
        }
        private ProductViewModel MapProductToViewModel(Product product)
        {
            return new ProductViewModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Quantity = product.Quantity,
                Price = product.Price,
                Image = product.Image
            };
        }

        private WalletViewModel MapWalletToViewModel(Wallet wallet)
        {
            return new WalletViewModel()
            {
                WalletId = wallet.WalletId,
                TransactionDate = wallet.TransactionDate,
                Balance = wallet.Balance,
            };
        }
        private int Exists(List<CartViewModel> cartItems, string id)
        {
            for (var i = 0; i < cartItems.Count; i++)
            {
                if (cartItems[i].cartId == id)
                {
                    return i;
                }
            }
            return -1;
        }


		public IActionResult OnPostRemoveFromCart(string cartId)
		{
			var cartItems = _httpContextAccessor.HttpContext.Session.Get<List<CartViewModel>>("cart") ?? new List<CartViewModel>();
			var itemToRemove = cartItems.FirstOrDefault(c => c.cartId == cartId);

			if (itemToRemove != null)
			{
				cartItems.Remove(itemToRemove);
				_httpContextAccessor.HttpContext.Session.Set("cart", cartItems);
			}

			return RedirectToPage("/Cart");
		}
	}

}
