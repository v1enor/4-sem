using System;
using System.Collections.Generic;
using System.Text;

namespace laba_2
{
    internal class Tovar_adapter : Iadaptable
    {
        private readonly Tovar _tovar;

        public Tovar_adapter(Tovar tv)
        {
            this._tovar = tv;
        }

        public void Add_rand_name()
        {
            
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < 8)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            _tovar.Name = Name;
        }

        public void Ser()
        {
            XmlSerializeWrapper.Serialize(_tovar, "C:/Users/ilya/Desktop/tovari.xml");
        }
    }
}
