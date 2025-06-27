using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyber_Security_Awareness_Assistant
{
    internal class ActivityTracker
    {
        public int QuizAttempts { get; set; }
        public int TasksCreated { get; set; }
        public int TasksCompleted { get; set; }
        public int RemindersSet { get; set; }

        List<string> ActivityLog { get; set; }

        public ActivityTracker(int quizAttempts, int tasksCompleted, int tasksCreated, int remindersSet, List<string> activityLog)
        {
            QuizAttempts = quizAttempts;
            TasksCreated = tasksCreated;
            TasksCompleted = tasksCompleted;
            RemindersSet = remindersSet;
            ActivityLog = activityLog;
        }
    }
}
