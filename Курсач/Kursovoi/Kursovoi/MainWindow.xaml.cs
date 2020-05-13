using Kursovoi.MainFramePages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursovoi
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int a;
        private string _str;
        public MainWindow()
        {
            InitializeComponent();
            MyWorkouts.Visibility = Visibility.Hidden;
        }
        public MainWindow(int _id)
        {
            InitializeComponent();
            a = _id;
            Registration.Visibility = Visibility.Hidden;
            Authorization.Visibility = Visibility.Hidden;
            MyWorkouts.Visibility = Visibility.Visible;
        }
        public MainWindow(string str)
        {
            _str = str;
            InitializeComponent();
            Registration.Visibility = Visibility.Hidden;
            Authorization.Visibility = Visibility.Hidden;
            MyWorkouts.Visibility = Visibility.Hidden;
        }
        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            Authorization auth= new Authorization();
            auth.Show();
            this.Close();
        }
        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }
        private void Legs_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Legs(a);     
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Back(a);
        }
        private void Hands_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Hands(a);
        }
        private void My_Click(object sender, RoutedEventArgs e)
        {
            MyWorkouts my = new MyWorkouts(a);
            my.Show();
        }
    }
}
