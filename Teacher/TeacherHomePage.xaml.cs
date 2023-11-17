using Acadamy.Student;
using Azure;
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
namespace Acadamy.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherHomePage.xaml
    /// </summary>
    public partial class TeacherHomePage : Page
    {
        private ObservableCollection<string> listBoxItems;
        public TeacherHomePage()
        {
            InitializeComponent();
            listschool.ItemsSource = SharedData.Instance.ListBoxItems;
            listBoxItems = new ObservableCollection<string>();
            DZ_LAB.ItemsSource = listBoxItems;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = Group.SelectedItem as ComboBoxItem;
            string selectedText = selectedItem != null ? selectedItem.Content.ToString() : string.Empty;
            string textBoxContent = textBox.Text;
            if (!string.IsNullOrEmpty(selectedText) && !string.IsNullOrEmpty(textBoxContent))
            {
                listBoxItems.Add($"{selectedText}: {textBoxContent}");
            }
            else
            {
                MessageBox.Show("Please select an item and enter text");
            }
        }
    }
}
