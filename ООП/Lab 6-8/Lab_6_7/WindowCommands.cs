using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab_6_7
{
    public class WindowCommands
    {
        static WindowCommands() 
        {
            Exit = new RoutedCommand("Exit", typeof(MainWindow));
        }
        public static RoutedCommand Exit { get; set; }
    }
}





//команда Exit и представляет собой объект RoutedCommand. В конструктор этого объекта в данном случае
//передается название команды и элемент-владелец команды