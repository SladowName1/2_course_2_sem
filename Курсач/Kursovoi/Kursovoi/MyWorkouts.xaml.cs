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
            foreach (var i in db.UsersToTopics.Where(x=>x.UserId==a))
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
                UsersToTopic usersToTopic = new UsersToTopic { UserId = a, TopicNumber = ((Topic)MyWorkoutsDG.SelectedItem).NumberOfTopic};
                if(usersToTopic!=null)
                {

                    var maxLevel = db.Topics;
                    int maxlevel = 0;
                    foreach(Topic i in maxLevel.Where(y => y.Topic1 == ((Topic)MyWorkoutsDG.SelectedItem).Topic1 && y.Level > ((Topic)MyWorkoutsDG.SelectedItem).Level))
                    {
                        if (maxlevel < i.Level)
                            maxlevel = (int)i.Level;
                    }
                    if(maxlevel>((Topic)MyWorkoutsDG.SelectedItem).Level)
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
                                else if(d>0) break;
                            }
                            db.UsersToTopics.Remove(db.UsersToTopics.Where(x => x.UserId == a && x.TopicNumber == ((Topic)MyWorkoutsDG.SelectedItem).NumberOfTopic).First());
                            db.SaveChanges();
                            BindingList<Topic> topics7 = new BindingList<Topic>();
                            foreach (var i in db.UsersToTopics.Where(x => x.UserId == a))
                            {
                                topics7.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
                            }
                            MyWorkoutsDG.ItemsSource = topics7;
                            UsersToTopic user1 = new UsersToTopic { UserId = a, TopicNumber = topicasd};
                            db.UsersToTopics.Add(user1);
                            db.SaveChanges();
                            BindingList<Topic> topics1 = new BindingList<Topic>();

                            foreach (var i in db.UsersToTopics.Where(x => x.UserId == a))
                            {
                                topics1.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
                            }
                            MyWorkoutsDG.ItemsSource = topics1;
                        }
                        else
                        {
                            var result4 = MessageBox.Show("Хотите остаться на данном уровне?", "Qustion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result4 == MessageBoxResult.No)
                            {

                                BindingList<Topic> topics1 = new BindingList<Topic>();
                                foreach (var i in db.UsersToTopics.Where(x => x.UserId == a))
                                {
                                    topics1.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
                                }
                                MyWorkoutsDG.ItemsSource = topics1;
                                db = new KursachEntities();
                                var minLevel = db.Topics;
                                int minlevel = 123123;
                                foreach (Topic i in minLevel.Where(y => y.Topic1 == ((Topic)MyWorkoutsDG.SelectedItem).Topic1 && y.Level < ((Topic)MyWorkoutsDG.SelectedItem).Level))
                                {
                                    if (minlevel > i.Level)
                                        minlevel = (int)i.Level;
                                }
                                if (minlevel < ((Topic)MyWorkoutsDG.SelectedItem).Level)
                                {
                                    var result5 = MessageBox.Show("Хотите перейти на предыдущий уровень?", "Qustion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                    if(result5==MessageBoxResult.Yes)
                                    {
                                        int topicasd = 0;
                                        var _topicNumber = db.Topics;
                                        int d = 0;
                                        foreach (Topic i in _topicNumber.Where(y => y.Topic1 == ((Topic)MyWorkoutsDG.SelectedItem).Topic1 && y.Level <((Topic)MyWorkoutsDG.SelectedItem).Level))
                                        {
                                            if (d == 0)
                                            {
                                                d++;
                                                topicasd = i.NumberOfTopic;

                                            }
                                            else if (d > 0) break;
                                        }
                                        db.UsersToTopics.Remove(db.UsersToTopics.Where(x => x.UserId == a && x.TopicNumber == ((Topic)MyWorkoutsDG.SelectedItem).NumberOfTopic).First());
                                        db.SaveChanges();
                                        UsersToTopic user1 = new UsersToTopic { UserId = a, TopicNumber = topicasd };
                                        db.UsersToTopics.Add(user1);
                                        db.SaveChanges();
                                        BindingList<Topic> topics6 = new BindingList<Topic>();
                                        foreach (var i in db.UsersToTopics.Where(x => x.UserId == a))
                                        {
                                            topics6.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
                                        }
                                        MyWorkoutsDG.ItemsSource = topics6;
                                    }
                                    else
                                    {
                                        db.UsersToTopics.Remove(db.UsersToTopics.Where(x => x.UserId == a && x.TopicNumber == ((Topic)MyWorkoutsDG.SelectedItem).NumberOfTopic).First());
                                        db.SaveChanges();
                                        BindingList<Topic> topics6 = new BindingList<Topic>();
                                        foreach (var i in db.UsersToTopics.Where(x => x.UserId == a))
                                        {
                                            topics1.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
                                        }
                                        MyWorkoutsDG.ItemsSource = topics6;
                                    }
                                }
                                else
                                {
                                    var result8 = MessageBox.Show("Простите ниже этого уровня нету, повторяем?", "Qustion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                    if(result8==MessageBoxResult.No)
                                    {
                                        db.UsersToTopics.Remove(db.UsersToTopics.Where(x => x.UserId == a && x.TopicNumber == ((Topic)MyWorkoutsDG.SelectedItem).NumberOfTopic).First());
                                        db.SaveChanges();
                                        BindingList<Topic> topics6 = new BindingList<Topic>();
                                        foreach (var i in db.UsersToTopics.Where(x => x.UserId == a))
                                        {
                                            topics1.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
                                        }
                                        MyWorkoutsDG.ItemsSource = topics6;
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        var result2 = MessageBox.Show("Не хочешь повторить что сделал?", "Qustion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                       if (result2==MessageBoxResult.Yes)
                        {
                            BindingList<Topic> topics1 = new BindingList<Topic>();
                            foreach (var i in db.UsersToTopics.Where(x => x.UserId == a))
                            {
                                topics1.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
                            }
                            MyWorkoutsDG.ItemsSource = topics1;
                        }
                        else
                        {
                            db.UsersToTopics.Remove(db.UsersToTopics.Where(x => x.UserId == a && x.TopicNumber == ((Topic)MyWorkoutsDG.SelectedItem).NumberOfTopic).First());
                            db.SaveChanges();
                            BindingList<Topic> topics4 = new BindingList<Topic>();
                            foreach (var i in db.UsersToTopics.Where(x => x.UserId == a))
                            {
                                topics4.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
                            }
                            MyWorkoutsDG.ItemsSource = topics4;
                        }

                    }
                    
                }
                BindingList<Topic> topics = new BindingList<Topic>();
                foreach (var i in db.UsersToTopics.Where(x => x.UserId == a))
                {
                    topics.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
                }
                MyWorkoutsDG.ItemsSource = topics;
            }
            else
            {
                var result3 = MessageBox.Show("Хотите отменить тренировку?", "Qustion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(result3==MessageBoxResult.Yes)
                {
                    db.UsersToTopics.Remove(db.UsersToTopics.Where(x => x.UserId == a && x.TopicNumber == ((Topic)MyWorkoutsDG.SelectedItem).NumberOfTopic).First());
                    db.SaveChanges();
                    BindingList<Topic> topics = new BindingList<Topic>();
                    foreach (var i in db.UsersToTopics.Where(x => x.UserId == a))
                    {
                        topics.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
                    }
                    MyWorkoutsDG.ItemsSource = topics;
                }
                else
                {
                    var minLevel = db.Topics;
                    int minlevel = 123123;
                    foreach (Topic i in minLevel.Where(y => y.Topic1 == ((Topic)MyWorkoutsDG.SelectedItem).Topic1 && y.Level < ((Topic)MyWorkoutsDG.SelectedItem).Level))
                    {
                        if (minlevel > i.Level)
                            minlevel = (int)i.Level;
                    }
                    if (minlevel < ((Topic)MyWorkoutsDG.SelectedItem).Level)
                    {
                        var result9 = MessageBox.Show("Хотите вернуться на предыдущий уровень?", "Qustion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result9 == MessageBoxResult.Yes)
                        {

                               int topicasd = 0;
                                var _topicNumber = db.Topics;
                                int d = 0;
                                foreach (Topic i in _topicNumber.Where(y => y.Topic1 == ((Topic)MyWorkoutsDG.SelectedItem).Topic1 && y.Level < ((Topic)MyWorkoutsDG.SelectedItem).Level))
                                {
                                    if (d == 0)
                                    {
                                        d++;
                                        topicasd = i.NumberOfTopic;

                                    }
                                    else if (d > 0) break;
                                }
                                db.UsersToTopics.Remove(db.UsersToTopics.Where(x => x.UserId == a && x.TopicNumber == ((Topic)MyWorkoutsDG.SelectedItem).NumberOfTopic).First());
                                db.SaveChanges();
                                UsersToTopic user1 = new UsersToTopic { UserId = a, TopicNumber = topicasd };
                                db.UsersToTopics.Add(user1);
                                db.SaveChanges();
                                BindingList<Topic> topics10 = new BindingList<Topic>();
                                foreach (var i in db.UsersToTopics.Where(x => x.UserId == a))
                                {
                                    topics10.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
                                }
                                MyWorkoutsDG.ItemsSource = topics10;
                        }
                    }
                    else
                    {
                        db.UsersToTopics.Remove(db.UsersToTopics.Where(x => x.UserId == a && x.TopicNumber == ((Topic)MyWorkoutsDG.SelectedItem).NumberOfTopic).First());
                        db.SaveChanges();
                        BindingList<Topic> topics10 = new BindingList<Topic>();
                        foreach (var i in db.UsersToTopics.Where(x => x.UserId == a))
                        {
                            topics10.Add(db.Topics.Where(y => y.NumberOfTopic == i.TopicNumber).First());
                        }
                        MyWorkoutsDG.ItemsSource = topics10;
                    }
                }
            }

           
        }
    }
}
