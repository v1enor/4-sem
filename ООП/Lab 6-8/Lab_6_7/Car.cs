using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_7
{
    /// <summary>
    /// Класс объекта машины
    /// </summary>
   [Serializable]
    public class Car
    {
        private string number;
        private string brand;
        private string transmission;
        private double mileage;
        private double consumption;
        private double price;
        private string photoPath;

        [Required(ErrorMessage = "Введите номер автомобиля")]
        [RegularExpression(@"\d{1,5}",ErrorMessage ="Неверный формат номера")]
        public string Number { get { return this.number; } set { this.number = value; } }

        [Required(ErrorMessage = "Введите марку автомобиля")]
        public string Brand { get { return this.brand; } set { this.brand = value; } }

        [Required(ErrorMessage = "Выберите тип КПП автомобиля")]
        public string Transmission { get { return this.transmission; } set { this.transmission = value; } }

        [Required(ErrorMessage = "Введите пробег автомобиля")]
        [RegularExpression(@"^([1-9][0-9]{1,5})$", ErrorMessage = "Неверный формат пробега")]
        public double Mileage { get { return this.mileage; } set { this.mileage = value; } }

        [Required(ErrorMessage = "Введите расход топлива автомобиля")]
        [RegularExpression(@"^(\d{1,2}(\,\d{1,2})?)$", ErrorMessage = "Неверный формат расхода топлива")]
        public double Consumption { get { return this.consumption; } set { this.consumption = value; } }

        [Required(ErrorMessage = "Введите цену автомобиля")]
        [RegularExpression(@"^(\d{1,4}(\,\d{1,2})?)$", ErrorMessage = "Неверный формат цены")]
        public double Price { get { return this.price; } set { this.price = value; } }
        public string PhotoPath { get { return this.photoPath; } set { this.photoPath= value; } }

        

    }
}
