using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            MealProducts = new HashSet<MealProductViewModel>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public double? Weight { get; set; }

        public virtual ICollection<MealProductViewModel> MealProducts { get; set; }
    }
}
