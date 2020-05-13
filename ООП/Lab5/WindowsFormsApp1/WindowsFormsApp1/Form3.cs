using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public RadioButton getButton()
        {
            if (radioButton1.Checked)
                return radioButton1;
            if (radioButton2.Checked)
                return radioButton2;
            if (radioButton3.Checked)
                return radioButton3;
            if (radioButton4.Checked)
                return radioButton4;
            else return null;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string pattern1 = (@"\D*?");
            string pattern2 = (@"\D{4,6}");
            Regex regex1=new Regex(@"ИСиТ|ПОИТ|ДЭИВИ|МОБИЛКИ",RegexOptions.IgnoreCase);
            string pattern3 = (@"{1-4}{1}");
            string pattern4 = (@"{4-10}{1}");
            bool prov=true;

            if(textBox1.Text =="" && textBox2.Text=="" && textBox3.Text=="" && getButton()==null)
            {
                MessageBox.Show("You dont oick any critaries");
                return;
            }

            if (textBox1.Text != "" && textBox2.Text == "" && textBox3.Text == "" && getButton() == null)
            {
                if (Regex.IsMatch(textBox1.Text, pattern1, RegexOptions.IgnoreCase))
                {
                    foreach (var item in Form1.ListStudents)
                    {
                        if (item.Name == textBox1.Text)
                        {
                            richTextBox1.Text += item;
                            prov = false;
                        }

                    }
                    if (prov)
                    {
                        MessageBox.Show("Nobody students");
                        textBox1.Clear();
                        return;
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("No correctly input data");
                    return;
                }
            }
                prov = true;
               if (textBox1.Text == "" && textBox2.Text != "" && textBox3.Text == "" && getButton() == null)
                {
                    if(regex1.IsMatch(textBox2.Text))
                    {
                        foreach(var item in Form1.ListStudents)
                        {
                            if(item.Profession==textBox2.Text.ToUpper())
                            {
                                richTextBox1.Text += item;
                                prov = false;
                            }

                        }
                        if (prov)
                        {
                            MessageBox.Show("Nobody students");
                            textBox1.Clear();
                            return;
                        }
                        return;
                    }
                    else
                    {
                        MessageBox.Show("This Profession isn't in this univer");
                        return;
                    }
                }
                prov = true;
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text != "" && getButton() == null)
            {
                if(Regex.IsMatch(textBox3.Text,pattern4,RegexOptions.IgnoreCase))
                {
                    foreach(var item in Form1.ListStudents)
                    {
                        if (item.Avg > Convert.ToDouble(textBox3.Text))
                        {
                            richTextBox1.Text += item;
                            prov = false;
                        }
                    }
                    if(prov)
                    {
                        MessageBox.Show("No coincidences");
                        textBox3.Clear();
                        return;
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("You make mistake");
                    return;
                }
            }
            prov = true;
            if (textBox1.Text == "" && textBox2.Text == "" && getButton() != null)  //толко по кнопке
            {
                if (Regex.IsMatch(getButton().Text, pattern3, RegexOptions.IgnoreCase))
                {
                    foreach (var item in Form1.ListStudents)
                    {
                        if (item.Course == Convert.ToInt32(getButton().Text))
                        {
                            richTextBox1.Text += item;
                            prov = false;
                        }

                    }
                    if (prov)
                    {
                        MessageBox.Show("Совпадений не найдено :(");
                        textBox2.Clear();
                        return;
                    }
                    getButton().Checked = false;
                    return;
                }
            }
            prov = true;
        }
    }
}
