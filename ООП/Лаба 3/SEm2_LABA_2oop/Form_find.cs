using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace laba_2
{
    public partial class Form_find : Form
    {
        public string Result { get; set; }
        public Form_find()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void find_by_type_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Find_button_Click(object sender, EventArgs e)
        {
            Search_result_richTextBox.Text = "";
            Result = "";

            FileStream fs1 = File.Open("C:/Users/ilya/Desktop/учеба/ООП/Лаба 3/Записи/SearchResult.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fs1.SetLength(0);
            fs1.Close();
            int i = 0;

            XmlSerializer formatter = new XmlSerializer(typeof(Orders));
            Regex regexSearh = null;

            if (find_by_name_box.Text != null && find_by_name_box.Text != "" )
            {
                regexSearh = new Regex(find_by_name_box.Text.ToString());
                i = 1;
            }
//            Непродовольственные
//Продовольственные

            else 
            {
                if (find_by_type_comboBox.Text == "Непродовольственные")
                {
                    i = 2;
                    regexSearh = new Regex(@"\^" + find_by_type_comboBox.Text);

                }
                else if (find_by_type_comboBox.Text == "Продовольственные")
                {
                    i=3;
                    regexSearh = new Regex(find_by_type_comboBox.Text);
                }

                else if (Price_from_box.Text != null && Price_from_box.Text != "" || Price_to_box.Text != null && Price_to_box.Text != "")
                {
                    i = 4;
                }




            }

            



            Orders OrdersSearch = new Orders();
            Orders searchResult = new Orders();


            IEnumerable<Tovar> ordered = null;

            using (FileStream stream = new FileStream("C:/Users/ilya/Desktop/учеба/ООП/Лаба 3/Записи/test.xml", FileMode.Open))
            {
                OrdersSearch = formatter.Deserialize(stream) as Orders;

                foreach (Tovar res in OrdersSearch.ordersList)
                {
                    Result = "";
                    Result = Result + res.ToString();

                    if (Result != null)
                    {
                        if (i == 1 && regexSearh.IsMatch(Result))
                        {
                            searchResult.SearchResult.Add(res);
                        }

                        else if (i == 2 && regexSearh.IsMatch(res.Type))
                        {
                            searchResult.SearchResult.Add(res);
                        }

                        else if (i == 3 && regexSearh.IsMatch(res.Type))
                        {
                            searchResult.SearchResult.Add(res);
                        }

                        else if (i == 4)
                        {
                            int from = 0;
                            int to = 1000000000;


                            if (Price_from_box.Text != null && Price_from_box.Text != "")
                            {
                                from = int.Parse(Price_from_box.Text);
                            }

                            if (Price_to_box != null && Price_to_box.Text != "")
                            {
                                to = int.Parse(Price_to_box.Text);
                            }



                            ordered = OrdersSearch.ordersList.Where(x => int.Parse(x.Price) >= from).Where(x => int.Parse(x.Price) <= to);

                            foreach (Tovar item in ordered)
                                searchResult.SearchResult.Add(item);
                               


                        }



                    }






                }
                Find_count_label.Text = "Количество объектов " + searchResult.SearchResult.Count + "";
            }


            using (FileStream fs = new FileStream("C:/Users/ilya/Desktop/учеба/ООП/Лаба 3/Записи/SearchResult.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, searchResult);
            }


            using (FileStream stream = new FileStream("C:/Users/ilya/Desktop/учеба/ООП/Лаба 3/Записи/SearchResult.xml", FileMode.Open))
            {

                searchResult = formatter.Deserialize(stream) as Orders;

                if (searchResult.SearchResult != null)
                {
                    foreach (Tovar comp3 in searchResult.SearchResult)
                    {
                        Search_result_richTextBox.Text = Search_result_richTextBox.Text + comp3.ToString() + "\n";
                    }
                }
                else
                {
                    Search_result_richTextBox.Text = "Няма";
                }
            }

            
            if (By_date_radio.Checked)
            {
                Search_result_richTextBox.Text = "";
                ordered = searchResult.SearchResult.OrderBy(p => DateTime.Parse(p.DataPostyplenia)).OrderBy(x => x.Name.ToString());
                foreach (Tovar item in ordered)
                    Search_result_richTextBox.Text = Search_result_richTextBox.Text + item.ToString() + "\n";
            }

            else if (By_country_radio.Checked)
            {
                Search_result_richTextBox.Text = "";
                ordered = searchResult.SearchResult.OrderBy(p => p.Country.ToString()).OrderBy(x => x.Name.ToString());
                foreach (Tovar item in ordered)
                    Search_result_richTextBox.Text = Search_result_richTextBox.Text + item.ToString() + "\n";
            }

            





        }

        private void find_by_name_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void By_date_radio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Price_to_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void Save_search_but_Click(object sender, EventArgs e)
        {
            
            //XmlSerializer ser = new XmlSerializer(typeof(Orders));
            //using (FileStream fs = new FileStream("C:/Users/ilya/Desktop/учеба/ООП/Лаба 3/Записи/search_results.xml",FileMode.Create))
            //{
            //    ser.Serialize(fs, OrdersSearch.ordersList);

            //}


        }

        private void Price_from_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
