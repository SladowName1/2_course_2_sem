using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text.Contains("Input"))
            {
                MessageBox.Show("Input City");
                return;
            }
            if (textBox3.Text == "" || textBox2.Text.Contains("Input"))
            {
                MessageBox.Show("Input Streat!");
                return;
            }
            if (textBox4.Text == "" || textBox2.Text.Contains("Input"))
            {
                MessageBox.Show("Input NuberOfHouse!");
                return;
            }
            if (textBox5.Text == "" || textBox2.Text.Contains("Input"))
            {
                MessageBox.Show("Input Flat!");
                return;
            }
            if (textBox2.Text == "" || textBox2.Text.Contains("Input"))
            {
                MessageBox.Show("Input Index");
                return;
            }
            Adress adress = new Adress(textBox1.Text, Convert.ToInt32(textBox2.Text), textBox3.Text, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
            bool bol = false;
            foreach (var item in Form1.adresses)
            {

                if (adress.City == item.City)
                    bol = true;
            }
            if (!bol)
            {
                Form1.CreateAdress(adress);
                Form1.AllAdreses.Add(adress);
            }
            else
            {
                MessageBox.Show("This address is list");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !Char.IsNumber(e.KeyChar))
            {
                MessageBox.Show("You must input only number!");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !Char.IsNumber(e.KeyChar))
            {
                MessageBox.Show("You must input only number!");
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !Char.IsNumber(e.KeyChar))
            {
                MessageBox.Show("You must input only number!");
            }
        }
    }
}
