using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

namespace Lab1
{

    static class Program
    {
        public interface ICALCULATOR
        {
            public void SIN();
            public void COS();
            public void TG();
            public void CTG();
            public void DEL();
            public void Clear();
            public void Koren();
           // public void stinginput(string N, TextBox textBox1);
            public void Koren_kub();
            public void Save();


        }
        internal class Calculator : ICALCULATOR
        {
            public static List<string> memory = new List<string>();
            public static List<string> save = new List<string>();
            public double number;

           


            public void mem_input(Button N,TextBox textBox1)
            {
                try
                {

                    Program.Calculator.memory.Add(N.Text);
                    if (Program.Calculator.memory[0] == ",")
                    {
                        throw new Exception("Нельзя вводить первым символом .");
                    }
                }
                catch
                {
                    //memory.Clear();
                    //textBox1.Clear();

                    Debug.Assert(Program.Calculator.memory[0] != ",", "Нельзя вводить первым символом .");
                }
                textBox1.Text = textBox1.Text + N.Text;
            }


            
            public void mem_output()
            {
                string f="";
                
                foreach(var i in memory)
                {

                    //if (i.All(char.IsDigit))
                    //{
                        f += i;
                    //}
                }
                try
                {
                 number = Convert.ToDouble(f);
                }
                
                catch(System.FormatException)
                {

                    memory.Clear();
                    MessageBox.Show("Пожалуйста, введите корректные данные.");
                }
                
                
    }
            public void SIN()
            {
                mem_output();
                number=Math.Sin((number/180)*Math.PI);
                memory.Clear();
                string str = Convert.ToString(number);
                foreach (var i in str)
                {
                    memory.Add(Convert.ToString(i));
                }
            }
            public void COS()
            {
                mem_output();
                number = Math.Cos((number/180)* Math.PI);
                memory.Clear();
                string str = Convert.ToString(number);
                foreach (var i in str)
                {
                    memory.Add(Convert.ToString(i));
                }
            }
            public void TG()
            {
                mem_output();
                number = Math.Tan((number/180)* Math.PI);
                memory.Clear();
                string str = Convert.ToString(number);
                foreach (var i in str)
                {
                    memory.Add(Convert.ToString(i));
                }
            }
            public void CTG()
            {
                mem_output();
                number = 1.0 / Math.Tan((number / 180) * Math.PI);
                memory.Clear();
                string str = Convert.ToString(number);
                foreach (var i in str)
                {
                    memory.Add(Convert.ToString(i));
                }
            }
            public void DEL()
            {
                memory.RemoveAt(memory.Count-1);
            }
            public void Clear()
            {
                memory.Clear();
            }
            public void Koren()
            {
                mem_output();
                number = Math.Sqrt(number);
                memory.Clear();
                string str = Convert.ToString(number);
                foreach (var i in str)
                {
                    memory.Add(Convert.ToString(i));
                }
            }
            public void Koren_kub()
            {
                mem_output();
                number = Math.Pow(number, 1.0 / 3.0);
                memory.Clear();
                string str = Convert.ToString(number);
                foreach (var i in str)
                {
                    memory.Add(Convert.ToString(i));
                }
            }

            public void Save()
            {
                mem_output();
                string str = Convert.ToString(number);
                foreach (var i in str)
                {
                    save.Add(Convert.ToString(i));
                }
            }

            public void stinginput(string N, TextBox textBox1)
            {
                try
                {

                    Program.Calculator.memory.Add(N);
                    if (Program.Calculator.memory[0] == ",")
                    {
                        throw new Exception("Нельзя вводить первым символом .");
                    }
                }
                catch
                {
                    //memory.Clear();
                    //textBox1.Clear();

                    Debug.Assert(Program.Calculator.memory[0] != ",", "Нельзя вводить первым символом .");
                }
                textBox1.Text = textBox1.Text + N;
            }

        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
