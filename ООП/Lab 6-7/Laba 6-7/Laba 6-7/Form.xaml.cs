using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Laba_6_7
{
    /// <summary>
    /// Логика взаимодействия для Form.xaml
    /// </summary>
    public partial class Form : Window
    {

        public interface ICommandSource
        {
            ICommand Command { get; }
            object CommandParameter { get; }
            IInputElement CommandTarget { get; }
        }


        public Form(object djson)
        {
            InitializeComponent();

            CommandBinding commandBinding = new CommandBinding();
            // устанавливаем команду
            commandBinding.Command = ApplicationCommands.Save;
            // устанавливаем метод, который будет выполняться при вызове команды
            commandBinding.Executed += ButtonBase_OnClick;
            // добавляем привязку к коллекции привязок элемента Button
            savebtn.CommandBindings.Add(commandBinding);

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Product add_pr = new Product()
                {
                    Id = int.Parse(id.Text), color = color.Text, count = int.Parse(count.Text),
                    description = description.Text, full_name = full_name.Text, name = name.Text,
                    price = decimal.Parse(price.Text), rating = float.Parse(rating.Text)
                };
                string fileName = "profucts.json";
                string jsonString = File.ReadAllText(fileName);
                List<Product> djson = JsonSerializer.Deserialize<List<Product>>(jsonString);
                djson.Add(add_pr);

                var json = JsonSerializer.Serialize(djson);
                File.WriteAllText(fileName, json);
            }

            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
            

        }
    }
}
