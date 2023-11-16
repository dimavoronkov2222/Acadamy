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
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        UsersList list;
        public SignUp()
        {
            InitializeComponent();
            list = new UsersList();
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(passbox1.Password == passbox2.Password)
            {
                string Username = username.Text;
                string pass = passbox1.Password;
                int roleuser = 0;
                string selectedText = null;
                if (role.SelectedItem != null)
                {
                    ComboBoxItem selectedItem = (ComboBoxItem)role.SelectedItem;
                    selectedText = selectedItem.Content.ToString();
                    if(selectedText == "Admin")
                    {
                        roleuser = 1;
                        list.AddUser(new Users(Username, pass, roleuser));
                    }
                    else if (selectedText == "Teacher")
                    {
                        roleuser = 2;
                        list.AddUser(new Users(Username, pass, roleuser));
                    }
                    else if(selectedText == "Student")
                    {
                        roleuser = 3;
                        list.AddUser(new Users(Username, pass, roleuser));
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                if (list.users.Count > 0)
                {
                    MessageBox.Show("В списке есть пользователи.");
                }
                else
                {
                    Console.WriteLine("Список пользователей пуст.");
                }
            }
            else
            {
                MessageBox.Show("Password mismatch", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}