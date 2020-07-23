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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;


namespace abcd
{
    /// <summary>
    /// Interaction logic for customer_login.xaml
    /// </summary>
    
    public partial class customer_login : Window
    {
        public customer_login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Sayan\Documents\erfanrestudb.mdf; Integrated Security = True; Connect Timeout = 30");
            sqlConnection.Open();

            string sql = "select * from customers where (email='" + userbox.Text.Trim() + "' or nationalid='"+userbox.Text.Trim()+"' and password='" + passbox.Password.Trim() + "')";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string res = string.Join(Environment.NewLine, dataTable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));
            


            if (dataTable.Rows.Count == 1)
            {
                string[] id = res.Split(';');
                allmethods.signinid = int.Parse(id[0]);
                customermenu customermenuobj = new customermenu();
                customermenuobj.Show();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }
            
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            customer_register customer_registerobj = new customer_register();
            customer_registerobj.Show();
            this.Close();
        } 
        
    }
}
