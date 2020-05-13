using lab7.Models;
using lab7.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace lab7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string Path = $"{Environment.CurrentDirectory}\\todoData.json";
        private BindingList<TodoModels> _todoData;
        private FileIOServices _fileIOServices;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dgTodoList_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _todoData = new BindingList<TodoModels>()
            {
                new TodoModels(){Text="asd"}
            };
            dgTodoList.ItemsSource = _todoData;
            _todoData.ListChanged += _todoData_ListChanged;
        }
        private void _todoData_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {

                try
                {
                    _fileIOServices.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
    }
}
