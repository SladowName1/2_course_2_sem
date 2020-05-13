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
        public Back(int _id)
        {
            a = _id;
            InitializeComponent();
            db = new KursachEntities();
            db.Topics.Load();
            BackDG.ItemsSource = db.Topics.Local.ToBindingList().Where(x=>x.Topic1=="Back");
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
                    UsersToTopic user1 = new UsersToTopic { UsersId = a, TopicNumber = ((Topic)BackDG.SelectedItem).NumberOfTopic };
                    db.UsersToTopics.Add(user1);
                    db.SaveChanges();
                }
            }
        }
    }
}
