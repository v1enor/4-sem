using System;
using System.Collections.Generic;
using System.Text;

namespace laba_2
{
    internal interface Add_tovar_interface
    {
        void Name_tovara(string Name);
        void Invent_number(string Invent_number);
        void Size_tovara(string Size);
        void Weigth(string Weigth);
        void Type(string Type);
        void DataPostyplenia(string DataPostyplenia);
        void Quantity(int Quantity);
        void Price(string Price);
        void Proizvoditel(Proizvoditel producer);
        void Save_in_file();
    }
}
