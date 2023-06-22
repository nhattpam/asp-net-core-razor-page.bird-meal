using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class OrderDetailViewModel
    {
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }
        public string? MealId { get; set; }

        public virtual MealViewModel? Meal { get; set; }
        public virtual OrderDetail? Order { get; set; }
    }
}
