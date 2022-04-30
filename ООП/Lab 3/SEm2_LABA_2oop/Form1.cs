using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace laba_2
{
    public partial class Form1 : Form
    {
        public Orders ords = new Orders();

        public Form1()
        {
            InitializeComponent();

            //Timer timer = new Timer();
            //timer.Interval = 5000;
            //timer.Enabled = true;
            //timer.Tick += new EventHandler(timer_Tick);

        }

      

        private void TXTB_ONLY_CHAR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TXTB_ONLY_NUMBER_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

  




        private void buttonSaveInFile_Click(object sender, EventArgs e)
        {

            //try
            //{

 
                Tovar tv = new Tovar()
                {
                    Name = Name_textBox.Text,
                    InvetarniNumber = int.Parse(InvetarniNumber_textBox.Text),
                    Weight = Weight_textBox.Text,
                    DataPostyplenia = DataPostyplenia_picker.Text,
                    Quantity = Quantity_trackBar.Value,
                    Price = Price_textBox.Text,
                    Organization = Org_textBox.Text,
                    Country = Country_textBox.Text,
                    Adres = Adres_textBox.Text,
                    Phone = Phone_textBox.Text,
                };


                if (checkBox1.Checked) { tv.Type += "Непродовольственные"; }
                if (checkBox2.Checked) { tv.Type += "Продовольственные"; }

                if (radioBig.Checked)  { tv.Size += "Большой"; }
                if (radioSred.Checked) { tv.Size += "Средний"; }
                if (radioSmall.Checked){ tv.Size += "Маленький"; }

            
                var results = new List<ValidationResult>();
                var context = new ValidationContext(tv);
                

                if (!Validator.TryValidateObject(tv, context, results, true))
                {
                    foreach (var error in results)
                    {
                        MessageBox.Show(error.ErrorMessage);
                    }
                }


                else
                {
                    ords.ordersList.Add(tv);

                }
            //}

            //catch (System.FormatException)
            //{

            //    MessageBox.Show("Введите все данные");
            //}

            ivent("Добавили в файл");
        }


        

        private void trackBarColichestvo_Scroll(object sender, EventArgs e)
        {
            Count_label.Text = "Количество "+ Quantity_trackBar.Value + "";
        }


     

        private void Button_clear(object sender, EventArgs e)
        {
            Adres_textBox.Clear();
            Price_textBox.Clear();
            Name_textBox.Clear();
            InvetarniNumber_textBox.Clear();
            Org_textBox.Clear();
            Country_textBox.Clear();
            Weight_textBox.Clear();
            Phone_textBox.Clear();
            Country_label.Text = "Количество";
            Quantity_trackBar.Value = 0;
            ivent("Очистили поля");
        }

        private void DataPostyplenia_picker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Type_label_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Country_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Weight_label_Click(object sender, EventArgs e)
        {

        }

        private void Invent_label_Click(object sender, EventArgs e)
        {

        }

        private void Size_label_Click(object sender, EventArgs e)
        {

        }

        private void Clear_rch_Click(object sender, EventArgs e)
        {
            Resume_richbox.Clear();
            ivent("Очистили вывод");
        }

        private void Phone_textBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Name_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer_label.Text = "Время:" + DateTime.Now.ToLongTimeString() + DateTime.Now.ToLongDateString();
            //date_label.Text =  DateTime.Now.ToLongDateString();

        }

        private void Price_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Weight_textBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Price_textBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            XmlSerializer ser = new XmlSerializer(typeof(Orders));
            using (FileStream fs = new FileStream(@"C:/Users/ilya/Desktop/учеба/ООП/Лаба 3/Записи/test.xml", FileMode.Create))
            {
                ser.Serialize(fs, ords);
            }
            ivent("Сохрнанили в файл");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Resume_richbox.Text = "";
            using (FileStream fs = new FileStream("C:/Users/ilya/Desktop/учеба/ООП/Лаба 3/Записи/test.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Orders));
                ords = formatter.Deserialize(fs) as Orders;

                if (ords.ordersList != null)
                {
                    foreach (Tovar order in ords.ordersList)
                    {
                        Resume_richbox.Text = Resume_richbox.Text + order.ToString() + "\n";
                    }
                }
            }

            label_stat.Text = "Количество объектов " + ords.ordersList.Count + "";
            ivent("Прочитал из файла");


        }

        private void Resume_richbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_find_Click(object sender, EventArgs e)
        {
            Form_find form_find = new Form_find();
            form_find.Show();
            ivent("Что-то искали");
        }

        private void Price_textBox_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {

        }


        //-----------------------------------------
        void timer_Tick(object sender, EventArgs e)
        {
            timer_label.Text = DateTime.Now.ToShortDateString() + ", " + DateTime.Now.ToLongTimeString();
        }
        private void About_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Парибок Илья \n Версия 0.0.3");

        }

        private void InvetarniNumber_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void сортировкаПоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnumerable<Tovar> ordered = null;
            Resume_richbox.Text = "";
            ordered = ords.ordersList.OrderBy(p => DateTime.Parse(p.DataPostyplenia)).OrderBy(x => x.Name);
            foreach (Tovar item in ordered)
                Resume_richbox.Text = Resume_richbox.Text + item.ToString() + "\n";
            ivent("Сортировали по дате");
        }

        private void сортировкаПоСтранеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnumerable<Tovar> ordered = null;
            Resume_richbox.Text = "";
            ordered = ords.ordersList.OrderBy(p => p.Country.ToString());
            foreach (Tovar item in ordered)
                Resume_richbox.Text = Resume_richbox.Text + item.ToString() + "\n";
            ivent("Сортировали по Стране");

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_find form_find = new Form_find();
            form_find.Show();
            ivent("Искали что-то");
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resume_richbox.Clear();
            ivent("Очистили данные");
        }

        private void Count_label_Click(object sender, EventArgs e)
        {

        }

        private void ivent(string label)
        {
            ivent_label.Text = "Последнее действие: " + label ;
        }

        private void label_stat_Click(object sender, EventArgs e)
        {

        }

        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ivent_label_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_label.Text = "Время:" + DateTime.Now.ToLongTimeString() +" " + DateTime.Now.ToLongDateString();
            timer1.Start();
        }

        private void toolStripTextBox_timer_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            //toolStripStatusLabel1.Text = DateTime.Now.ToLongTimeString();
            //timer1.Start();
        }
    }
}
