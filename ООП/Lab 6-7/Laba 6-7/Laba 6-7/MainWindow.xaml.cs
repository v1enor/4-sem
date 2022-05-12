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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laba_6_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        private object djson;

        public MainWindow()
        {

            string fileName = "profucts.json";
            string jsonString = File.ReadAllText(fileName);
            List<Product> djson = JsonSerializer.Deserialize<List<Product>>(jsonString);
            InitializeComponent();
            CommandBinding commandBinding = new CommandBinding();
            // устанавливаем команду
            commandBinding.Command = ApplicationCommands.Open;
            // устанавливаем метод, который будет выполняться при вызове команды
            commandBinding.Executed += edit_window;
            // добавляем привязку к коллекции привязок элемента Button
            edit.CommandBindings.Add(commandBinding);


            

            Products_grid.ItemsSource = djson;
            this.DataContext = djson;

        }

        private void edit_window(object sender, ExecutedRoutedEventArgs e)
        {
            int pr = Products_grid.SelectedIndex;
            var pag = new Edit(pr);
            pag.Show();

        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var Page2 = new Form(djson); //create your new form.
            Page2.Show();
        }

        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            Products_grid.ItemsSource = null;
            string fileName = "profucts.json";
            string jsonString = File.ReadAllText(fileName);
            List<Product> djson = JsonSerializer.Deserialize<List<Product>>(jsonString);
            Products_grid.ItemsSource = djson;
        }

    
    }

}