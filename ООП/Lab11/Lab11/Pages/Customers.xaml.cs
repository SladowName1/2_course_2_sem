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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab11.Pages
{
    /// <summary>
    /// Логика взаимодействия для Customers.xaml
    /// </summary>
    public partial class Customers : Page
    {
        DataTable CustomersTable;
        string connectionString;
        SqlDataAdapter adapter;
        public Customers()
        {
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "Select * from Customers";
            CustomersTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                adapter.InsertCommand = new SqlCommand("sp_InsertCustomers", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@NameCustomers", SqlDbType.NVarChar, 50, "Customers"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.Int, 0, "PhoneNumber"));
                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@NameCustomers", SqlDbType.Int, 0, "Customers");
                parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(CustomersTable);
                CustomersDG.ItemsSource = CustomersTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateDB()
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(CustomersTable);
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersDG.SelectedItems != null)
            {
                for (int i = 0; i < CustomersDG.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = CustomersDG.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
        }
        private void Tran(object sender, RoutedEventArgs e)
        {
            Tran tran = new Tran();
            tran.Show();
        }
    }
}
