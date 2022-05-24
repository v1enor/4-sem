using System;
using System.Data;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Lab_6_7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Car> carList = new List<Car>();
        List<Car> tempList = new List<Car>();
        public string tempPath;
        public string filePath = "CarsBase.xml";
        public MainWindow()
        {
            InitializeComponent();

            //chb_searchNumber.Checked += Chb_searchNumber_Checked;
            //chb_searchNumber.Unchecked += Chb_searchNumber_Checked;
            //chb_searchBrand.Checked += Chb_searchBrand_Checked;
            //chb_searchBrand.Unchecked += Chb_searchBrand_Checked;
            //chb_searchConsumption.Checked += Chb_searchConsumption_Checked;
            //chb_searchConsumption.Unchecked += Chb_searchConsumption_Checked;
            //chb_searchTransmission.Checked += Chb_searchTransmission_Checked;
            //chb_searchTransmission.Unchecked += Chb_searchTransmission_Checked;
            //chb_searchPrice.Checked += Chb_searchPrice_Checked;
            //chb_searchPrice.Unchecked += Chb_searchPrice_Checked;

        }

        //private void Chb_searchPrice_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cb = (CheckBox)sender;
        //    if((bool)cb.IsChecked)
        //    {
        //        TB_searchPriceFrom.IsEnabled = true;
        //        TB_searchPriceTo.IsEnabled = true;
        //    }
        //    else
        //    {
        //        TB_searchPriceFrom.IsEnabled = false;
        //        TB_searchPriceTo.IsEnabled = false;
                
        //    }
        //}

        //private void Chb_searchTransmission_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cb = (CheckBox)sender;
        //    if ((bool)cb.IsChecked)
        //    {
        //        CB_searchTrnsm.IsEnabled = true;
        //    }
        //    else
        //    {
        //        CB_searchTrnsm.IsEnabled = false;
        //    }
        //}

        //private void Chb_searchConsumption_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cb = (CheckBox)sender;
        //    if ((bool)cb.IsChecked)
        //    {
        //        TB_searchCnsmpFrom.IsEnabled = true;
        //        TB_searchCnsmpTo.IsEnabled = true;
        //    }
        //    else
        //    {
        //        TB_searchCnsmpFrom.IsEnabled = false;
        //        TB_searchCnsmpTo.IsEnabled = false;

        //    }
        //}

        //private void Chb_searchBrand_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cb = (CheckBox)sender;
        //    if ((bool)cb.IsChecked)
        //    {
        //        TB_searchBrand.IsEnabled = true;
        //    }
        //    else
        //    {
        //        TB_searchBrand.IsEnabled = false;

        //    }
        //}

        //private void Chb_searchNumber_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cb = (CheckBox)sender;
        //    if ((bool)cb.IsChecked)
        //    {
        //        TB_searchNumber.IsEnabled = true;
        //    }
        //    else
        //    {
        //        TB_searchNumber.IsEnabled = false;

        //    }
        //}

        private void btn_carPhoto_Click(object sender, RoutedEventArgs e)
        {
            tempPath = "";
            loadImageName.Text = "";
            OpenFileDialog ofdPicture = new OpenFileDialog();
            ofdPicture.Filter =
                "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif";
            ofdPicture.FilterIndex = 1;

            if (ofdPicture.ShowDialog() == true)
            {
                tempPath = ofdPicture.FileName;
                loadImageName.Text = tempPath.Substring(tempPath.LastIndexOf('.'));
                
            }
               
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car;
                if(String.IsNullOrEmpty(tempPath))
                    car = new CreateCarWithoutPhoto().CreateCar(this);
                else
                    car = new CreateCarWithPhoto().CreateCar(this);

                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var context = new ValidationContext(car);
                if (!Validator.TryValidateObject(car, context, results, true))
                {
                    foreach (var error in results)
                    {
                        throw new InvalidConstraintException(error.ErrorMessage);
                    }
                    return;
                }
                if (File.Exists(filePath))
                {
                    carList = Serialization.CarDeserialization(filePath);
                    carList.Add(car);
                    Serialization.CarSerialization(filePath, carList);
                }
                else
                {
                    carList.Add(car);
                    Serialization.CarSerialization(filePath, carList);
                }

                clear_Text();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                          MessageBoxButton.OK,
                          MessageBoxImage.Question,
                          MessageBoxResult.OK,
                          MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btn_Output_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    FileInfo fi = new FileInfo(filePath);
                    if (fi.Length == 0)
                        throw new Exception("В базе нет автомобилей");

                    carList = Serialization.CarDeserialization(filePath);
                    carGrid.ItemsSource = carList;
                }
                else
                    throw new Exception("Файла базы данных не существует");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                         MessageBoxButton.OK,
                         MessageBoxImage.Question,
                         MessageBoxResult.OK,
                         MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            clear_Text();
        }


        private void clear_Text()
        {
            TB_carNumber.Clear();
            TB_carBrand.Clear();
            CB_carTransmission.Text = "";
            TB_carMileage.Clear();
            TB_carConsumption.Clear();
            TB_carPrice.Clear();
            loadImageName.Text = "";
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            tempList.Clear();
            tempList = Serialization.CarDeserialization(filePath);
            regular_Search();
            searchOutput.ItemsSource = tempList;
            searchText_Clear();
        }

        private void regular_Search()
        {
            List<Car> temp = new List<Car>();
            if (TB_searchNumber.IsEnabled && !String.IsNullOrEmpty(TB_searchNumber.Text))
            {
                temp.Clear();
                foreach (var n in tempList)
                {
                    if (Regex.IsMatch(n.Number, TB_searchNumber.Text.ToString(), RegexOptions.IgnoreCase))
                        temp.Add(n);
                }
                tempList.Clear();
                tempList.AddRange(temp);
            }

            if (TB_searchBrand.IsEnabled && !String.IsNullOrEmpty(TB_searchBrand.Text))
            {
                temp.Clear();
                foreach (var n in tempList)
                {
                    if (Regex.IsMatch(n.Brand, TB_searchBrand.Text.ToString(), RegexOptions.IgnoreCase))
                        temp.Add(n);
                }
                tempList.Clear();
                tempList.AddRange(temp);
            }
            if (CB_searchTrnsm.IsEnabled && !String.IsNullOrEmpty(CB_searchTrnsm.Text))
            {
                temp.Clear();
                foreach (var n in tempList)
                {
                    if (Regex.IsMatch(n.Transmission, CB_searchTrnsm.Text.ToString(), RegexOptions.IgnoreCase))
                        temp.Add(n);
                }
                tempList.Clear();
                tempList.AddRange(temp);
            }
            if (TB_searchCnsmpTo.IsEnabled && !String.IsNullOrEmpty(TB_searchCnsmpTo.Text))
            {
                temp.Clear();
                foreach (var n in tempList)
                {
                    if ((Convert.ToInt32(n.Consumption) >= Convert.ToInt32(TB_searchCnsmpFrom.Text)) &&
                        (Convert.ToInt32(n.Consumption) <= Convert.ToInt32(TB_searchCnsmpTo.Text)))
                        temp.Add(n);
                }
                tempList.Clear();
                tempList.AddRange(temp);
            }
            if (TB_searchPriceTo.IsEnabled && !String.IsNullOrEmpty(TB_searchPriceTo.Text))
            {
                temp.Clear();
                foreach (var n in tempList)
                {
                    if ((Convert.ToInt32(n.Price) >= Convert.ToInt32(TB_searchPriceFrom.Text)) &&
                        (Convert.ToInt32(n.Price) <= Convert.ToInt32(TB_searchPriceTo.Text)))
                        temp.Add(n);
                }
                tempList.Clear();
                tempList.AddRange(temp);
            }
            tempList.Clear();
            tempList.AddRange(temp);
            if (tempList.Count == 0)
            {
                MessageBox.Show("Элементов не найдено", "Info",
                         MessageBoxButton.OK,
                         MessageBoxImage.Information,
                         MessageBoxResult.OK,
                         MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void searchText_Clear()
        {
            TB_searchNumber.Clear();
            TB_searchBrand.Clear();
            CB_searchTrnsm.Text = "";
            TB_searchCnsmpTo.Clear();
            TB_searchCnsmpFrom.Clear();
            TB_searchPriceTo.Clear();
            TB_searchPriceFrom.Clear();

    
        }

        private void btn_SearchClear_Click(object sender, RoutedEventArgs e)
        {
            searchText_Clear();
        }

        private void btn_Sort_Click(object sender, RoutedEventArgs e)
        {
            if((bool)rb_sortBrand.IsChecked)
            {
                var sortList = tempList.OrderBy(t => t.Brand);
                searchOutput.ItemsSource = sortList;
            }

            if ((bool)rb_sortConsumption.IsChecked)
            {
                var sortList = tempList.OrderBy(t => t.Consumption);
                searchOutput.ItemsSource = sortList;
            }

            if ((bool)rb_sortPrice.IsChecked)
            {
                var sortList = tempList.OrderBy(t => t.Price);
                searchOutput.ItemsSource = sortList;
            }

        }

        private void btn_outputAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    FileInfo fi = new FileInfo(filePath);
                    if (fi.Length == 0)
                        throw new Exception("В базе нет автомобилей");

                    carList = Serialization.CarDeserialization(filePath);
                    editBox.ItemsSource = carList;
                }
                else
                    throw new Exception("Файла базы данных не существует");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                         MessageBoxButton.OK,
                         MessageBoxImage.Question,
                         MessageBoxResult.OK,
                         MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btn_changePhoto_Click(object sender, RoutedEventArgs e)
        {
            tempPath = "";
           ChangedImage.Text = "";
            OpenFileDialog ofdPicture = new OpenFileDialog();
            ofdPicture.Filter =
                "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif";
            ofdPicture.FilterIndex = 1;

            if (ofdPicture.ShowDialog() == true)
            {
                tempPath = ofdPicture.FileName;
                ChangedImage.Text = tempPath.Substring(tempPath.LastIndexOf('.'));

            }
        }

        private void btn_searchToChange_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(TB_searchNumberToChange.Text))
            {
                carList = Serialization.CarDeserialization(filePath);
                var changeList = carList.Where(n => Regex.IsMatch(n.Number, TB_searchNumberToChange.Text.ToString()));
                editBox.ItemsSource = changeList;
                TB_searchNumberToChange.Clear();
            }
            else
            {
                MessageBox.Show("Введите данные", "Info",
                         MessageBoxButton.OK,
                         MessageBoxImage.Information,
                         MessageBoxResult.OK,
                         MessageBoxOptions.DefaultDesktopOnly);
            }

               
        }

        private void editBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (editBox.SelectedItem != null)
            {
                Car c = (Car)editBox.SelectedItem;
                TB_changeBrand.Text = c.Brand;
                TB_changeNumber.Text = c.Number;
                TB_changeConsumption.Text = c.Consumption.ToString();
                TB_changeMileage.Text = c.Mileage.ToString();
                TB_changePrice.Text = c.Price.ToString();
                CB_changeTransmission.Text = c.Transmission;
                ChangedImage.Text = c.PhotoPath.Substring(c.PhotoPath.LastIndexOf('.'));
                tempPath = c.PhotoPath;
            }    
            
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            TB_changeBrand.IsEnabled = true;
            TB_changeNumber.IsEnabled = true;
            TB_changeConsumption.IsEnabled = true;
            TB_changeMileage.IsEnabled = true;
            TB_changePrice.IsEnabled = true;
            CB_changeTransmission.IsEnabled = true;
            btn_changePhoto.IsEnabled = true;

          
        }

        private void btn_saveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = new ChangedCar().CreateCar(this);
                carList = Serialization.CarDeserialization(filePath);
                carList = carList.Where(n => n.Number != TB_changeNumber.Text).ToList();
                carList.Add(car);
                Serialization.CarSerialization(filePath, carList);
                editBox.ItemsSource = carList;
            }
           catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                         MessageBoxButton.OK,
                         MessageBoxImage.Error,
                         MessageBoxResult.OK,
                         MessageBoxOptions.DefaultDesktopOnly);
            }
            
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            carList = Serialization.CarDeserialization(filePath);
            carList = carList.Where(n => n.Number != TB_changeNumber.Text).ToList();
            Serialization.CarSerialization(filePath, carList);
            TB_changeBrand.Clear();
            TB_changeNumber.Clear();
            TB_changeConsumption.Clear();
            TB_changeMileage.Clear();
            TB_changePrice.Clear();
            CB_changeTransmission.Text = "";
            ChangedImage.Text = "";
            editBox.ItemsSource = carList;
        }

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл уже удален");
                return;
            }
            else
            {
                File.Delete(filePath);
                carList.Clear();
                MessageBox.Show("Файл удален");
            }
        }

        private void Exit_Executed(object sender, RoutedEventArgs e) //определение обработчика 
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("log.txt", true))
            {
                writer.WriteLine("Выход из приложения: " + DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }
            this.Close();
        }

        //языки
        private void Russian_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.Clear();
            this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("pack://application:,,,/Dictionary_ru.xaml") });
         
        }

        private void English_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.Clear();
            this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("pack://application:,,,/Dictionary_en.xaml") });
          
        }

        private void DarkTheme_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.Clear();
            this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("pack://application:,,,/DarkTheme.xaml") });

        }

        private void LightTheme_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.Clear();
            this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("pack://application:,,,/LightTheme.xaml") });

        }


        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            TB_carNumber.Undo();
            TB_carBrand.Undo();
            CB_carTransmission.Text = "";
            TB_carMileage.Undo();
            TB_carConsumption.Undo();
            TB_carPrice.Undo();
            loadImageName.Text = "";

        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            TB_carNumber.Redo();
            TB_carBrand.Redo();
            CB_carTransmission.Text = "";
            TB_carMileage.Redo();
            TB_carConsumption.Redo();
            TB_carPrice.Redo();
            loadImageName.Text = "";

        }

    }
}
