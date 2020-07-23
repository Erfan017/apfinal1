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
using System.Data.SqlClient;
using System.Data;

namespace abcd
{
    /// <summary>
    /// Interaction logic for adminlogin.xaml
    /// </summary>
    public partial class adminlogin : Window
    {
        public adminlogin()
        {
            InitializeComponent();
            // string connectionString = ConfigurationManager.ConnectionStrings[abcd.Properties.Settings.].ConnectionString;
            

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Sayan\Documents\erfanrestudb.mdf; Integrated Security = True; Connect Timeout = 30");
            sqlConnection.Open();

            string sql = "select * from adminss where (adminusername='" + userbox.Text.Trim()+"' and adminpassword='" +passbox.Password.Trim()+"')";
             SqlDataAdapter sqlDataAdapter=new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable(); 
            sqlDataAdapter.Fill(dataTable);
            

            if (dataTable.Rows.Count == 1)
            {
                adminmenu adminmenuobj = new adminmenu();
                adminmenuobj.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }




        }

    }
}
