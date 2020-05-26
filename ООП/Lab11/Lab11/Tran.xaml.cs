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
    /// Логика взаимодействия для Tran.xaml
    /// </summary>
    public partial class Tran : Window
    {
        DataTable ProductsTable;
        string connectionString;
        SqlDataAdapter adapter;
        SqlConnection connection;
        public Tran()
        {
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        private void Trans(object sender, RoutedEventArgs e)
        {
            connection.Open();


            SqlTransaction tx = connection.BeginTransaction();
            SqlCommand command = connection.CreateCommand();
            command.Transaction = tx;
           
            try
            {
                command.CommandText = $"Insert into Customers (NameCustomers,PhoneNumber) values ('{Text.Text}',11)";
                command.ExecuteNonQuery();
                command.CommandText = "Insert into Customers (NameCustomers,PhoneNumber) values ('AssSd',121)";
                command.ExecuteNonQuery();
                tx.Commit();
                connection.Close();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // При возникновении любой ошибки выполняется откат транзакции.
                connection.Close();
            }
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            string Phone = string.Empty;
            connection.Open();

            using(SqlCommand cmd= new SqlCommand("GetPet",connection))
            {
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@name";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Value = "Денисюк";

                parameter = new SqlParameter();
                parameter.ParameterName = "@phone";
                parameter.Size = 10;
                parameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parameter);

                cmd.ExecuteNonQuery();
                connection.Close();
                
            }
        }
    }
}
