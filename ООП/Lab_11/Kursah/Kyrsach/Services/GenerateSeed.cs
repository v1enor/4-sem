using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NBitcoin;

namespace Kyrsach.Model
{
    internal class GenerateSeed
    {
        public void GenerateMnemo()
        {
            var mnemo = new Mnemonic(Wordlist.English, WordCount.Twelve);
            Application.Current.Resources["MNEMO"] = mnemo.ToString();
        }
    }
}