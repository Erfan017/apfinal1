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
    /// Interaction logic for editcutomerprofile.xaml
    /// </summary>
    public partial class editcutomerprofile : Window
    {
        
        public editcutomerprofile()
        {
            InitializeComponent();

            SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Sayan\Documents\erfanrestudb.mdf; Integrated Security = True; Connect Timeout = 30");
            sqlConnection.Open();

            string sql = "select * from customers where Id= " + allmethods.signinid;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string res = string.Join(Environment.NewLine, dataTable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));
            string[] natayej = res.Split(';');

            b1.Text = "your name is:" + natayej[3];
            b2.Text = "your phone number is:" + natayej[5];
            b3.Text = "your email is:" + natayej[6];
            b4.Text = "your profile picture address:" + natayej[7];
            b5.Text = "enter new password:";
            b6.Text = "re enter new password:";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string newnumber = "";
            bool flag = true;
            bool flagz = true;
            bool flag1 = true;
            bool flag2 = true;
            bool flag3 = true;
            bool flag4 = true;
            string errormasage = "";
            if (c2.Text.Trim() != "")
            {
                if (!allmethods.emailcheck(c2.Text.Trim()))
                {
                    flag = false;
                    errormasage += "The email format is not corect ";
                }
            }
            if (c1.Text.Trim() != "")
            {
                if (!allmethods.phonechecker(c1.Text.Trim(), out newnumber))
                {
                    flag1 = false;
                    errormasage += "The phone number format is not corect ";
                }
            }
            if (c4.Password.Trim() != c5.Password.Trim())
            {
                flag2 = false;
                errormasage += "paswords do not match";
            }
            

            SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Sayan\Documents\erfanrestudb.mdf; Integrated Security = True; Connect Timeout = 30");
            sqlConnection.Open();

            string sql = "select * from customers";
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
                    sql = "update customers set name = '" + c.Text.Trim() + "' where Id = "+allmethods.signinid;
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand.ExecuteNonQuery();
                }
                if (c2.Text.Trim() != "")
                {
                    sql = "update customers set email = '" + c2.Text.Trim() + "' where Id = " + allmethods.signinid;
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand.ExecuteNonQuery();
                }
                if (c1.Text.Trim() != "")
                {
                    sql = "update customers set phone = '" + newnumber + "' where Id = " + allmethods.signinid;
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand.ExecuteNonQuery();

                }
                if (c3.Text.Trim() != "")
                {
                    sql = "update customers set image = '" + c3.Text.Trim() + "' where Id = " + allmethods.signinid;
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand.ExecuteNonQuery();

                }
                if (c4.Password.Trim() != "")
                {
                    sql = "update customers set password = '" + c4.Password.Trim() + "' where Id = " + allmethods.signinid;
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataAdapter.InsertCommand.ExecuteNonQuery();

                }
                
                MessageBox.Show("Done!!");
                customermenu customermenuobj = new customermenu();
                customermenuobj.Show();
                this.Close();
            }



        }
    }
}
