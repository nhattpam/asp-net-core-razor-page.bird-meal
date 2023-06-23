using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Wallet
    {
        public int? WalletId { get; set; }
        public double? Balance { get; set; }
        public DateTime? TransactionDate { get; set; }

        public virtual User? User { get; set; }
    }
}
