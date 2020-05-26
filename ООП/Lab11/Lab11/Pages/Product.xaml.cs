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
using System.Data;
using System.Data.SqlClient;

namespace Lab11.Pages
{
    /// <summary>
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Product : Page
    {
        DataTable ProductsTable;
        string connectionString;
        SqlDataAdapter adapter;
        public Product()
        {
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "Select * from Products";
            ProductsTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                adapter.InsertCommand = new SqlCommand("sp_InsertProduct", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Id",SqlDbType.Int,0,"Id"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@NameProducts", SqlDbType.NVarChar, 50, "Product"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Price", SqlDbType.Int, 0, "Price"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Photo","Photo"));
                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(ProductsTable);
                ProductDG.ItemsSource = ProductsTable.DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateDB()
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(ProductsTable);
        }
        private void Oreder_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void Add_click(object sender, RoutedEventArgs e)
        {
            add add = new add();
            add.Show();
        }
        private void Row_Editing(object sender, DataGridRowEditEndingEventArgs e)
        {
            UpdateDB();
        }
        private void Upd_click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }
    }
}
