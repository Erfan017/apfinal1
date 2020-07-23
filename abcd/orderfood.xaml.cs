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
    /// Interaction logic for orderfood.xaml
    /// </summary>
    public partial class orderfood : Window
    {
        public orderfood()
           {
            InitializeComponent();

            SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Sayan\Documents\erfanrestudb.mdf; Integrated Security = True; Connect Timeout = 30");
            sqlConnection.Open();

            string sql = "select * from food";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string res = string.Join(Environment.NewLine, dataTable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));


            string[] all2 = res.Split('\n');
            string[] all;
            for (int i = 0; i < (all2.Length); i++)
            {
                all = all2[i].Split(';');
                listView.Items.Add(new { id = all[0], name = all[1], quantity = all[2], description = all[3], price = double.Parse(all[4])*1.24 });
            }

            sql = "select * from factor where customerid="+allmethods.signinid;
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            res = string.Join(Environment.NewLine, dataTable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));

            
            all2 = res.Split('\n');
            if (all2[0] != "")
            {
                for (int i = 0; i < (all2.Length); i++)
                {

                    all = all2[i].Split(';');
                    orders.Items.Add(new { name = all[2], quantity = all[3], price = int.Parse(all[4]) });
                }
            }
            
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string food = commandbox.Text.Trim();
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Sayan\Documents\erfanrestudb.mdf; Integrated Security = True; Connect Timeout = 30");
            sqlConnection.Open();

            string sql = "select * from factor where food='" + food + "' and customerid=" + allmethods.signinid;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string res = string.Join(Environment.NewLine, dataTable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));
            

            if (dataTable.Rows.Count == 1)
            {               
                string[] komaki = res.Split(';');
                sql = "select * from food where foodname='" + food + "'";                
                sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                res = string.Join(Environment.NewLine, dataTable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));               

                string[] komaki2 = res.Split(';');
                int quantitynew = int.Parse(komaki[3]) + int.Parse(komaki2[2]);

                sql = "update food set foodquantity = "+quantitynew+" where Id = "+komaki2[0];
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                sqlDataAdapter.InsertCommand.ExecuteNonQuery();

                sql = "delete from factor where food='" + food + "' and customerid="+allmethods.signinid;
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                command.ExecuteNonQuery();

                orderfood orderfoodobj = new orderfood();
                orderfoodobj.Show();
                this.Close();

            }
            else MessageBox.Show("didnt find a match");
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string[] komaki = commandbox.Text.Trim().Split(';');

            SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Sayan\Documents\erfanrestudb.mdf; Integrated Security = True; Connect Timeout = 30");
            sqlConnection.Open();

            string sql = "select * from food";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string res = string.Join(Environment.NewLine, dataTable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));

            bool flag = false;
            string[] all2 = res.Split('\n');
            string[] all;
            int mojoodi=-1;
            double gheymat=0;
            try
            {
                for (int i = 0; i < (all2.Length); i++)
                {
                    all = all2[i].Split(';');
                    if (all[1].Trim() == komaki[0])
                    {
                        mojoodi =int.Parse(all[2]);
                        gheymat = int.Parse(all[4])*1.24;
                        flag = true;
                    }
                }

                int.Parse(komaki[1]);
                
                if (flag == true && komaki.Length == 2 && komaki[0] != "" && mojoodi >= int.Parse(komaki[1]) && int.Parse(komaki[1])>0)
                {
                    sql = "select * from factor where (food='" + komaki[0] + "' and customerid= " +allmethods.signinid+")";                    
                    sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                    dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count == 1) int.Parse("hi");

                    SqlCommand sqlCommand;
                    sql = "insert into factor (customerid,food,quantity,price) values(" + allmethods.signinid + ",'" + komaki[0] + "'," + int.Parse(komaki[1]) + ","+ (gheymat* int.Parse(komaki[1])) +")";
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand.ExecuteNonQuery();

                    sql = "update food set foodquantity = "+(mojoodi-int.Parse(komaki[1]))+" where foodname = '"+komaki[0]+"'";
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand.ExecuteNonQuery();

                    orderfood orderfoodobj = new orderfood();
                    orderfoodobj.Show();
                    this.Close();
                }
                else MessageBox.Show("input is not valid");
            }
            catch (Exception)
            {
                MessageBox.Show("input is not valid");
            }



        }




        

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            customermenu customermenuobj = new customermenu();
            customermenuobj.Show();
            this.Close();
        }
    }
}
