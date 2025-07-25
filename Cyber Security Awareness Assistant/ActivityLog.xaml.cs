﻿using System;
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
using System.Windows.Shapes;

namespace Cyber_Security_Awareness_Assistant
{
    /// <summary>
    /// Interaction logic for ActivityLog.xaml
    /// </summary>
    public partial class ActivityLog : Window
    {
        public static int QuizAttempts { get; set; }
        public static int TasksCreated { get; set; }
        public static int TasksCompleted { get; set; }
        public static int RemindersSet { get; set; }
        public static List<string> activityLog = new List<string>();
        

        

        public ActivityLog()
        {
            InitializeComponent();
            Label_QuizAttemps.Content = $"Quiz Attempts: {QuizAttempts}";
            Label_RemindersSet.Content = $"Reminders Set: {RemindersSet}";
            Label_TasksCreated.Content = $"Tasks Created: {TasksCreated}";
            Label_TasksCompleted.Content = $"Tasks Completed: {TasksCompleted}";
            ActivityList.ItemsSource = activityLog;
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
