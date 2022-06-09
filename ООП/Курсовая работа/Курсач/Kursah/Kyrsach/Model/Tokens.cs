using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kyrsach
{
    public partial class Tokens 
    {
        public int IdCurrency { get; set; }
        public string TxLsit { get; set; }
        public string Adres { get; set; }
        public decimal Balance { get; set; }
        public int IdWallet { get; set; }

        public virtual CurrencyList IdCurrencyNavigation { get; set; }
        public virtual User IdWalletNavigation { get; set; }

        public Tokens(int IdCurrency, string TxLsit, string Adres, decimal Balance, int IdWallet)
        {
            this.IdCurrency = IdCurrency;
            this.TxLsit = TxLsit;
            this.Adres = Adres;
            this.Balance = Balance;
            this.IdWallet = IdWallet;
           
        }

    }
}