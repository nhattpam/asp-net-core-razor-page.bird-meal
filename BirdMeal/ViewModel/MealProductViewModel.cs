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
        public MealProductViewModel()
        {
            Bills = new HashSet<BillViewModel>();
        }

        public int MealProductId { get; set; }
        public int? MealId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual MealViewModel? Meal { get; set; }
        public virtual ProductViewModel? Product { get; set; }
        public virtual ICollection<BillViewModel> Bills { get; set; }
    }
}
