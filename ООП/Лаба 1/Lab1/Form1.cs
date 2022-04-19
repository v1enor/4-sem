using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lab1
{
    internal partial class Form1 : Form
    {
        Program.Calculator cal = new Program.Calculator();
        bool _doubleclick = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void button4_DoubleClick(object sender, EventArgs e)
        {
            
            if (_doubleclick == true)
            {
                _doubleclick = false;
            }
            else if(_doubleclick == false)
            {
                textBox1.Text = "";
                cal.CTG();
                foreach (var i in Program.Calculator.memory)
                {
                    textBox1.Text += i;
                }
                _doubleclick = true;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            cal.COS();
            foreach (var i in Program.Calculator.memory)
            {
                textBox1.Text += i;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cal.Clear();
            textBox1.Text = "";
        }

        private void panel1_Click(object sender, EventArgs e)
        {
          
            Button N = (Button)sender;
            cal.mem_input(N, textBox1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cal.DEL();
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            cal.SIN();
            foreach(var i in Program.Calculator.memory)
            {
                textBox1.Text +=i;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            cal.Koren();
            foreach (var i in Program.Calculator.memory)
            {
                textBox1.Text += i;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            cal.Koren_kub();
            foreach (var i in Program.Calculator.memory)
            {
                textBox1.Text += i;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            cal.TG();
            foreach (var i in Program.Calculator.memory)
            {
                textBox1.Text += i;
            }
        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            //cal.stinginput(textBox1.Text, textBox1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            cal.Save();
            MessageBox.Show("Сохранил");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            foreach (var i in Program.Calculator.save)
            {
                textBox1.Text += i;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Button N = (Button)sender;
            cal.mem_input(N, textBox1);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
