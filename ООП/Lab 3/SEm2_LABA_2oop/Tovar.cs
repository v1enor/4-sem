using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;


namespace laba_2
{
    [Serializable]
    [XmlRoot(Namespace = "laba_2")]
    [XmlType("Order")]
    public class Tovar : Proizvoditel 
    {
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Длина должна быть в диапазоне от {2}-{1} символов")]
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "InvetarniNumber")]
        //[Range(1,10000, ErrorMessage = "Инвентарный номер должен быть в диапозоне от {1}-{2}")]
        [RegularExpression(@"^[0-9]+$", 
         ErrorMessage = "не то")]
        public int InvetarniNumber { get; set; }

        [XmlElement(ElementName = "Size")]
        public string Size { get; set; }

        [XmlElement(ElementName = "Weight")]
        public string Weight { get; set; }

        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "DataPostyplenia")]
        public string DataPostyplenia { get; set; }

        [XmlElement(ElementName = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Не указана цена")]
        [XmlElement(ElementName = "Price")]
        public string Price { get; set; }

        [XmlElement(ElementName = "Proizvoditel")]
        public Proizvoditel Proizvod = new Proizvoditel();

        public Tovar() { }

        public override string ToString()
        {
            return $"-------------------------INFO------------------------\n" +
                   $" Название: {this.Name};\n Инвентарный номер: {this.InvetarniNumber};\n Вес: {this.Weight};\n" +
                   $" Дата поступления: {this.DataPostyplenia};\n Количество: {this.Quantity};\n"+
                   $" Цена: {this.Price};\n Организация: {this.Organization};\n" +
                   $" Страна: {this.Country};\n Адресс: {this.Adres};\n Телефон: {this.Phone};\n" +
                   $" Id: {this.Id};\n" +
                   $" Размер: {this.Size};\n Тип: {this.Type}";
        }
    }

}
