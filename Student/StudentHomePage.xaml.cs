using Microsoft.Data.SqlClient;
using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
namespace Acadamy.Student
{
    public partial class StudentHomePage : Page
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AcadamyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public StudentHomePage()
        {
            InitializeComponent();
            LoadHomeworkData();
        }
        private void LoadHomeworkData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CourseName, Assignment, DueDate, TeacherName FROM Homework";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            ObservableCollection<HomeworkItem> homeworkItems = new ObservableCollection<HomeworkItem>();
                            while (reader.Read())
                            {
                                string courseName = reader["CourseName"].ToString();
                                string assignment = reader["Assignment"].ToString();
                                DateTime dueDate = (DateTime)reader["DueDate"];
                                string teacherName = reader["TeacherName"].ToString();
                                homeworkItems.Add(new HomeworkItem(courseName, assignment, dueDate, teacherName));
                            }
                            DZ_LAB.ItemsSource = homeworkItems;
                        }
                    }
                    string query1 = "SELECT DayOfWeek, CourseName, TimeSlot, TeacherName FROM Schedule";
                    using (SqlCommand command = new SqlCommand(query1, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            ObservableCollection<ScheduleItem> ScheduleItems = new ObservableCollection<ScheduleItem>();
                            while (reader.Read())
                            {
                                string dayofweek = reader["DayOfWeek"].ToString();
                                string courseName = reader["CourseName"].ToString();
                                TimeSpan timeslot = (TimeSpan)reader["TimeSlot"];
                                string teacherName = reader["TeacherName"].ToString();
                                ScheduleItems.Add(new ScheduleItem(dayofweek, courseName, timeslot, teacherName));
                            }
                            Schedule.ItemsSource = ScheduleItems;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading homework data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    public class HomeworkItem
    {
        public string CourseName { get; set; }
        public string Assignment { get; set; }
        public DateTime DueDate { get; set; }
        public string TeacherName { get; set; }

        public HomeworkItem(string courseName, string assignment, DateTime dueDate, string teacherName)
        {
            CourseName = courseName;
            Assignment = assignment;
            DueDate = dueDate;
            TeacherName = teacherName;
        }
    }
    public class ScheduleItem
    {
        public string CourseName { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan TimeSlot { get; set; }
        public string TeacherName { get; set; }

        public ScheduleItem(string courseName, string dayofweek, TimeSpan timeslot, string teacherName)
        {
            CourseName = courseName;
            DayOfWeek = dayofweek;
            TimeSlot = timeslot;
            TeacherName = teacherName;
        }
    }
}