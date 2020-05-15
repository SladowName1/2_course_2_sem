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
    /// Логика взаимодействия для Legs.xaml
    /// </summary>
    public partial class Legs : Page
    {
        KursachEntities db;
        private int a;
        private string _str;
        public Legs()
        {
            InitializeComponent();
            db = new KursachEntities();
            db.Topics.Load();
            LegsDg.ItemsSource = db.Topics.Local.ToBindingList().Where(x => x.Topic1 == "Legs");
            Delete.Visibility = Visibility.Hidden;
            Refresh.Visibility = Visibility.Hidden;
        }
        public Legs(string str)
        {
            _str = str;
            InitializeComponent();
            db = new KursachEntities();
            db.Topics.Load();
            LegsDg.ItemsSource = db.Topics.Local.ToBindingList().Where(x => x.Topic1 == "Legs");

        }
        public Legs(int _id)
        {
            a = _id;
            InitializeComponent();
            db = new KursachEntities();
            db.Topics.Load();
            LegsDg.ItemsSource = db.Topics.Local.ToBindingList().Where(x => x.Topic1 == "Legs");
            Levels.IsReadOnly = true;
            Content.IsReadOnly = true;
            Photo.IsReadOnly = true;
            Delete.Visibility = Visibility.Hidden;
            Refresh.Visibility = Visibility.Hidden;
        }

        private void Subscribe_Click(object sender, RoutedEventArgs e)
        {

            if (a>0)
            {
                using (KursachEntities db = new KursachEntities())
                {
                    UsersToTopic user1 = new UsersToTopic {UserId=a,TopicNumber=((Topic)LegsDg.SelectedItem).NumberOfTopic};
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
            Topic topic = LegsDg.SelectedItem as Topic;
            int numbers = 0;
            var userToTopic = db.Topics;
            foreach (Topic i in userToTopic.Where(x => x.NumberOfTopic == ((Topic)LegsDg.SelectedItem).NumberOfTopic))
            {
                numbers = (int)i.NumberOfTopic;

            }
            int number = db.Database.ExecuteSqlCommand($"Delete from UsersToTopic Where TopicNumber={numbers}");
            if (topic != null)
            {
                int b = db.Database.ExecuteSqlCommand($"Delete from Topic Where NumberOfTopic={numbers}");
            }

        }
        private void Refresh_Click(object sendeer, RoutedEventArgs e)
        {
            db.Topics.Load();
            LegsDg.ItemsSource = db.Topics.Local.ToBindingList().Where(x => x.Topic1 == "Legs");
        }
    }
}
