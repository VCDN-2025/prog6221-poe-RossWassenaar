using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;

namespace CyberSecurityAwarenessAssistant
{
    public static class TaskReminderService
    {
        private static readonly List<ReminderTask> taskList = new();
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "TaskList.txt");
        private static System.Timers.Timer reminderTimer;

        public static void StartReminderMonitor()
        {
            LoadTasks();

            reminderTimer = new System.Timers.Timer(10000); // Check every 10 seconds
            reminderTimer.Elapsed += CheckReminders;
            reminderTimer.AutoReset = true;
            reminderTimer.Enabled = true;

            Console.WriteLine("Reminder monitor is running...");
        }

        private static void LoadTasks()
        {
            taskList.Clear();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Task list file not found.");
                return;
            }

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('\t');
                if (parts.Length < 4) continue;

                string title = parts[0].Replace("Title: ", "").Trim();
                string description = parts[1].Replace("Description: ", "").Trim();
                string dateStr = parts[2].Replace("Date: ", "").Trim();
                string timeStr = parts[3].Replace("Time: ", "").Trim();

                if (DateTime.TryParse($"{dateStr} {timeStr}", out DateTime reminderTime))
                {
                    taskList.Add(new ReminderTask
                    {
                        Title = title,
                        Description = description,
                        ReminderTime = reminderTime
                    });
                }
            }
        }

        private static void CheckReminders(object sender, ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;

            foreach (var task in taskList.Where(t => !t.IsNotified && t.ReminderTime <= now))
            {
                Console.WriteLine($"\n Reminder: {task.Title}\n{task.Description}\n {task.ReminderTime}\n");
                task.IsNotified = true;
            }
        }

        private class ReminderTask
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime ReminderTime { get; set; }
            public bool IsNotified { get; set; } = false;
        }
    }
}
