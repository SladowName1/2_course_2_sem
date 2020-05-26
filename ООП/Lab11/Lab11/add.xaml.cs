using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Lab11
{
    /// <summary>
    /// Логика взаимодействия для add.xaml
    /// </summary>
    public partial class add : Window
    {
        DataTable CustomersTable;
        string connectionString;
        SqlDataAdapter adapter;
        string FilePath = @"D:\";
        public add()
        {
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        private void Image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog
            {
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*" //формат загружаемого файла
            }; //создание диалогового окна для выбора файла
            if (open_dialog.ShowDialog() == true)
            {
                FilePath = open_dialog.FileName;

            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = string.Format("Insert into Products" + "(Id, NameProducts, Price, Photo) Values (@IdP,@Name,@Price,@Photo)");
            using (SqlCommand cmd = new SqlCommand(sql,connection))
            {
                int id = Convert.ToInt32(TId.Text);
                int price = Convert.ToInt32(TPrice.Text);
                cmd.Parameters.AddWithValue("@IdP", id);
                cmd.Parameters.AddWithValue("@Name", TName.Text);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Photo", FilePath);

                cmd.ExecuteNonQuery();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    
}
