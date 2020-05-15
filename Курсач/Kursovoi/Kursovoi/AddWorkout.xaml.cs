using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kursovoi
{
    /// <summary>
    /// Логика взаимодействия для AddWorkout.xaml
    /// </summary>
    public partial class AddWorkout : Window
    {
        KursachEntities db;
        public string FilePath = @"D:\Image";
        public AddWorkout()
        {
            InitializeComponent();
        }
        public void Image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog
            {
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*" //формат загружаемого файла
            }; //создание диалогового окна для выбора файла
            if (open_dialog.ShowDialog() == true)
            {
                FilePath = open_dialog.FileName;

            }
        }
        public void Add_Click(object sender, RoutedEventArgs e)
        {
            db = new KursachEntities();
            Topic topic = new Topic { Topic1 = Topic.Text, Level = Convert.ToInt32(Levels.Text), Image = FilePath, Content = new TextRange(Content1.Document.ContentStart, Content1.Document.ContentEnd).Text };
            db.Topics.Add(topic);
            db.SaveChanges();
        }
        public void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Text_Validation(object sender, TextCompositionEventArgs e)
        {
            if(e.Text!="." && IsNumber(e.Text)==false)
            {
                e.Handled = true;
            }
            else if(e.Text==".")
            {
                if(((TextBox)sender).Text.IndexOf(e.Text)>-1)
                {
                    e.Handled = true;
                }
            }
        }
        private bool IsNumber(string Text)
        {
            int output;
            return int.TryParse(Text, out output);
        }
    }
}
