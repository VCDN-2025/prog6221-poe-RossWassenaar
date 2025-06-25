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
            DateOnly taskDate = DateOnly.FromDateTime(DatePicker_ReminderDate.SelectedDate ?? DateTime.Now);

            string time = ComboBox_ReminderTime.Text?.ToString() ?? "12:00";
            TimeOnly taskTime;
            if (!TimeOnly.TryParse(time, out taskTime))
            {
                MessageBox.Show("Invalid time format. Please use HH:mm.");
                return;
            }

            string taskDetails = $"Title: {taskTitle}    Description: {taskDescription}    Date: {taskDate}    Time: {taskTime}";

            // Build a full path to the Assets folder regardless of where the app runs
            string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "TaskList.txt");

            try
            {
                // Ensure the Assets directory exists (just in case)
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filepath));

                // Append to the file
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine(taskDetails);
                }

                // Optional: refresh the task list to show the new entry
                LoadTaskList();
                MessageBox.Show("Task added successfully!");
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
                // Remove from ListView
                var tasks = ListView_TaskList.Items.Cast<string>().ToList();
                tasks.Remove(selectedTask);

                // Update the file
                string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "TaskList.txt");
                File.WriteAllLines(filepath, tasks);

                // Refresh the ListView
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
                // Avoid marking the same task twice
                if (selectedTask.Contains("[COMPLETED]")) return;

                string updatedTask = "[COMPLETED] " + selectedTask;

                // Update the list
                var tasks = ListView_TaskList.Items.Cast<string>().ToList();
                int index = tasks.IndexOf(selectedTask);
                tasks[index] = updatedTask;

                // Update the file
                string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "TaskList.txt");
                File.WriteAllLines(filepath, tasks);

                // Refresh the ListView
                ListView_TaskList.ItemsSource = null;
                ListView_TaskList.ItemsSource = tasks;
            }
            else
            {
                MessageBox.Show("Please select a task to mark as completed.");
            }

        }
    }
}