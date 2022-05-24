using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_7
{
    static class Serialization
    {
      
        public static void CarSerialization(string filePath, List<Car> cars)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Car>));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                xs.Serialize(fs, cars);
            }
            
        }

        public static List<Car> CarDeserialization(string filePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Car>));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (List<Car>)xs.Deserialize(fs);
            }
        }
    }
}
