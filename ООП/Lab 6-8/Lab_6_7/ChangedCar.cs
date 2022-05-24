using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_7
{
    class ChangedCar:ICarAbstractFactory
    {
        public Car CreateCar(MainWindow win)
        {
            CarBuilder car = new CarBuilder();
            car.Reset();
            car.SetCarNumber(win.TB_changeNumber.Text);
            car.SetCarBrand(win.TB_changeBrand.Text);
            car.SetCarTransmission(win.CB_changeTransmission.Text);
            car.SetCarMileage(Convert.ToDouble(win.TB_changeMileage.Text));
            car.SetCarConsumption(Convert.ToDouble(win.TB_changeConsumption.Text));
            car.SetCarPrice(Convert.ToDouble(win.TB_changePrice.Text));
            if(!String.IsNullOrEmpty(win.tempPath))
            {
                car.SetCarPhotoPath(win.tempPath);
            }
           else
                car.SetCarPhotoPath("Resource/washer.png");
            return car.GetResult();
        }
    }
}
