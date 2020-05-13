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

namespace Lab10
{
    /// <summary>
    /// Логика взаимодействия для FirstCustom.xaml
    /// </summary>
    public partial class FirstCustom : UserControl
    {
        public FirstCustom()
        {
            InitializeComponent();
        }
        private void First_Checked(object sender, RoutedEventArgs e)
        {
            Label.Content = "First butt is click";
        }
        private void Second_Checked(object sender, RoutedEventArgs e)
        {
            Label.Content = "Second button is click";
        }
        private void Third_Checked(object sender, RoutedEventArgs e)
        {
            Label.Content = "Third button is click";
        }
    }
}
