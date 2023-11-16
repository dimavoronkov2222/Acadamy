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
        UsersList list;
        string Usernameadmin = "Admin";
        string PassAdmin = "123456";
        public login()
        {
            InitializeComponent();
            list = new UsersList();
        }
        private void signin(object sender, RoutedEventArgs e)
        {
            string USername = usernamebox.Text;
            string Pass = passwordbox.Password;
            int role = 0;
            if (Usernameadmin == usernamebox.Text)
            {
                if (PassAdmin == Pass)
                {
                    AdminHome adminHome = new AdminHome();
                    adminHome.Show();
                }
            }
            Users user = list.GetUser(USername, Pass);
            if (user != null)
            {
                role = user.Role;
                if (role == 1)
                {
                    AdminHome adminHome = new AdminHome();
                    adminHome.Show();
                }
                else if (role == 2)
                {
                    TeaherHome teaherHome = new TeaherHome();
                    teaherHome.Show();
                }
                else if (role == 3)
                {
                    StudentHome studentHome = new StudentHome();
                    studentHome.Show();
                }
                else
                {
                    MessageBox.Show("Something went wrong", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Incorrect username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void signup(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
        }
    }
}