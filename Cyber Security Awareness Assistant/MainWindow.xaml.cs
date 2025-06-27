using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/*
 * AI Declaration
 * AI Used: ChatGPT
 * Date of knowledge: June 2024
 * Date used: 26 June 2025
 * Reason: To write to a text file and read its contents in a WPF application.
 * Prompt used: "how to read from and write to a text file in C# in a wpf application"
 * Available at: https://chatgpt.com/share/685c518b-5e70-800e-a5d5-26b31331973b 
 */

namespace Cyber_Security_Awareness_Assistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadTaskList();
        }

        private void Button_AddTask_Click(object sender, RoutedEventArgs e)
        {

            string taskTitle = TextBox_TaskTitle.Text.Trim();
            string taskDescription = TextBox_TaskDescription.Text.Trim();
            DateOnly? taskDate = DateOnly.FromDateTime(DatePicker_ReminderDate.SelectedDate ?? DateTime.Now);

            string? time = ComboBox_ReminderTime.Text?.ToString() ?? "12:00";
            TimeOnly taskTime;
            if (!TimeOnly.TryParse(time, out taskTime))
            {
                MessageBox.Show("Invalid time format. Please use HH:mm.");
                return;
            }

            string taskDetails = $"Title: {taskTitle}    Description: {taskDescription}    Date: {taskDate}    Time: {taskTime}";

            
            string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "TaskList.txt");

            try
            {
                
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filepath));

                
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine(taskDetails);
                }

                
                LoadTaskList();
                MessageBox.Show("Task added successfully!");
                ActivityLog.TasksCreated++; //incrementing the tasks created count for the activity log
                ActivityLog.activityLog.Add($"Task '{taskTitle}' created with description '{taskDescription}' on {taskDate?.ToShortDateString()} at {taskTime}.");

                if (taskDate != null)
                {
                    ActivityLog.RemindersSet++; //incrementing the reminders set count for the activity log
                    ActivityLog.activityLog.Add($"Reminder set for task '{taskTitle}' on {taskDate.Value.ToShortDateString()} at {taskTime}.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to write task: {ex.Message}");
            }

            

        }

        private void LoadTaskList()
        {
            string filePath = "Assets/TaskList.txt";
            List<string> tasks = new List<string>();

            if (File.Exists(filePath))
            {
                tasks.AddRange(File.ReadAllLines(filePath));
            }

            ListView_TaskList.ItemsSource = tasks;
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ListView_TaskList.SelectedItem is string selectedTask)
            {
                
                var tasks = ListView_TaskList.Items.Cast<string>().ToList();
                tasks.Remove(selectedTask);

                
                string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "TaskList.txt");
                File.WriteAllLines(filepath, tasks);

                
                ListView_TaskList.ItemsSource = null;
                ListView_TaskList.ItemsSource = tasks;
            }
            else
            {
                MessageBox.Show("Please select a task to delete.");
            }

        }

        private void Button_MarkCompleted_Click(object sender, RoutedEventArgs e)
        {
            if (ListView_TaskList.SelectedItem is string selectedTask)
            {
                
                if (selectedTask.Contains("[COMPLETED]")) return;

                string updatedTask = "[COMPLETED] " + selectedTask;

                
                var tasks = ListView_TaskList.Items.Cast<string>().ToList();
                int index = tasks.IndexOf(selectedTask);
                tasks[index] = updatedTask;

                
                string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "TaskList.txt");
                File.WriteAllLines(filepath, tasks);

                
                ListView_TaskList.ItemsSource = null;
                ListView_TaskList.ItemsSource = tasks;

                ActivityLog.TasksCompleted++; //incrementing the tasks completed count for the activity log
                ActivityLog.activityLog.Add($"Task '{selectedTask}' marked as completed.");
            }
            else
            {
                MessageBox.Show("Please select a task to mark as completed.");
            }

        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}