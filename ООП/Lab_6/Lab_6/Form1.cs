using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.IO;


namespace Lab_6
{

    public partial class Form1 : Form
    {
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;
        public Form1()
        {
            InitializeComponent();
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }
        static List<Student> students = new List<Student>();
        public static List<Adress> adresses = new List<Adress>();
        public static List<Adress> AllAdreses = new List<Adress>();
        public static List<Student> ListStudents = new List<Student>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public RadioButton getButton()
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if((sender as TextBox).Text=="")
            {
                (sender as TextBox).ForeColor = Color.Red;
                (sender as TextBox).Text = "Input date";
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).ForeColor = Color.Red;
                (sender as TextBox).Text = "Input date";
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).ForeColor = Color.Red;
                (sender as TextBox).Text = "Input date";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).ForeColor = Color.Red;
                (sender as TextBox).Text = "Input date";
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label10.Text = String.Format("Group: {0}", trackBar2.Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            foreach (var item in adresses)
            {
                comboBox1.Items.Add(item.Streat);
            }
            adresses.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int indx = 0;

            foreach (var item in AllAdreses)
            {
                if (item.Streat == comboBox1.SelectedItem.ToString())
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
            Student student = new Student(textBox1.Text, Convert.ToInt32(textBox2.Text), checkedListBox1.SelectedItem.ToString(), Convert.ToDateTime(textBox3.Text), Convert.ToInt32(getButton().Text), trackBar2.Value, Convert.ToDouble(textBox5.Text), getButton2().Text, AllAdreses[indx]);
            ListStudents.Add(student);
            richTextBox1.Text += student;
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
                MessageBox.Show("List clear");
            }
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
                    MessageBox.Show("Collection clear");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsWhiteSpace(e.KeyChar))
            {
                MessageBox.Show("You must input only letter!");
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Input date")
                textBox1.Clear();
            (sender as TextBox).ForeColor = Color.Black;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !Char.IsNumber(e.KeyChar) )
            {
                MessageBox.Show("You must input only number!");
            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "Input date")
                textBox5.Clear();
            (sender as TextBox).ForeColor = Color.Black;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Input date")
                textBox2.Clear();
            (sender as TextBox).ForeColor = Color.Black;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !Char.IsNumber(e.KeyChar))
            {
                MessageBox.Show("You must input only number!");
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
        }

        private void aboutProgrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Grudinsky Pavel\n Version lab №6");
        }

        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.ShowDialog();
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            ListStudents.Clear();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "Input date")
                textBox3.Clear();
            (sender as TextBox).ForeColor = Color.Black;
        }
    }
}
