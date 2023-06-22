using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MealProductViewModel
    {
        public int MealProductId { get; set; }
        public string? MealId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual MealViewModel? Meal { get; set; }
        public virtual ProductViewModel? Product { get; set; }
    }
}
