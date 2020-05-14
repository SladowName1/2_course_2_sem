﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursovoi.MainFramePages
{
    /// <summary>
    /// Логика взаимодействия для Hands.xaml
    /// </summary>
    public partial class Hands : Page
    {
        KursachEntities db;
        private int a;
        private string _str;
        public Hands()
        {
            InitializeComponent();
            db = new KursachEntities();
            db.Topics.Load();
            HandsDG.ItemsSource = db.Topics.Local.ToBindingList().Where(x => x.Topic1 == "Hands");
            Delete.Visibility = Visibility.Hidden;
            Refresh.Visibility = Visibility.Hidden;
        }
        public Hands(string str)
        {
            _str = str;
            InitializeComponent();
            db = new KursachEntities();
            db.Topics.Load();
            HandsDG.ItemsSource = db.Topics.Local.ToBindingList().Where(x => x.Topic1 == "Hands");
        }
        public Hands(int _id)
        {
            a = _id;
            InitializeComponent();
            db = new KursachEntities();
            db.Topics.Load();
            HandsDG.ItemsSource = db.Topics.Local.ToBindingList().Where(x => x.Topic1 == "Hands");
            Levels.IsReadOnly = true;
            Content.IsReadOnly = true;
            Photo.IsReadOnly = true;
            Delete.Visibility = Visibility.Hidden;
            Refresh.Visibility = Visibility.Hidden;
        }
        private void Subscribe_Click(object sender, RoutedEventArgs e)
        {
            if (a > 0)
            {
                using (KursachEntities db = new KursachEntities())
                {
                    UsersToTopic user1 = new UsersToTopic { UsersId = a, TopicNumber = ((Topic)HandsDG.SelectedItem).NumberOfTopic };
                    db.UsersToTopics.Add(user1);
                    db.SaveChanges();
                }
            }
        }
        private void Refresh_Click(object sendeer, RoutedEventArgs e)
        {
            db.Topics.Load();
            HandsDG.ItemsSource = db.Topics.Local.ToBindingList().Where(x => x.Topic1 == "Hands");
        }
    }
}
