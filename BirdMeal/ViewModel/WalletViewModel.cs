using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class WalletViewModel
    {
        public int? WalletId { get; set; }
        public double? Balance { get; set; }
        public DateTime? TransactionDate { get; set; }

        public virtual UserViewModel? User { get; set; }
    }
}
