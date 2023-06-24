using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CartViewModel
    {
        public string cartId { get; set; }
        public int quantity { get; set; }
        public float? price { get; set; }
        public MealViewModel Meal { get; set; }
    }
}
