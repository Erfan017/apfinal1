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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace abcd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void userbot_MouseLeave(object sender, MouseEventArgs e)
        {
            userbot.Foreground = Brushes.Black;
        }

        private void userbot_MouseEnter(object sender, MouseEventArgs e)
        {
            userbot.Foreground = Brushes.Red;
        }

        private void adminbot_MouseEnter(object sender, MouseEventArgs e)
        {
            adminbot.Foreground = Brushes.Red;
        }

        private void adminbot_MouseLeave(object sender, MouseEventArgs e)
        {
            adminbot.Foreground = Brushes.Black;
        }

        private void adminbot_Click(object sender, RoutedEventArgs e)
        {
            adminlogin adminloginobj = new adminlogin(); //Create object of Page2
            adminloginobj.Show(); //Show page2
            this.Close(); //this will close Page1
        }

        private void userbot_Click(object sender, RoutedEventArgs e)
        {
            customer_login customer_loginobj = new customer_login();
            customer_loginobj.Show();
            this.Close();
        }
    }
}
