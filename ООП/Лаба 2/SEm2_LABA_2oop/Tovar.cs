using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace laba_2
{
    [Serializable]
    [XmlRoot(Namespace = "laba_2")]
    [XmlType("items")]
    public class Tovar : Proizvoditel
    {
        [XmlElement(ElementName = "Name")]
        public string Name;

        [XmlElement(ElementName = "InvetarniNumber")]
        public string InvetarniNumber;

        [XmlElement(ElementName = "Size")]
        public string Size;

        [XmlElement(ElementName = "Weight")]
        public string Weight;

        [XmlElement(ElementName = "Type")]
        public string Type;

        [XmlElement(ElementName = "DataPostyplenia")]
        public string DataPostyplenia;

        [XmlElement(ElementName = "Quantity")]
        public int Quantity;

        [XmlElement(ElementName = "Price")]
        public string Price;

        [XmlElement(ElementName = "Proizvoditel")]
        public Proizvoditel Proizvod = new Proizvoditel();

        public Tovar() { }

    }
}
