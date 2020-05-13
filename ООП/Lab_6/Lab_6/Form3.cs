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

namespace Lab_6
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            string pattern1 = (@"\D*?");
            Regex regex=new Regex(@"ИСИТ|ПОИТ|ПОИБМС|ДЭИВИ", RegexOptions.IgnoreCase);
            string pattern2 = (@"[1-9]{1}");
            bool prov = true;

            if(textBox1.Text== "" && textBox2.Text== "" && textBox3.Text== "")
            {
                MessageBox.Show("You don't select anyone criterion");
                return;
            }

            if(textBox1.Text!= "" && textBox2.Text== "" && textBox3.Text== "")
            {
                if (Regex.IsMatch(textBox1.Text, pattern1, RegexOptions.IgnoreCase))
                {
                    foreach (var item in Form1.ListStudents)
                    {
                        if (item.Name==textBox1.Text)
                        {
                            richTextBox1.Text += item;
                            prov = false;
                        }

                    }
                    if (prov)
                    {
                        MessageBox.Show("No matches :(");
                        textBox1.Clear();
                        return;
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("You dont must press number on name!");
                    return;
                }
            }
            prov=true;

            if(textBox1.Text== "" && textBox2.Text!= "" && textBox3.Text== "")
            {
                if (regex.IsMatch(textBox2.Text))
                {
                    foreach (var item in Form1.ListStudents)
                    {
                        if (item.Profession == textBox2.Text.ToUpper())
                        {
                            richTextBox1.Text += item;
                            prov = false;
                        }

                    }
                    if (prov)
                    {
                        MessageBox.Show("No matches :(");
                        textBox2.Clear();
                        return;
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("This profession no correctly!");
                    return;
                }

            }
            prov = true;

            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text != "")
            {
                if (Regex.IsMatch(textBox3.Text, pattern2, RegexOptions.IgnoreCase))
                {
                    foreach (var item in Form1.ListStudents)
                    {
                        if (item.Group == Convert.ToInt32(textBox3.Text))
                        {
                            richTextBox1.Text += item;
                            prov = false;
                        }

                    }
                    if (prov)
                    {
                        MessageBox.Show("No matches :(");
                        textBox1.Clear();
                        return;
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("This group dont is!");
                    return;
                }
            }
            prov = true;

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text == "")
            {
                if (Regex.IsMatch(textBox1.Text, pattern1, RegexOptions.IgnoreCase) && regex.IsMatch(textBox2.Text))
                {
                    foreach (var item in Form1.ListStudents)
                    {
                        if (item.Profession == textBox2.Text.ToUpper() && item.Name==textBox1.Text) 
                        {
                            richTextBox1.Text += item;
                            prov = false;
                        }

                    }
                    if (prov)
                    {
                        MessageBox.Show("No matches :(");
                        textBox2.Clear();
                        return;
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("Profession or name dont correctly press");
                    return;
                }

            }
            prov = true;

            if (textBox1.Text == "" && textBox2.Text != "" && textBox3.Text != "")
            {
                if (regex.IsMatch(textBox2.Text) && Regex.IsMatch(textBox3.Text, pattern2, RegexOptions.IgnoreCase))
                {
                    foreach (var item in Form1.ListStudents)
                    {
                        if (item.Group == Convert.ToInt32(textBox3.Text) && item.Profession==textBox2.Text.ToUpper())
                        {
                            richTextBox1.Text += item;
                            prov = false;
                        }

                    }
                    if (prov)
                    {
                        MessageBox.Show("No matches :(");
                        textBox1.Clear();
                        return;
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("Profession or group dont correctly press");
                    return;
                }
            }
            prov = true;

            if (textBox1.Text != "" && textBox2.Text == "" && textBox3.Text != "")
            {
                if (Regex.IsMatch(textBox1.Text, pattern1, RegexOptions.IgnoreCase) && Regex.IsMatch(textBox3.Text, pattern2, RegexOptions.IgnoreCase))
                {
                    foreach (var item in Form1.ListStudents)
                    {
                        if (item.Group == Convert.ToInt32(textBox3.Text) && item.Name==textBox1.Text)
                        {
                            richTextBox1.Text += item;
                            prov = false;
                        }

                    }
                    if (prov)
                    {
                        MessageBox.Show("No matches :(");
                        textBox1.Clear();
                        return;
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("Name or group dont correctly press");
                    return;
                }
            }
            prov = true;

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                if (Regex.IsMatch(textBox1.Text, pattern1, RegexOptions.IgnoreCase) && Regex.IsMatch(textBox3.Text, pattern2, RegexOptions.IgnoreCase) && regex.IsMatch(textBox2.Text))
                {
                    foreach (var item in Form1.ListStudents)
                    {
                        if (item.Group == Convert.ToInt32(textBox3.Text) && item.Name == textBox1.Text && item.Profession==textBox2.Text.ToUpper())
                        {
                            richTextBox1.Text += item;
                            prov = false;
                        }

                    }
                    if (prov)
                    {
                        MessageBox.Show("No matches :(");
                        textBox1.Clear();
                        return;
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("Name or group or profession dont correctly press");
                    return;
                }
            }
            prov = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
