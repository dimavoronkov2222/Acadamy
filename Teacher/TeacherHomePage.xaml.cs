using Microsoft.Data.SqlClient;
using System;
using System.Data.Common;
using System.Windows;
using System.Windows.Controls;

namespace Acadamy.Teacher
{
    public partial class TeacherHomePage : Page
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AcadamyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public TeacherHomePage()
        {
            InitializeComponent();
            LoadScheduleData();
            LoadHomeworkData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string courseName = coursename.Text;
            string assignment = Assingment.Text;
            DateTime dueDate;
            if (DateTime.TryParse(DueDate.Text, out dueDate))
            {
                string teacherName = teachername.Text;
                string homeworkId = Homeworkid.Text;

                if (!string.IsNullOrEmpty(courseName) && !string.IsNullOrEmpty(assignment) && !string.IsNullOrEmpty(teacherName))
                {
                    AddHomeworkToDatabase(courseName, assignment, dueDate, teacherName, homeworkId);
                    coursename.Text = string.Empty;
                    Assingment.Text = string.Empty;
                    DueDate.Text = string.Empty;
                    teachername.Text = string.Empty;
                    Homeworkid.Text = string.Empty;
                    LoadHomeworkData();
                }
                else
                {
                    MessageBox.Show("Please fill in all the fields");
                }
            }
            else
            {
                MessageBox.Show("Invalid Due Date format. Please enter a valid date (e.g., 2022-01-01)");
            }
        }

        private void LoadHomeworkData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT HomeWorkID, CourseName, Assignment, DueDate, TeacherName FROM Homework";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DZ_LAB.ItemsSource = reader.Cast<DbDataRecord>().Select(r =>
                                new HomeworkItem(
                                    r["HomeWorkID"].ToString(),
                                    r["CourseName"].ToString(),
                                    r["Assignment"].ToString(),
                                    (DateTime)r["DueDate"],
                                    r["TeacherName"].ToString()
                                )
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading homework data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadScheduleData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CourseName, DayOfWeek, TimeSlot, TeacherName FROM Schedule";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Schedule.ItemsSource = reader.Cast<DbDataRecord>().Select(r =>
                                new ScheduleItem(
                                    r["CourseName"].ToString(),
                                    r["DayOfWeek"].ToString(),
                                    (TimeSpan)r["TimeSlot"],
                                    r["TeacherName"].ToString()
                                )
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading schedule data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddHomeworkToDatabase(string courseName, string assignment, DateTime dueDate, string teacherName, string homeworkId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Homework (HomeWorkID, CourseName, Assignment, DueDate, TeacherName) VALUES (@HomeWorkID, @CourseName, @Assignment, @DueDate, @TeacherName)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@HomeWorkID", homeworkId);
                        command.Parameters.AddWithValue("@CourseName", courseName);
                        command.Parameters.AddWithValue("@Assignment", assignment);
                        command.Parameters.AddWithValue("@DueDate", dueDate);
                        command.Parameters.AddWithValue("@TeacherName", teacherName);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Homework added to the database successfully");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add homework to the database");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding homework to the database: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class HomeworkItem
    {
        public string HomeworkID { get; set; }
        public string CourseName { get; set; }
        public string Assignment { get; set; }
        public DateTime DueDate { get; set; }
        public string TeacherName { get; set; }

        public HomeworkItem(string homeworkID, string courseName, string assignment, DateTime dueDate, string teacherName)
        {
            HomeworkID = homeworkID;
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

        public ScheduleItem(string courseName, string dayOfWeek, TimeSpan timeSlot, string teacherName)
        {
            CourseName = courseName;
            DayOfWeek = dayOfWeek;
            TimeSlot = timeSlot;
            TeacherName = teacherName;
        }
    }
}