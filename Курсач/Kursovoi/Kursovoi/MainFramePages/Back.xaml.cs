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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Entity;
using System.ComponentModel;

namespace Kursovoi.MainFramePages
{
    /// <summary>
    /// Логика взаимодействия для Back.xaml
    /// </summary>
    public partial class Back : Page
    {
        KursachEntities db;
        private int a;
        private string _str;
        public Back()
        {
            a = 0;
            InitializeComponent();
            db = new KursachEntities();
            db.Topics.Load();
            BackDG.ItemsSource = db.Topics.Local.ToBindingList().Where(x => x.Topic1 == "Back");
            Delete.Visibility = Visibility.Hidden;
            Refresh.Visibility = Visibility.Hidden;
        }
        public Back(string str)
        {
            a = 0;
            _str = str;
            InitializeComponent();
            db = new KursachEntities();
            db.Topics.Load();
            BackDG.ItemsSource = db.Topics.Local.ToBindingList().Where(x => x.Topic1 == "Back");
        }
        public Back(int _id)
        {
            a = _id;
            InitializeComponent();
            db = new KursachEntities();
            db.Topics.Load();
            BackDG.ItemsSource = db.Topics.Local.ToBindingList().Where(x=>x.Topic1=="Back");
            Levels.IsReadOnly = true;
            Content.IsReadOnly = true;
            Photo.IsReadOnly = true;
            Delete.Visibility = Visibility.Hidden;
            Refresh.Visibility = Visibility.Hidden;
        }
        private void BackLoaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Subscribe_Click(object sender, RoutedEventArgs e)
        {
            if (a > 0)
            {
                using (KursachEntities db = new KursachEntities())
                {
                    UsersToTopic user1 = new UsersToTopic { UserId = a, TopicNumber = ((Topic)BackDG.SelectedItem).NumberOfTopic };
                    db.UsersToTopics.Add(user1);
                    db.SaveChanges();
                }
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            db = new KursachEntities();
            db.Topics.Load();
            db.UsersToTopics.Load();
            Topic topic = BackDG.SelectedItem as Topic;
            int numbers=0;
            var userToTopic = db.Topics;
            foreach(Topic i in userToTopic.Where(x=>x.NumberOfTopic==((Topic)BackDG.SelectedItem).NumberOfTopic))
            {
                numbers = (int)i.NumberOfTopic;
              
            }
            int number = db.Database.ExecuteSqlCommand($"Delete from UsersToTopic Where TopicNumber={numbers}");
            if (topic != null)
            {
                int b = db.Database.ExecuteSqlCommand($"Delete from Topic Where NumberOfTopic={numbers}");
            }
            db.Topics.Load();
            BackDG.ItemsSource = db.Topics.Local.ToBindingList().Where(x => x.Topic1 == "Back");
        }
        private void Refresh_Click(object sendeer, RoutedEventArgs e)
        {
            db.Topics.Load();
            BackDG.ItemsSource = db.Topics.Local.ToBindingList().Where(x => x.Topic1 == "Back");
        }
    }
}
