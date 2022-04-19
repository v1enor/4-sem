using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace laba_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

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
            var new_item = new List<Tovar>()
            {
                new Tovar(){
                Name = Name_textBox.Text,
                InvetarniNumber = InvetarniNumber_textBox.Text,
                Weight = Weight_textBox.Text,
                DataPostyplenia = DataPostyplenia_picker.Text,
                Quantity = Quantity_trackBar.Value,
                Price = Price_textBox.Text,
                Organization = Org_textBox.Text,
                Country = Country_textBox.Text,
                Adres = Adres_textBox.Text,
                Phone = Phone_textBox.Text, }
            };

            if (checkBox1.Checked) { new_item[0].Type += "Непродовольственные"; }
            if (checkBox2.Checked) { new_item[0].Type += " Продовольственные"; }

            if (radioBig.Checked)  { new_item[0].Size += "Большой"; }
            if (radioSred.Checked) { new_item[0].Size += "Средний"; }
            if (radioSmall.Checked){ new_item[0].Size += "Маленький"; }
            XmlSerializeWrapper.Serialize(new_item, "tovari.xml");

            if (String.IsNullOrEmpty(new_item[0].Name) == true || String.IsNullOrEmpty(new_item[0].InvetarniNumber) == true || String.IsNullOrEmpty(new_item[0].Organization) == true || String.IsNullOrEmpty(new_item[0].Price) == true || String.IsNullOrEmpty(new_item[0].Quantity.ToString()) == true || String.IsNullOrEmpty(new_item[0].Country) == true || String.IsNullOrEmpty(new_item[0].Weight) == true)
            {
                MessageBox.Show("Заполните все поля!");
            }
            

            
        }

        private void trackBarColichestvo_Scroll(object sender, EventArgs e)
        {
            Count_label.Text = "Количество "+ Quantity_trackBar.Value + "";
        }


        private void buttonIzFile_Click(object sender, EventArgs e)
        {
            
            var deserializeUsers = XmlSerializeWrapper.Deserialize<List<Tovar>>("tovari.xml");
            Resume_richbox.Text = $" Название: {deserializeUsers[0].Name};\n Инвентарный номер: {deserializeUsers[0].InvetarniNumber};\n Вес: {deserializeUsers[0].Weight};\n" +
                $" Дата поступления: {deserializeUsers[0].DataPostyplenia};\n Количество: {deserializeUsers[0].Quantity};\n"+
                $" Цена: {deserializeUsers[0].Price};\n Организация: {deserializeUsers[0].Organization};\n" +
                $" Страна: {deserializeUsers[0].Country};\n Адресс: {deserializeUsers[0].Adres};\n Телефон: {deserializeUsers[0].Phone};\n" +
                $" Id: {deserializeUsers[0].Id};\n" +
                $" Размер: {deserializeUsers[0].Size};\n Тип: {deserializeUsers[0].Type}";

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
        }

        private void Phone_textBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Name_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
    }
}
