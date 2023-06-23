using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataAccess
{
    public class WalletDAO
    {
        // Using Singleton Pattern
        private static WalletDAO instance = null;
        private static object instanceLook = new object();

        public static WalletDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new WalletDAO();
                    }
                    return instance;
                }
            }
        }

        public int? AddWallet()
        {
            Wallet w = null;
            try
            {
                w = new Wallet();
                w.Balance = 0;
                var context = new BirdMealContext();
                context.Wallets.Add(w);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return w.WalletId;
        }



       
    }
}
