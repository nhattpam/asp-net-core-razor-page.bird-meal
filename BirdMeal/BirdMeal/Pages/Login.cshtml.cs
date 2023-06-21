using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.UserRepository;
using ViewModel;

namespace BirdMeal.Pages
{
    public class LoginModel : PageModel
    {
        public IUserRepository userRepository { get; set; }

        [BindProperty]
        public LoginViewModel LoginMember { get; set; }
        public LoginModel()
        {
            userRepository = new UserRepository();
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            string email = LoginMember.Email;
            string password = LoginMember.Password;

            if(!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password)) 
            {
                var user = userRepository.Login(email, password);
                if (user != null)
                {
                    var dto = new LoginViewModel()
                    {
                        UserId = user.UserId,
                        FullName = user.FullName,
                        Email = user.Email,
                        Password = user.Password,
                        Role = user.Role
                    };

                    if (dto.Role.Equals("ADMIN"))
                    {
                        HttpContext.Session.SetString("loginMemName", dto.FullName);
                        HttpContext.Session.SetString("loginMem", dto.Email);
                        HttpContext.Session.SetString("loginMemId", dto.UserId.ToString());
                        return RedirectToPage("Admins/Index");
                    }
                    else if (dto.Role.Equals("STAFF"))
                    {
                        HttpContext.Session.SetString("loginMemName", dto.FullName);
                        HttpContext.Session.SetString("loginMem", dto.Email);
                        HttpContext.Session.SetString("loginMemId", dto.UserId.ToString());
                        return RedirectToPage("Staffs/Orders/ListOrder");
                    }
                    else
                    {
                        HttpContext.Session.SetString("loginMemName", dto.FullName);
                        HttpContext.Session.SetString("loginMem", dto.Email);
                        HttpContext.Session.SetString("loginMemId", dto.UserId.ToString());
                        return RedirectToPage("/Index");
                    }
                }
                else
                {
                    ViewData["loginFailed"] = "Khong tim thay tai khoan";
                    return Page();
                }
            }
            ViewData["loginFailed"] = "Lam on nhap day du thong tin va khong co khoang trang!";
            return Page();

        }
    }
}
