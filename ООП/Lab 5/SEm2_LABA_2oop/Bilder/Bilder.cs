using System;
using System.Collections.Generic;
using System.Text;

namespace laba_2
{
    internal class Bilder : Add_tovar_interface
    {
        
        
        
        private Tovar _tovar = new Tovar();

        public Bilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            _tovar = new Tovar();
        }


        public void DataPostyplenia(string item)
        {
            this._tovar.DataPostyplenia = item;
        }

        public void Invent_number(string Invent_number)
        {
            this._tovar.InvetarniNumber = Invent_number;
        }

        public void Price(string Price)
        {
            this._tovar.Price = Price;
        }

        public void Proizvoditel(Proizvoditel producer)
        {
            this._tovar.proizvod = producer;
        }

        public void Quantity(int Quantity)
        {
            this._tovar.Quantity = Quantity;
        }

        public void Type(string Type)
        {
            this._tovar.Type = Type;
        }

        public void Weigth(string Weigth)
        {
            this._tovar.Weight = Weigth;
        }

        public void Name_tovara(string Name)
        {
            this._tovar.Name = Name;
        }

        public void Size_tovara(string Size)
        {
            this._tovar.Size = Size;
        }

        public void Save_in_file()
        {
            XmlSerializeWrapper.Serialize(this._tovar, "C:/Users/ilya/Desktop/tovari.xml");
        }
        
    }
}
