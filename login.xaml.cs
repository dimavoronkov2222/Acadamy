using Acadamy.Admin;
using Acadamy.Student;
using Acadamy.Teacher;
using MahApps.Metro.Controls.Dialogs;
using MaterialDesignThemes.Wpf;
using Microsoft.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
namespace Acadamy
{
    public partial class login : Window
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AcadamyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public login()
        {
            InitializeComponent();

            ComboBoxItem item = new ComboBoxItem();
            item.Content = "Admin";
            role.Items.Add(item);

            ComboBoxItem item1 = new ComboBoxItem();
            item1.Content = "Teacher";
            role.Items.Add(item1);

            ComboBoxItem item2 = new ComboBoxItem();
            item2.Content = "Student";
            role.Items.Add(item2);
        }
        private void signin(object sender, RoutedEventArgs e)
        {
            string Username = usernamebox.Text;
            string Pass = passwordbox.Password;
            string selectedRole = ((ComboBoxItem)role.SelectedItem).Content.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE UserName=@UserName AND Password=@Password AND Role=@Role";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", Username);
                    command.Parameters.AddWithValue("@Password", Pass);
                    command.Parameters.AddWithValue("@Role", selectedRole);
                    int userCount = (int)command.ExecuteScalar();
                    if (userCount > 0)
                    {
                        switch (selectedRole)
                        {
                            case "Admin":
                                AdminHomePage adminHome = new AdminHomePage();
                                Grid.SetZIndex(MainFrame, 1);
                                MainFrame.Navigate(adminHome);
                                break;

                            case "Teacher":
                                TeacherHomePage teacherHome = new TeacherHomePage();
                                Grid.SetZIndex(MainFrame, 1);
                                MainFrame.Navigate(teacherHome);
                                break;

                            case "Student":
                                StudentHomePage studentHome = new StudentHomePage();
                                Grid.SetZIndex(MainFrame, 1);
                                MainFrame.Navigate(studentHome);
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong login or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}