using Kursovoi.MainFramePages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            a = 0;
            _str = "";
            InitializeComponent();
            MyWorkouts.Visibility = Visibility.Hidden;
            Menu.Visibility = Visibility.Hidden;
            Logout.Visibility = Visibility.Hidden;
        }
        public MainWindow(int _id)
        {
            InitializeComponent();
            a = _id;
            _str = "";
            Registration.Visibility = Visibility.Hidden;
            Authorization.Visibility = Visibility.Hidden;
            MyWorkouts.Visibility = Visibility.Visible;
            Menu.Visibility = Visibility.Hidden;
        }
        public MainWindow(string str)
        {
            a = 0;
            _str = str;
            InitializeComponent();
            Registration.Visibility = Visibility.Hidden;
            Authorization.Visibility = Visibility.Hidden;
            MyWorkouts.Visibility = Visibility.Hidden;
            Menu.Visibility = Visibility.Visible;
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
            if (a > 0)
                Frame.Content = new Legs(a);
            else if (_str != "")
                Frame.Content = new Legs(_str);
            else Frame.Content = new Legs();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {

            if (a > 0)
                Frame.Content = new Back(a);
            else if (_str != "")
                Frame.Content = new Back(_str);
            else Frame.Content = new Back();
        }
        private void Hands_Click(object sender, RoutedEventArgs e)
        {
            if (a > 0)
                Frame.Content = new Hands(a);
            else if (_str != "")
                Frame.Content = new Hands(_str);
            else Frame.Content = new Hands();
        }
        private void My_Click(object sender, RoutedEventArgs e)
        {
            MyWorkouts my = new MyWorkouts(a);
            my.Show();
        }
        private void Add_Click(object sender,RoutedEventArgs e)
        {

        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            KursachEntities kursachEntities = new KursachEntities();
            kursachEntities.Topics.Load();
        }
        private void Info_Click(object sender,RoutedEventArgs e)
        {

        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
