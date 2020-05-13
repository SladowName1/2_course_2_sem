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
    /// Логика взаимодействия для SecondCustom.xaml
    /// </summary>
    public partial class SecondCustom : UserControl
    {
        public SecondCustom()
        {
            InitializeComponent();
        }
        private void First_click(object sender, RoutedEventArgs e)
        {
            Second.Visibility = Visibility;
        }
        private void Second_click(object sender, RoutedEventArgs e)
        {
            Third.Visibility = Visibility;
        }
        private void Third_click(object sender, RoutedEventArgs e)
        {
            Fourth.Visibility = Visibility;
        }
        private void Fourth_click(object sender, RoutedEventArgs e)
        {
            Second.Visibility = Visibility.Hidden;
            Third.Visibility = Visibility.Hidden;
            Fourth.Visibility = Visibility.Hidden;
        }
    }
}
