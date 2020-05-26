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
    /// Логика взаимодействия для Orders.xaml
    /// </summary>

    public partial class Orders : Page
    {
        DataTable OrdersTable;
        string connectionString;
        SqlDataAdapter adapter;
        public Orders()
        {
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "Select * from Orders";
            OrdersTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                adapter.InsertCommand = new SqlCommand("sp_InsertOrder", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdOrders", SqlDbType.Int, 0, "Id"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@NameCustomers", SqlDbType.NVarChar, 50, "Customers"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Products", SqlDbType.NVarChar, 50, "Products"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Photo", "Photo"));
                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@IdOrders", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(OrdersTable);
                OrdersDG.ItemsSource = OrdersTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateDB()
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(OrdersTable);
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersDG.SelectedItems != null)
            {
                for (int i = 0; i < OrdersDG.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = OrdersDG.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
        }
    }
}
