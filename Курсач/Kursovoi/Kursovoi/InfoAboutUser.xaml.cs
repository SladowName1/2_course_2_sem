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
    /// Логика взаимодействия для InfoAboutUser.xaml
    /// </summary>
    public partial class InfoAboutUser : Window 
    {
        KursachEntities db;
        public InfoAboutUser()
        {
            InitializeComponent();
            db = new KursachEntities();
            db.UsersToTopics.Load();
            UserInfoDg.ItemsSource = db.UsersToTopics.Local.ToBindingList();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            db.UsersToTopics.Load();
            UsersToTopic usersToTopic = UserInfoDg.SelectedItem as UsersToTopic;
            if (usersToTopic != null)
            {
                db.UsersToTopics.RemoveRange(db.UsersToTopics.Where(y => y.UserId == ((UsersToTopic)UserInfoDg.SelectedItem).UserId && y.TopicNumber == ((UsersToTopic)UserInfoDg.SelectedItem).TopicNumber));
            }
            db.SaveChanges();
            db.UsersToTopics.Load();
            UserInfoDg.ItemsSource = db.UsersToTopics.Local.ToBindingList();

        }
    }
}
