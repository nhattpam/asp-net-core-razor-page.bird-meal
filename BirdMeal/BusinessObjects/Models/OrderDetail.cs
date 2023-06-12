using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            Bills = new HashSet<Bill>();
        }

        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }

        public virtual Order? Order { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
