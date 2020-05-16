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
    /// Логика взаимодействия для AddAdmin.xaml
    /// </summary>
    public partial class AddAdmin : Window
    {
        KursachEntities db;
        public AddAdmin()
        {
            InitializeComponent();
        }
        private void Add_admin(object sender, RoutedEventArgs e)
        {
                if (AddLogin.Text.Length > 0)
                {
                    db = new KursachEntities();
                    db.Admins.Load(); ;
                    foreach (Admin i in db.Admins)
                    {
                        if (AddLogin.Text == i.Login)
                        {
                            MessageBox.Show("This login is busy, pls pressed another login");
                        }
                    }
                    if (AddPassword.Password.Length > 0)
                    {
                        Admin admin = new Admin { Login = AddLogin.Text, Password = AddPassword.Password };
                        db.Admins.Add(admin);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("You dont pressed password");
                    }
                }
                else
                {
                    MessageBox.Show("You dont pressed login");
                }
        }
        private void Cancel_Click(object sennder,RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
