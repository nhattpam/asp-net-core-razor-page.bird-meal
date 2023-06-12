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
        public OrderDetailViewModel()
        {
            Bills = new HashSet<BillViewModel>();
        }

        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }

        public virtual OrderViewModel? Order { get; set; }
        public virtual ICollection<BillViewModel> Bills { get; set; }
    }
}
