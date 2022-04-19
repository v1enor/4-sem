using System;
using System.Collections.Generic;
using System.Text;

namespace laba_2
{
    internal class Director 
    {

        private Add_tovar_interface _builder;

        

        public Add_tovar_interface Builder
        {
            set { _builder = value; }
        }

        public void BuildProduct()
        {
            string item = "test";
            Proizvoditel pr = new Proizvoditel() { Adres = "asf", Country = "afs", Organization = "saf", Phone = "saf"};

            this._builder.Name_tovara(item);
            this._builder.Invent_number(item);
            this._builder.Quantity(1);
            this._builder.Weigth(item);
            this._builder.Type(item);
            this._builder.Price("124");
            this._builder.Size_tovara("Средний");
            this._builder.DataPostyplenia("12-22-2002");
            this._builder.Proizvoditel(pr);
            this._builder.Save_in_file();
            


        }
        

    }
}
