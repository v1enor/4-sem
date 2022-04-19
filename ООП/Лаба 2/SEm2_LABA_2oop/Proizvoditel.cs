using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;


namespace laba_2
{
    [Serializable]
    [XmlRoot(Namespace = "SEm2_LABA_2oop")]
    [XmlType("proizvoditel")]

    public class Proizvoditel
    {
        [XmlElement(ElementName = "organization")]
        public string Organization;

        [XmlElement(ElementName = "strana")]
        public string Country;

        [XmlElement(ElementName = "adres")]
        public string Adres;

        [XmlElement(ElementName = "telefon")]
        public string Phone;

        [XmlElement(ElementName = "id")]
        public Guid Id { get; set; }


        public Proizvoditel()
            {
            Id = Guid.NewGuid();
        }


    }
}
