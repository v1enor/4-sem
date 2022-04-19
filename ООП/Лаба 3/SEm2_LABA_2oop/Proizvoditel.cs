using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace laba_2
{
    [Serializable]
    [XmlRoot(Namespace = "SEm2_LABA_2oop")]
    [XmlType("proizvoditel")]

    public class CountryAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string country = value.ToString();
                if (country.StartsWith("Be"))
                    return true;
                else
                    this.ErrorMessage = "ЕСТЬ ТОЛЬКО ДВЕ СТРАНЫ, И НАЧИНАЮТЬСЯ ОНИ НА Be";
            }
            return false;
        }
    }



    public class Proizvoditel 
    {



        [XmlElement(ElementName = "Organization")]
        public string Organization { get; set; }
        
        [Country]
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }

        [XmlElement(ElementName = "Adres")]
        public string Adres { get; set; }

        [XmlElement(ElementName = "Phone")]
        public string Phone { get; set; }

        [XmlElement(ElementName = "Id")]
        public Guid Id { get; set; }


        public Proizvoditel()
            {
            Id = Guid.NewGuid();
        }


    }
}
