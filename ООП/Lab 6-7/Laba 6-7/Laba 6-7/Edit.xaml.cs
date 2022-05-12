using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {

        private List<Product> djson;
        public int index;
        public Edit(int pr)
        {

            InitializeComponent();

            CommandBinding commandBinding = new CommandBinding();
            // устанавливаем команду
            commandBinding.Command = ApplicationCommands.Save;
            // устанавливаем метод, который будет выполняться при вызове команды
            commandBinding.Executed += ButtonBase_OnClick23;
            Edit_btn.CommandBindings.Add(commandBinding);


            string fileName = "profucts.json";
            string jsonString = File.ReadAllText(fileName);
            djson = JsonSerializer.Deserialize<List<Product>>(jsonString);
            index = pr;
            id.Text = djson[pr].Id.ToString();
            name.Text = djson[pr].name;
            full_name.Text = djson[pr].full_name;
            rating.Text = djson[pr].rating.ToString();
            price.Text = djson[pr].price.ToString();
            count.Text = djson[pr].count.ToString();
            color.Text = djson[pr].color;
            description.Text = djson[pr].description;

        }

        private void ButtonBase_OnClick23(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {

                this.djson[index].Id = int.Parse(id.Text);
                this.djson[index].name = name.Text;
                this.djson[index].full_name = full_name.Text;
                this.djson[index].color = color.Text;
                this.djson[index].rating = int.Parse(rating.Text);
                this.djson[index].price = int.Parse(price.Text);
                this.djson[index].count = int.Parse(count.Text);
                this.djson[index].description = description.Text;
                



                string fileName = "profucts.json";
                

                var json = JsonSerializer.Serialize(this.djson);
                File.WriteAllText(fileName, json);
            }

            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
        }
    }
}
