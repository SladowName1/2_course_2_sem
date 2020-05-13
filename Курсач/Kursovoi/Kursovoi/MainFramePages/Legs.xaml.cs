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
        public Legs(int _id)
        {
            a = _id;
            InitializeComponent();
            db = new KursachEntities();
            db.Topics.Load();
            LegsDg.ItemsSource = db.Topics.Local.ToBindingList().Where(x => x.Topic1 == "Legs");   
        }

        private void Subscribe_Click(object sender, RoutedEventArgs e)
        {

            if (a>0)
            {
                using (KursachEntities db = new KursachEntities())
                {
                    UsersToTopic user1 = new UsersToTopic {UsersId=a,TopicNumber=((Topic)LegsDg.SelectedItem).NumberOfTopic};
                    db.UsersToTopics.Add(user1);
                    db.SaveChanges();
                }
            }
        }
    }
}
