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
        public SignUp()
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(passbox1.Password == passbox2.Password)
            {
                string Username = username.Text;
                string pass = passbox1.Password;
            }
            else
            {
                MessageBox.Show("Password mismatch", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
