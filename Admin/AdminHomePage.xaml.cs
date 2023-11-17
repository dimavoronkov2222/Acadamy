using Acadamy.Student;
using Acadamy.Teacher;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Acadamy.Admin
{
    /// <summary>
    /// Interaction logic for AdminHomePage.xaml
    /// </summary>
    public partial class AdminHomePage : Page
    {
        public AdminHomePage()
        {
            InitializeComponent();
            listschool.ItemsSource = SharedData.Instance.ListBoxItems;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = dayOfWeekComboBox.SelectedItem as ComboBoxItem;
            string selectedText = selectedItem != null ? selectedItem.Content.ToString() : string.Empty;
            string textBoxContent = textBox.Text;
            if (!string.IsNullOrEmpty(selectedText) && !string.IsNullOrEmpty(textBoxContent))
            {
                SharedData.Instance.ListBoxItems.Add($"{selectedText}: {textBoxContent}");
            }
            else
            {
                MessageBox.Show("Please select an item and enter text");
            }
        }
    }
}
