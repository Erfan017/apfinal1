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
    /// Interaction logic for customermenu.xaml
    /// </summary>
    public partial class customermenu : Window
    {
        public customermenu()
        {
            InitializeComponent();
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Sayan\Documents\erfanrestudb.mdf; Integrated Security = True; Connect Timeout = 30");
            sqlConnection.Open();

            string sql = "select * from customers where (Id='" + allmethods.signinid + "')";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string res = string.Join(Environment.NewLine, dataTable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));
            string[] welcome = res.Split(';');
            welcomebox.Text = "welcome " + welcome[3];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            editcutomerprofile editcutomerprofileobj = new editcutomerprofile();
            editcutomerprofileobj.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            orderfood orderfoodobj = new orderfood();
            orderfoodobj.Show();
            this.Close();
        }
    }
}
