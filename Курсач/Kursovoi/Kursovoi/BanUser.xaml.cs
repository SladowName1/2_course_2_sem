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
    /// Логика взаимодействия для BanUser.xaml
    /// </summary>
    public partial class BanUser : Window
    {
        KursachEntities db;
        public BanUser()
        {
            InitializeComponent();
            db = new KursachEntities();
            db.Users.Load();
            UserBanDg.ItemsSource = db.Users.Local.ToBindingList();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            db = new KursachEntities();
            db.Users.Load();
            db.UsersToTopics.Load();
            User user = UserBanDg.SelectedItem as User;
            var userToTopic = db.Users;
            int id = 0;
            foreach(User i in userToTopic.Where(x=>x.Id==((User)UserBanDg.SelectedItem).Id))
            {
                id = (int)i.Id;
            }
            int number = db.Database.ExecuteSqlCommand($"Delete from UsersToTopic Where UserId={id}");
            if(user!=null)
            {
                int b = db.Database.ExecuteSqlCommand($"Delete from Users Where Id={id}");
            }
            db.Users.Load();
            UserBanDg.ItemsSource = db.Users.Local.ToBindingList();
        }
    }
}
