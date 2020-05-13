using Lab7_8.Models;
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
using Lab7_8.Servisec;
using System.Globalization;

namespace Lab7_8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string Path = $"{Environment.CurrentDirectory}\\todoData.json";
        public static BindingList<TodoModels> _todoData;
        private FileIOServices _fileIOServices;
        public static void AddElement(TodoModels model)
        {
            _todoData.Add(model);
        }
        public MainWindow()
        {
            InitializeComponent();
            this.Cursor = new Cursor(@"D:\Arrow.cur");

            App.LanguageChanged += LanguageChanged;

            CultureInfo currLang = App.Language;

            //Заполняем меню смены языка:
            menuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }

            List<string> styles = new List<string> { "white", "black", "pink" };
            styleBox.SelectionChanged += ThemeChange;
            styleBox.ItemsSource = styles;
        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in menuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }

        }

        private void dgTodoList_Loaded(object sender, RoutedEventArgs e)
        {

        }



        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            newTask taskWindow = new newTask();
            taskWindow.Show();
        }
        private void MenuItem_Click1(object sender, RoutedEventArgs e)
        {
            var len = _todoData.Count;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (_todoData[j].IsDone == true && _todoData[j + 1].IsDone != true)
                    {
                        TodoModels date;
                        date = _todoData[j];
                        _todoData[j] = _todoData[j + 1];
                        _todoData[j + 1] = date;
                    }
                }
            }
            dgTodoList.Items.Refresh();
        }
        private void MenuItem_ClickPr(object sender, RoutedEventArgs e)
        {
            var len = _todoData.Count;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (_todoData[j].Priorety < _todoData[j + 1].Priorety)
                    {
                        TodoModels date;
                        date = _todoData[j];
                        _todoData[j] = _todoData[j + 1];
                        _todoData[j + 1] = date;
                    }
                }
            }
            dgTodoList.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOServices = new FileIOServices(Path);
            try
            {
                _todoData = _fileIOServices.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
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

        private void Undo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            // определяем путь к файлу ресурсов
            var uri = new Uri(@"Resources\" + style + ".xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
      
    }
}