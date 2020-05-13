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
using System.ComponentModel;

namespace Kursovoi
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();  
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            if (AuthLogin.Text.Length > 0) // проверяем введён ли логин     
            {
                if (AuthPassword.Password.Length > 0) // проверяем введён ли пароль         
                {
                    KursachEntities kursachEntities = new KursachEntities();
                    kursachEntities.Users.Load();
                    kursachEntities.Admins.Load();
                    BindingList<User> ts = kursachEntities.Users.Local.ToBindingList();
                    BindingList<Admin> admins = kursachEntities.Admins.Local.ToBindingList();
                    int a = 0;
                    foreach (var i in admins)
                    {
                        if(i.Login==AuthLogin.Text && i.Password==AuthPassword.Password)
                        {
                            MainWindow mainWindow = new MainWindow(i.Login);
                            mainWindow.Show();
                            this.Close();
                            a++;
                            break;
                        }
                    }
                    foreach(var i in ts)
                    {
                        if (i.Login == AuthLogin.Text && i.Password == AuthPassword.Password)
                        {
                            MainWindow mainWindow = new MainWindow(i.Id);
                            mainWindow.Show();
                            this.Close();
                            a++;
                            break;
                        }
                    } 
                    if(a==0)
                        MessageBox.Show("Пользователь не найден");
                }
                else MessageBox.Show("Введите пароль"); // выводим ошибку    
            }
            else MessageBox.Show("Введите логин"); // выводим ошибку 
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close(); 
        }
    }
}
