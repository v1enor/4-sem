using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_7
{
    class CreateCarWithoutPhoto : ICarAbstractFactory
    {
        public Car CreateCar(MainWindow win)
        {
            CarBuilder car = new CarBuilder();
            car.Reset();
            car.SetCarNumber(win.TB_carNumber.Text);
            car.SetCarBrand(win.TB_carBrand.Text);
            car.SetCarTransmission(win.CB_carTransmission.Text);
            car.SetCarMileage(Convert.ToDouble(win.TB_carMileage.Text));
            car.SetCarConsumption(Convert.ToDouble(win.TB_carConsumption.Text));
            car.SetCarPrice(Convert.ToDouble(win.TB_carPrice.Text));
            car.SetCarPhotoPath("Resource/washer.png");
            return car.GetResult();
        }
    }
}
