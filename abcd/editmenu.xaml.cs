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
    /// Interaction logic for editmenu.xaml
    /// </summary>
    public partial class editmenu : Window
    {
        public editmenu()
        {
            InitializeComponent();

            SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Sayan\Documents\erfanrestudb.mdf; Integrated Security = True; Connect Timeout = 30");
            sqlConnection.Open();

            string sql = "select * from food";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string res = string.Join(Environment.NewLine, dataTable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));

            
            string []all2 = res.Split('\n');
            string[] all;
            for (int i = 0; i < (all2.Length); i++)
            {
                all = all2[i].Split(';');
                listView.Items.Add(new { id = all[0], name = all[1],quantity=all[2],description=all[3],price=all[4]});
            }


            

            
            
        }

       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string food=commandbox.Text.Trim();
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Sayan\Documents\erfanrestudb.mdf; Integrated Security = True; Connect Timeout = 30");
            sqlConnection.Open();

            string sql = "select * from food where foodname='"+food+"'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string res = string.Join(Environment.NewLine, dataTable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));

            if (dataTable.Rows.Count==1)
            {
                sql = "DELETE FROM food WHERE foodname = '"+food+"'";
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                command.ExecuteNonQuery();
                editmenu editmenuobj = new editmenu();
                editmenuobj.Show();
                this.Close();

            } 
            else MessageBox.Show("didnt found a match");
            //DELETE FROM table_name WHERE condition
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string[] komaki= commandbox.Text.Trim().Split(';');

            SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Sayan\Documents\erfanrestudb.mdf; Integrated Security = True; Connect Timeout = 30");
            sqlConnection.Open();

            string sql = "select * from food";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string res = string.Join(Environment.NewLine, dataTable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));

            bool flag = true;
            string[] all2 = res.Split('\n');
            string[] all;

            try
            {
                    for (int i = 0; i < (all2.Length); i++)
                    {
                        all = all2[i].Split(';');
                        if (all[1].Trim() == komaki[0])
                        {
                            flag = false;
                        }                      
                    }
                int.Parse(komaki[1]);
                int.Parse(komaki[3]);
                if(flag==true && komaki.Length == 4 && komaki[0]!="" && int.Parse(komaki[1]) >=0 && komaki[2] != "" && komaki[3] != "")
                {

                    SqlCommand sqlCommand;
                    sql = "insert into food (foodname,foodquantity,description,price) values('" + komaki[0] + "','" + komaki[1] + "','" + komaki[2] + "','" + komaki[3] + "')";
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand.ExecuteNonQuery();

                    editmenu editmenuobj = new editmenu();
                    editmenuobj.Show();
                    this.Close();
                }
                else MessageBox.Show("input is not valid");
            }
            catch (Exception)
            {
                MessageBox.Show("input is not valid");
            }

            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            adminmenu adminmenuobj = new adminmenu();
            adminmenuobj.Show();
            this.Close();
        }
    }
}
