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
using System.Text.RegularExpressions;

namespace abcd
{
    /// <summary>
    /// Interaction logic for editrestaurantinfo.xaml
    /// </summary>
    public partial class editrestaurantinfo : Window
    {
        public editrestaurantinfo()
        {
            InitializeComponent();

            SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Sayan\Documents\erfanrestudb.mdf; Integrated Security = True; Connect Timeout = 30");
            sqlConnection.Open();

            string sql = "select * from restu";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string res = string.Join(Environment.NewLine, dataTable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));
            string[] natayej = res.Split(';');

            b1.Text = "the owner name is:" + natayej[1];
            b2.Text = "you are in:" + natayej[2]+ " block";
            b3.Text = "your food kind:" + natayej[3];
            b4.Text = "your menu picture location:" + natayej[4];
            b5.Text = "your exact location:" + natayej[5];
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;       
            bool flag1 = true;
            bool flag2 = true;
            bool flag3 = true;
            bool flag4 = true;
            string errormasage = "";

            
            if (!c.Text.All(Char.IsLetter))
            {
                flag = false;
                errormasage = "your name is not in coorect format ";
            }
            
           
            

            SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Sayan\Documents\erfanrestudb.mdf; Integrated Security = True; Connect Timeout = 30");
            sqlConnection.Open();

            string sql = "select * from restu";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string res = string.Join(Environment.NewLine, dataTable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));

            if (flag == false || flag1 == false || flag2 == false || flag3 == false || flag4 == false) MessageBox.Show(errormasage);
            else
            {
                SqlCommand sqlCommand;

                if (c.Text.Trim() != "")
                {
                    sql = "update restu set nameandfamily = '" + c.Text.Trim() + "' where Id = 1";
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand.ExecuteNonQuery();
                }
                if (c2.Text.Trim() != "")
                {
                    sql = "update restu set kind = '" + c2.Text.Trim() + "' where Id = 1";
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand.ExecuteNonQuery();
                }
                if (c1.Text.Trim() != "")
                {
                    sql = "update restu set block = '" + c1.Text.Trim() + "' where Id = 1";
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand.ExecuteNonQuery();

                }
                if (c3.Text.Trim() != "")
                {
                    sql = "update restu set menuimage = '" + c3.Text.Trim() + "' where Id = 1";
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand.ExecuteNonQuery();

                }
                if (c4.Text.Trim() != "")
                {
                    sql = "update restu set addres = '" + c4.Text.Trim() + "' where Id = 1";
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand.ExecuteNonQuery();

                }

                MessageBox.Show("Done!!");
                adminmenu adminmenuobj = new adminmenu();
                adminmenuobj.Show();
                this.Close();
            }



        }
    }
}
