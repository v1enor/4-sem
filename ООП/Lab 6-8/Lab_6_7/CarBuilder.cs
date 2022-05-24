using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_7
{
    /// <summary>
    /// Класс паттерна Builder
    /// </summary>
    class CarBuilder : ICarBuilder
    {
        Car result = new Car();

        public void Reset()
        {
            result = new Car();
        }
        public void SetCarNumber(string number)
        {
            result.Number = number;
        }
        public void SetCarBrand(string brand)
        {
            result.Brand = brand;
        }
        public void SetCarTransmission(string transm)
        {
            result.Transmission = transm;
        }
        public void SetCarMileage(double kilometers)
        {
            result.Mileage = kilometers;
        }
        public void SetCarConsumption(double liters)
        {
            result.Consumption = liters;
        }
        public void SetCarPrice(double price)
        {
            result.Price = price;
        }
        public void SetCarPhotoPath(string path)
        {
            result.PhotoPath = path;
        }
        public Car GetResult()
        {
            return result;
        }
    }
}
