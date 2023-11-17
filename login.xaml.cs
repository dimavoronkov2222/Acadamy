using Acadamy.Admin;
using Acadamy.Student;
using Acadamy.Teacher;
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

namespace Acadamy
{
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Window
    {
        string Usernameadmin = "Admin";
        string PassAdmin = "123456";
        public login()
        {
            InitializeComponent();
        }
        private void signin(object sender, RoutedEventArgs e)
        {
            string USername = usernamebox.Text;
            string Pass = passwordbox.Password;
            if (Usernameadmin == usernamebox.Text)
            {
                if (PassAdmin == Pass)
                {
                    AdminHome adminHome = new AdminHome();
                    adminHome.Show();
                }
            }
        }
        private void signup(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
        }
    }
}