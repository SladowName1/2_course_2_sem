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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            var GroupSort = Form1.ListStudents.OrderBy(n => n.Group);

            foreach (var item in GroupSort)
            {
                richTextBox1.Text += item;
            }

            saveFileDialog1.FileName = "GroupSort.xml";
            saveFileDialog1.ShowDialog();

            if (GroupSort.ToList().Count != 0)
            {
                using (FileStream fs = new FileStream(this.saveFileDialog1.FileName, FileMode.OpenOrCreate))
                {

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
                    xmlSerializer.Serialize(fs, GroupSort.ToList());

                }
            }
            else
            {
                MessageBox.Show("List clear");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            var CourseSort = Form1.ListStudents.OrderBy(n => n.Course);

            foreach (var item in CourseSort)
            {
                richTextBox1.Text += item;
            }

            saveFileDialog1.FileName = "CourseSort.xml";
            saveFileDialog1.ShowDialog();

            if (CourseSort.ToList().Count != 0)
            {
                using (FileStream fs = new FileStream(this.saveFileDialog1.FileName, FileMode.OpenOrCreate))
                {

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
                    xmlSerializer.Serialize(fs, CourseSort.ToList());

                }
            }
            else
            {
                MessageBox.Show("List clear");
            }
        }
    }
}
