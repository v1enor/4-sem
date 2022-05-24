using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lab_6_7
{
    /// <summary>
    /// Интерфейс для паттерна Builder
    /// </summary>
    interface ICarBuilder
    {
        void Reset();
        void SetCarNumber(string number);
        void SetCarBrand(string brand);
        void SetCarTransmission(string transm);
        void SetCarMileage(double kilometers);
        void SetCarConsumption(double liters);
        void SetCarPrice(double price);
        void SetCarPhotoPath(string path);
        Car GetResult();
    }
}
