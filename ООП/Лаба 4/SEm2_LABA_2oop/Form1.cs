using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace laba_2
{
    public partial class Form1 : Form
    {
        private Tovar clonable_tovar;

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
            var new_item = new Tovar()
            {
                
                Name = Name_textBox.Text,
                InvetarniNumber = InvetarniNumber_textBox.Text,
                Weight = Weight_textBox.Text,
                DataPostyplenia = DataPostyplenia_picker.Text,
                Quantity = Quantity_trackBar.Value,
                Price = Price_textBox.Text,
                Organization = Org_textBox.Text,
                Country = Country_textBox.Text,
                Adres = Adres_textBox.Text,
                Phone = Phone_textBox.Text, 
            };

            if (checkBox1.Checked) { new_item.Type += "Непродовольственные"; }
            if (checkBox2.Checked) { new_item.Type += " Продовольственные"; }

            if (radioBig.Checked) { new_item.Size += "Большой"; }
            if (radioSred.Checked) { new_item.Size += "Средний"; }
            if (radioSmall.Checked) { new_item.Size += "Маленький"; }






            XmlSerializeWrapper.Serialize(new_item, "C:/Users/ilya/Desktop/tovari.xml");

            if (String.IsNullOrEmpty(new_item.Name) == true || String.IsNullOrEmpty(new_item.InvetarniNumber) == true || String.IsNullOrEmpty(new_item.Organization) == true || String.IsNullOrEmpty(new_item.Price) == true || String.IsNullOrEmpty(new_item.Quantity.ToString()) == true || String.IsNullOrEmpty(new_item.Country) == true || String.IsNullOrEmpty(new_item.Weight) == true)
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
            
            var deserializeUsers = XmlSerializeWrapper.Deserialize<Tovar>("C:/Users/ilya/Desktop/tovari.xml");
            Resume_richbox.Text = $" Название: {deserializeUsers.Name};" + 
            $"\n Инвентарный номер: {deserializeUsers.InvetarniNumber};\n Вес: {deserializeUsers.Weight};\n" +
            $" Дата поступления: {deserializeUsers.DataPostyplenia};\n Количество: {deserializeUsers.Quantity};\n" +
            $" Цена: {deserializeUsers.Price};\n Организация: {deserializeUsers.Organization};\n" +
            $" Страна: {deserializeUsers.Country};\n Адресс: {deserializeUsers.Adres};\n Телефон: {deserializeUsers.Phone};\n" +
            $" Id: {deserializeUsers.Id};\n" +
            $" Размер: {deserializeUsers.Size};\n Тип: {deserializeUsers.Type}";

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

        private void button1_Click(object sender, EventArgs e)
        {


            if (Factory_1_radio.Checked)
            {
                ClientMethod(new Factory_1());
                
            }

            else if(Factory_2_radio.Checked)
            {
                ClientMethod(new Factory_2());
            }


            void ClientMethod(IAbstractFactory factory)
            {
                if (Object_1.Checked)
                {
                    var product = factory.Create_1();
                    Resume_richbox.Text = product.Info_product();
                }

                else if (Object_2.Checked)
                {
                    var product2 = factory.Create_2();
                    Resume_richbox.Text = product2.Info_product();
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Singletone_bt_Click(object sender, EventArgs e)
        {
            Singletone form1_info = Singletone.getInstance(this.BackColor, this.Font, this.Size);
            MessageBox.Show(form1_info.ToString(), "Информация об форме");
        }

        private void prototype_Click(object sender, EventArgs e)
        {

            var deserializeUsers = XmlSerializeWrapper.Deserialize<Tovar>("C:/Users/ilya/Desktop/tovari.xml");
            clonable_tovar = deserializeUsers.Clone();
        }

        private void Object_2_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Resume_richbox.Text = $" Название: {clonable_tovar.Name};" +
            $"\n Инвентарный номер: {clonable_tovar.InvetarniNumber};\n Вес: {clonable_tovar.Weight};\n" +
            $" Дата поступления: {clonable_tovar.DataPostyplenia};\n Количество: {clonable_tovar.Quantity};\n" +
            $" Цена: {clonable_tovar.Price};\n Организация: {clonable_tovar.proizvod.Organization};\n" +
            $" Страна: {clonable_tovar.proizvod.Country};\n Адресс: {clonable_tovar.proizvod.Adres};\n Телефон: {clonable_tovar.proizvod.Phone};\n" +
            $" Id: {clonable_tovar.Id};\n" +
            $" Размер: {clonable_tovar.Size};\n Тип: {clonable_tovar.Type}";
        }

        private void bilder_btn_Click(object sender, EventArgs e)
        {
            var direcrtor = new Director();
            var bilder = new Bilder();
            direcrtor.Builder = bilder;
            direcrtor.BuildProduct();
        }

        private void Factory_1_radio_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
