using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            OrderDetails = new HashSet<OrderDetailViewModel>();
        }

        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? TotalPrice { get; set; }
        public string? Status { get; set; }

        public virtual UserViewModel? User { get; set; }
        public virtual ICollection<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
