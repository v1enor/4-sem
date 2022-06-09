using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach
{
    public class WalletInfo : Tokens
    {
        public decimal USDPRICE { get; set; }
        public string Abr_NAME { get; set; }

        public WalletInfo(int IdCurrency, string TxLsit, string Adres, decimal Balance, int IdWallet, decimal USDPRICE, string Abr_NAME) : base(IdCurrency, TxLsit, Adres, Balance, IdWallet)
        {
            this.IdCurrency = IdCurrency;
            this.TxLsit = TxLsit;
            this.Adres = Adres;
            this.Balance = Balance;
            this.IdWallet = IdWallet;
            this.USDPRICE = USDPRICE;
            this.Abr_NAME = Abr_NAME;
            
        }


    }
}
