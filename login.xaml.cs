using Acadamy.Admin;
using MahApps.Metro.Controls.Dialogs;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
namespace Acadamy
{
    public partial class login : Window
    {
        string adminusername = "Admin";
        string adminpass = "123456";
        string teacherusername = "Teacher";
        string teacherpass = "123456";
        string studentusername = "Student";
        string studentpass = "123456";
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
            string role = ((ComboBoxItem)this.role.SelectedItem).Content.ToString();
            if (role == "Admin" && Username == adminusername && Pass == adminpass)
            {
                AdminHomePage adminHome = new AdminHomePage();
                Grid.SetZIndex(MainFrame, 1);
                MainFrame.Navigate(adminHome);
                
            }
            else if (role == "Teacher" && Username == teacherusername && Pass == teacherpass)
            {

                Grid.SetZIndex(MainFrame, 1);
            }
            else if (role == "Student" && Username == studentusername && Pass == studentpass)
            {

                Grid.SetZIndex(MainFrame, 1);
            }
            else
            {
                MessageBox.Show("wrong login or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}