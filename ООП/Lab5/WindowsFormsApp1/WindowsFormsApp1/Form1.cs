using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        static List<Student> students = new List<Student>();
        public static List<Adress> adresses=new List<Adress>();
        public static List<Adress> AllAdreses = new List<Adress>();
        public  static List<Student> ListStudents = new List<Student>();

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public RadioButton getButtom()
        {
            if (radioButton1.Checked)
                return radioButton1;
            if (radioButton2.Checked)
                return radioButton2;
            if (radioButton3.Checked)
                return radioButton3;
            else
                return radioButton4;
        }
        public RadioButton getButton2() 
        {
            if (radioButton5.Checked)
                return radioButton5;
            else
                return radioButton6;
        }
        internal static void CreateAdress(Adress adress)
        {
            adresses.Add(adress);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)

        {
            if (e.Handled = !Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsWhiteSpace(e.KeyChar))
                MessageBox.Show("input only letter");
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if((sender as TextBox).Text=="")
            {
                (sender as TextBox).Text = "Input data";
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label9.Text = String.Format("Years old: {0}", trackBar1.Value);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            foreach (var item in adresses)
            {
                comboBox2.Items.Add(item.Streat);
            }
            adresses.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "File.xml";
            saveFileDialog1.ShowDialog();

            if (ListStudents.Count != 0)
            {
                using (FileStream fs = new FileStream(this.saveFileDialog1.FileName, FileMode.OpenOrCreate))
                {

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
                    xmlSerializer.Serialize(fs, ListStudents);

                }
            }
            else
            {
                MessageBox.Show("Список пуст");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int indx = 0;

            foreach (var item in AllAdreses)
            {
                if (item.Streat == comboBox2.SelectedItem.ToString())
                {
                    indx = AllAdreses.IndexOf(item);
                }
            }



            foreach (var item in ListStudents)
            {
                if (item.Name == textBox1.Text)
                {
                    MessageBox.Show("This student added!");
                    return;
                }
            }


            Student student = new Student(textBox1.Text, textBox2.Text, checkedListBox1.SelectedItem.ToString(), Convert.ToInt32(getButtom().Text), Convert.ToInt32(textBox5.Text), AllAdreses[indx], Convert.ToDateTime(textBox3.Text), trackBar1.Value, getButton2().Text, Convert.ToDouble(textBox4.Text));
            ListStudents.Add(student);
            richTextBox1.Text += student;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.FileName = "serialization.xml";
                this.openFileDialog1.ShowDialog();

                List<Student> lst;
                using (FileStream fs = new FileStream(this.openFileDialog1.FileName, FileMode.Open))
                {

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
                    lst = (List<Student>)xmlSerializer.Deserialize(fs);

                }
                if (lst.Count != 0)
                {
                    foreach (Student i in lst)
                    {
                        this.richTextBox1.Text += i;
                    }
                }
                else
                {
                    MessageBox.Show("Коллекция пуста");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:" + ex.Message);
            }
        }

        private void textBox1_Validating_1(object sender, CancelEventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "Input data";
            }

        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsWhiteSpace(e.KeyChar))
                MessageBox.Show("input only letter");
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "Input data";
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsWhiteSpace(e.KeyChar))
                MessageBox.Show("input only letter");
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !Char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Input only number!");
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void searhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
