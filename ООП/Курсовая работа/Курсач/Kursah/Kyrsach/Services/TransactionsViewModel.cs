using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;

namespace Kyrsach.ViewModel
{
    internal class TransactionsViewModel 
    {

        public List<TransactionsList> Transactions
        {
            get; set;
        }

        public TransactionsViewModel()
        {


            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }
            else
            {
                using (var db = new CursachContext())
                {

                    var CID = Application.Current.Resources["CurID"].ToString();
                    var US = Application.Current.Resources["USER_ID"].ToString();

                    var ad = db.Tokens.Where(t => t.IdCurrency == Convert.ToInt32(CID)).Where(t => t.IdWallet == Convert.ToInt32(US)).First().Adres.ToString();
            
                    List<TransactionsList> trans = db.Transactions_List.Where(t => t.FromAdress == ad).ToList();
                    var ff = db.Transactions_List.Where(t => t.ToAdress == ad).ToList();

                    trans.AddRange(ff);


                    var trans2 = trans.Distinct();
                    Transactions = trans2.ToList();
                    var a = db.User.ToList();
                    var tr = db.Transactions_List.ToList();

                    var tr2 = db.Transactions_List;

                }
            }
        }
    }
}