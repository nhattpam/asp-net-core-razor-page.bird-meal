using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.WalletRepository
{
    public class WalletRepository : IWalletRepository
    {
        public int? AddWallet()
        {
            return WalletDAO.Instance.AddWallet();
        }
    }
}
