using Acadamy.Student;
using Acadamy.Teacher;
using Microsoft.Data.SqlClient;
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
        private string connectionS = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AcadamyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = dayOfWeekComboBox.SelectedItem as ComboBoxItem;
            string selectedDayOfWeek = selectedItem != null ? selectedItem.Content.ToString() : string.Empty;
            string timeSlot = textBox.Text;
            string courseName = Coursename.Text;
            string teacherName = "Teacher";
            int yourScheduleID = 1;
            if (!string.IsNullOrEmpty(selectedDayOfWeek) && !string.IsNullOrEmpty(timeSlot))
            {
                string queryCheck = "SELECT COUNT(*) FROM Schedule WHERE ScheduleID = @ScheduleID";
                using (SqlCommand commandCheck = new SqlCommand(queryCheck, new SqlConnection(connectionS)))
                {
                    commandCheck.Parameters.AddWithValue("@ScheduleID", yourScheduleID);
                    int existingCount = (int)commandCheck.ExecuteScalar();
                    if (existingCount > 0)
                    {
                        yourScheduleID += 1;
                        commandCheck.Parameters["@ScheduleID"].Value = yourScheduleID;
                        existingCount = (int)commandCheck.ExecuteScalar();
                    }
                    string query = "SET IDENTITY_INSERT Schedule ON; INSERT INTO Schedule (ScheduleID, DayOfWeek, TimeSlot, CourseName, TeacherName) VALUES (@ScheduleID, @DayOfWeek, @TimeSlot, @CourseName, @TeacherName); SET IDENTITY_INSERT Schedule OFF;";
                    using (SqlCommand command = new SqlCommand(query, new SqlConnection(connectionS)))
                    {
                        command.Parameters.AddWithValue("@ScheduleID", yourScheduleID);
                        command.Parameters.AddWithValue("@DayOfWeek", selectedDayOfWeek);
                        command.Parameters.AddWithValue("@TimeSlot", timeSlot);
                        command.Parameters.AddWithValue("@CourseName", courseName);
                        command.Parameters.AddWithValue("@TeacherName", teacherName);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data saved successfully");
                        }
                        else
                        {
                            MessageBox.Show("Failed to save data");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a day of the week and enter a time slot");
            }
        }
    }
}
