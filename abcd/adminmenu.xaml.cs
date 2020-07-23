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
    /// Interaction logic for adminmenu.xaml
    /// </summary>
    public partial class adminmenu : Window
    {
        public adminmenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            editadminprofile editadminprofileobj = new editadminprofile();
            editadminprofileobj.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            editrestaurantinfo editrestaurantinfoobj = new editrestaurantinfo();
            editrestaurantinfoobj.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Sayan\Documents\erfanrestudb.mdf; Integrated Security = True; Connect Timeout = 30");
            sqlConnection.Open();

            string sql = "select * from factor";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string res = string.Join(Environment.NewLine, dataTable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));
            string[] komaki = res.Split('\n');
            string[] komaki2;
            int pool=0;
            for(int i = 0; i < komaki.Length; i++)
            {
                komaki2 = komaki[i].Split(';');
                pool += int.Parse(komaki2[4]);
            }
            double sood = pool-(pool / 1.24);
            MessageBox.Show("total sell:"+pool+" your profit:"+sood);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            editmenu editmenuobj = new editmenu();
            editmenuobj.Show();
            this.Close();
        }       
    }
}
