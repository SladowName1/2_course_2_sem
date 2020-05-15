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
       
    }
}
