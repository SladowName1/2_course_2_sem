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
using System.Windows.Shapes;

namespace Kursovoi
{
    /// <summary>
    /// Логика взаимодействия для MyWorkouts.xaml
    /// </summary>
    public partial class MyWorkouts : Window
    {
        KursachEntities db;
        private int a;
        public MyWorkouts(int _id)
        {
            db = new KursachEntities();
            InitializeComponent();
            a = _id;
            db.UsersToTopics.Load();
            db.Topics.Load();
            BindingList<UsersToTopic> usersTos = db.UsersToTopics.Local.ToBindingList();
            BindingList<Topic> topics = new BindingList<Topic>();
            foreach(var i in db.UsersToTopics.Where(x=>x.UsersId==a))
            {
                topics.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
            }
            MyWorkoutsDG.ItemsSource = topics;
        }
        private void IsDone_Click(object sender,RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы закончили тренировку?","Qustion",MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result==MessageBoxResult.Yes)
            {
                UsersToTopic usersToTopic = new UsersToTopic { UsersId = a, TopicNumber = ((Topic)MyWorkoutsDG.SelectedItem).NumberOfTopic};
                if(usersToTopic!=null)
                {
                    db.UsersToTopics.Remove(db.UsersToTopics.Where(x => x.UsersId == a && x.TopicNumber == ((Topic)MyWorkoutsDG.SelectedItem).NumberOfTopic).First());
                    db.SaveChanges();
                    if(4>((Topic)MyWorkoutsDG.SelectedItem).Level)
                    {
                        var result2 = MessageBox.Show("Не хотели бы приступить к следующему уровну?", "Qustion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result2 == MessageBoxResult.Yes)
                        {
                            int topicasd=0;
                            var _topicNumber = db.Topics;
                            int d = 0;
                            foreach(Topic i in _topicNumber.Where(y => y.Topic1 == ((Topic)MyWorkoutsDG.SelectedItem).Topic1 && y.Level > ((Topic)MyWorkoutsDG.SelectedItem).Level))
                            {
                                if (d == 0)
                                {
                                    d++;
                                    topicasd = i.NumberOfTopic;
                                }
                                else break;
                            }
                            UsersToTopic user1 = new UsersToTopic { UsersId = a, TopicNumber = topicasd};
                            db.UsersToTopics.Add(user1);
                            db.SaveChanges();
                            BindingList<Topic> topics1 = new BindingList<Topic>();

                            foreach (var i in db.UsersToTopics.Where(x => x.UsersId == a))
                            {
                                topics1.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
                            }
                            MyWorkoutsDG.ItemsSource = topics1;
                        }
                    }
                    else
                    {
                        var result2 = MessageBox.Show("Не хочешь повторить что сделал?", "Qustion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                       if (result2==MessageBoxResult.Yes)
                        {
                            UsersToTopic user1 = new UsersToTopic { UsersId = a, TopicNumber = ((Topic)MyWorkoutsDG.SelectedItem).NumberOfTopic };
                            db.UsersToTopics.Add(user1);
                            db.SaveChanges();
                            BindingList<Topic> topics1 = new BindingList<Topic>();
                            foreach (var i in db.UsersToTopics.Where(x => x.UsersId == a))
                            {
                                topics1.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
                            }
                            MyWorkoutsDG.ItemsSource = topics1;
                        }
                    }
                    
                }
                BindingList<Topic> topics = new BindingList<Topic>();
                foreach (var i in db.UsersToTopics.Where(x => x.UsersId == a))
                {
                    topics.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
                }
                MyWorkoutsDG.ItemsSource = topics;
            }

           
        }
    }
}
