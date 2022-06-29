using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kyrsach
{
    public partial class TransactionsList
    {
        public string TxHash { get; set; }
        public int IdCurrency { get; set; }
        public string ToAdress { get; set; }
        public decimal? Fee { get; set; }
        public string FromAdress { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public decimal? UsdPrice { get; set; }

        public virtual CurrencyList IdCurrencyNavigation { get; set; }
    }
}