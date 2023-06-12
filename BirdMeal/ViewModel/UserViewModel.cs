using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Orders = new HashSet<OrderViewModel>();
        }

        public int UserId { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Role { get; set; }
        public int? WalletId { get; set; }

        public virtual WalletViewModel? Wallet { get; set; }
        public virtual ICollection<OrderViewModel> Orders { get; set; }
    }
}
