using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Input data")
                textBox1.Clear();
            (sender as TextBox).ForeColor = Color.Black;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Input data")
                textBox2.Clear();
            (sender as TextBox).ForeColor = Color.Black;
        }
        private void textBox3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "Input data")
                textBox3.Clear();
            (sender as TextBox).ForeColor = Color.Black;
        }
        private void textBox4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "Input data")
                textBox4.Clear();
            (sender as TextBox).ForeColor = Color.Black;
        }
        private void textBox5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "Input data")
                textBox5.Clear();
            (sender as TextBox).ForeColor = Color.Black;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text.Contains("Input"))
            {
                MessageBox.Show("Input City");
                return;
            }
            if (textBox2.Text == "" || textBox2.Text.Contains("Input"))
            {
                MessageBox.Show("Input Streat!");
                return;
            }
            if (textBox3.Text == "" || textBox2.Text.Contains("Input"))
            {
                MessageBox.Show("Input NuberOfHouse!");
                return;
            }
            if (textBox4.Text == "" || textBox2.Text.Contains("Input"))
            {
                MessageBox.Show("Input Flat!");
                return;
            }
            if (textBox5.Text == "" || textBox2.Text.Contains("Input"))
            {
                MessageBox.Show("Input Index");
                return;
            }
            Adress adress = new Adress(textBox1.Text, Convert.ToInt32(textBox5.Text), textBox2.Text, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
