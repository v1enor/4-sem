using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_7
{
    interface ICarAbstractFactory
    {
        Car CreateCar(MainWindow window);
    }
}
