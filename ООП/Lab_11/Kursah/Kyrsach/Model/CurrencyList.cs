using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kyrsach
{
    public partial class CurrencyList
    {
        public int IdCurrency { get; set; }
        public string Abbrecitation { get; set; }
        public decimal Price { get; set; }
        public string TokenSite { get; set; }
        public string ExplorerSite { get; set; }
    }
}