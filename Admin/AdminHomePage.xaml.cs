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
        private ObservableCollection<string> listBoxItems;
        public AdminHomePage()
        {
            InitializeComponent();
            listBoxItems = new ObservableCollection<string>();
            listschool.ItemsSource = listBoxItems;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = dayOfWeekComboBox.SelectedItem as ComboBoxItem;
            string selectedText = selectedItem != null ? selectedItem.Content.ToString() : string.Empty;
            string textBoxContent = textBox.Text;
            if (!string.IsNullOrEmpty(selectedText) && !string.IsNullOrEmpty(textBoxContent))
            {
                listBoxItems.Add($"{selectedText}: {textBoxContent}");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите элемент и введите текст");
            }
        }
        private void Teacherpage(object sender, RoutedEventArgs e)
        {
            TeacherHomePage teacherHome = new TeacherHomePage();
            Grid.SetZIndex(AdminFrame, 1);
            AdminFrame.Navigate(teacherHome);
        }
        private void Studentpage(object sender, RoutedEventArgs e)
        {
            StudentHomePage studentHome = new StudentHomePage();
            Grid.SetZIndex(AdminFrame, 1);
            AdminFrame.Navigate(studentHome);
        }
    }
}
