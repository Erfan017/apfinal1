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
    /// Interaction logic for customer_register.xaml
    /// </summary>
    public partial class customer_register : Window
    {
        public customer_register()
        {
            InitializeComponent();
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
            
            if (phonebox.Text.Trim() != "")
            {
                if (!allmethods.phonechecker(phonebox.Text.Trim(), out newnumber))
                {
                    flag1 = false;
                    errormasage += "The phone number format is not corect ";
                }
            }
            if (emailbox.Text.Trim() != "")
            {
                if (!allmethods.emailcheck(emailbox.Text.Trim()))
                {
                    flag = false;
                    errormasage += "The email format is not corect ";
                }
            }
            
            if (passbox.Password.Trim() != passbox2.Password.Trim())
            {
                flag2 = false;
                errormasage += "paswords do not match";
            }
            if (!namebox.Text.All(Char.IsLetter))
            {
                flag3 = false;
                errormasage = "your name is not in coorect format ";
            }
            if (!allmethods.nationalidcheck(nationalbox.Text.Trim()))
            {
                flag4 = false;
                errormasage += "your national id is not in the corect format";
            }

            SqlConnection sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Sayan\Documents\erfanrestudb.mdf; Integrated Security = True; Connect Timeout = 30");
            sqlConnection.Open();

            string sql = "select * from customers";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string res = string.Join(Environment.NewLine, dataTable.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));

            if (flag == false || flag1 == false || flag2 == false || flag3 == false || flag4 == false || passbox.Password.Trim()=="" || namebox.Text.Trim()=="" || nationalbox.Text.Trim()=="" || phonebox.Text.Trim()=="" || emailbox.Text.Trim()=="") MessageBox.Show(errormasage +" or some fields are empty");
            else
            {
                SqlCommand sqlCommand;
                sql = "insert into customers (password,name,nationalid,phone,email) values('" + passbox.Password.Trim() + "','" + namebox.Text.Trim() +"','" + nationalbox.Text.Trim() +"','"+ phonebox.Text.Trim() +"','"+ emailbox.Text.Trim() + "')";
                sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);
                sqlDataAdapter.InsertCommand.ExecuteNonQuery();
            
                MessageBox.Show("Done!!");
                customer_login customer_Loginobj = new customer_login();
                customer_Loginobj.Show();
                this.Close();
            }
        }
    }
}
