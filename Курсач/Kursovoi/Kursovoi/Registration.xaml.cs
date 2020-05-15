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

namespace Kursovoi
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void Reg_Click(object sender, RoutedEventArgs e)
        {

            
            if (RegLogin.Text.Length > 0) // проверяем логин
{
                if (RegPassword.Password.Length > 0) // проверяем пароль
	{
                    if (RegCopyPassword.Password.Length > 0) // проверяем второй пароль
		{
                        if (RegPassword.Password == RegCopyPassword.Password)
                        {
                            using (KursachEntities db = new KursachEntities())
                            {
                                User user1 = new User { Login = RegLogin.Text, Password = RegPassword.Password };
                                db.Users.Add(user1);
                                db.SaveChanges();
                                MainWindow mainWindow = new MainWindow(user1.Id);
                                mainWindow.Show();
                                this.Close();
                            }
                        }
                        else MessageBox.Show("Пароли не совподают");
                    }
                    else MessageBox.Show("Повторите пароль");
                }else MessageBox.Show("Укажите пароль");
            }else MessageBox.Show("Укажите логин");
            
        }
    }
}
