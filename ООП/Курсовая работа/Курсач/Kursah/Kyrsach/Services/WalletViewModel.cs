using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Collections.ObjectModel;
using Kyrsach.Model;
using NBitcoin;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Kyrsach.View.Pages;

namespace Kyrsach.ViewModel
{
    public class WalletViewModel : INotifyPropertyChanged
    {
        private WalletInfo _SelectedToken;
        private ObservableCollection<WalletInfo> _Tokens;
        public decimal USDPRICE { get; set; }
        public string  Abr_NAME { get; set; }

        public WalletInfo SelectedToken
        {
            get
            {
                return this._SelectedToken;
            }

            set
            {
                this._SelectedToken = value;
                OnPropertyChanged("SelectedToken");
            }
        }

        public ObservableCollection<WalletInfo> Token_list
        {
            get
            {
                return this._Tokens;
            }
        }

        public WalletViewModel()
        {
            _Tokens = new ObservableCollection<WalletInfo>();

            var id = Application.Current.Resources["USER_ID"].ToString();
            var cu = Application.Current.Resources["CurID"];
            using (var db = new CursachContext())
            {
                var ad3 = db.Tokens.Where(t => t.IdWallet == Convert.ToInt32(id)).ToList();
                for(int i = 0; i < ad3.Count; i++)
                {
                    var tk = db.CurrencyList.Where(t => t.IdCurrency == ad3[i].IdCurrency).FirstOrDefault();
                    USDPRICE = Math.Round(tk.Price * ad3[i].Balance,2);
                    Abr_NAME = tk.Abbrecitation;
                    var wi = new WalletInfo(ad3[i].IdCurrency, ad3[i].TxLsit, ad3[i].Adres, ad3[i].Balance, ad3[i].IdWallet, USDPRICE, Abr_NAME);
                    _Tokens.Add(wi);
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
                Application.Current.Resources["CurID"] = this._SelectedToken.IdCurrency.ToString();
        }


    }
}