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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.Data.Entity;
using System.ComponentModel;

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
        private void Add_click(object seneder, RoutedEventArgs e)
        {
            using (Test1Entities db= new Test1Entities())
            {
                string vs = GetHash(Byts.Text);
                T1 t1 = new T1 { I1 = Convert.ToInt32(Ints.Text), I2 = vs };
                db.T1.Add(t1);
                db.SaveChanges();
            }
        }
        private void Srav_Click(object sender, RoutedEventArgs e)
        {
            Test1Entities db = new Test1Entities();
            db.T1.Load();
            BindingList<T1> t1 = db.T1.Local.ToBindingList();
            foreach(var i in t1)
            {
                string vs = GetHash(Byts.Text);
                MessageBox.Show(vs);
                if (i.I1==Convert.ToInt32(Ints.Text) && i.I2==vs)
                {
                    MessageBox.Show("Darova");
                }
            }
        }
    }
}
