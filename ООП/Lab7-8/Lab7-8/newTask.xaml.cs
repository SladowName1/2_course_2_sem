using System;
using System.Collections.Generic;
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
using Lab7_8.Models;
using Lab7_8.Servisec;

namespace Lab7_8
{
    /// <summary>
    /// Логика взаимодействия для newTask.xaml
    /// </summary>
    public partial class newTask : Window
    {
        public newTask()
        {
            InitializeComponent();
            this.Cursor = new Cursor(@"D:\Curs.cur");
        }
        public RadioButton Getbutton()
        {
            if (FirstBut.IsChecked == true)
                return FirstBut;
            if (SecondBut.IsChecked == true)
                return SecondBut;
            if(ThirdBut.IsChecked==true)
                return ThirdBut;
            return FirtdBut;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            TodoModels model = new TodoModels();
            if (TextBox.Text != "")
            {
                model.Text = TextBox.Text;
                model.Priorety = Convert.ToInt32(Getbutton().Content);
                model.Pereodicaly = ComboBoxAdd.Text;
                MainWindow.AddElement(model);
            }
        }
    }
}
