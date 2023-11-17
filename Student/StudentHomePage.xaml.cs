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

namespace Acadamy.Student
{
    /// <summary>
    /// Interaction logic for StudentHomePage.xaml
    /// </summary>
    public partial class StudentHomePage : Page
    {
        public StudentHomePage()
        {
            InitializeComponent();
            listschool.ItemsSource = SharedData.Instance.ListBoxItems;
            DZ_LAB.ItemsSource = SharedData.Instance.ListBoxItems;
        }
    }
}
