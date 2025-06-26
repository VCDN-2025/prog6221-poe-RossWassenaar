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
using System.Windows.Shapes;

namespace Cyber_Security_Awareness_Assistant
{
    /// <summary>
    /// Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : Window
    {
        public int Score { get; set; } = 0;
        public Quiz()
        {
            InitializeComponent();
        }

        private void Button_Question1Answer1_Click(object sender, RoutedEventArgs e)
        {
            Label_Question1Result.Content = "Correct!";
            Score += 1; // Increment score for correct answer
            Label_Score.Content = $"{Score}/10"; // Update score display
            ScoreMessage();
        }

        private void ScoreMessage()
        {
            if (Score > 0)
            {
                Label_ScoreMessage.Content = "You're getting there, slowly but getting there!";
                if (Score >= 5)
                {
                    Label_ScoreMessage.Content = "Good job! You have a basic understanding of Cyber Security.";
                }
                if (Score >= 8)
                {
                    Label_ScoreMessage.Content = "Excellent! You have a strong understanding of Cyber Security.";
                }
                if (Score == 10)
                {
                    Label_ScoreMessage.Content = "Perfect! You are a Cyber Security expert!";
                }
            }
            
        }

        private void Button_Question1Answer2_Click(object sender, RoutedEventArgs e)
        {
            Label_Question1Result.Content = "Incorrect!";
            ScoreMessage();
        }

        private void Button_Question1Answer3_Click(object sender, RoutedEventArgs e)
        {
            Label_Question1Result.Content = "Incorrect!";
            ScoreMessage();
        }

        private void Button_Question2Answer1_Click(object sender, RoutedEventArgs e)
        {
            Label_Question2Result.Content = "Incorrect!";
            ScoreMessage();
        }

        private void Button_Question2Answer2_Click(object sender, RoutedEventArgs e)
        {
            Label_Question2Result.Content = "Incorrect!";
            ScoreMessage();
        }

        private void Button_Question2Answer3_Click(object sender, RoutedEventArgs e)
        {
            Label_Question2Result.Content = "Correct!";
            Score += 1; // Increment score for correct answer
            Label_Score.Content = $"{Score}/10"; // Update score display
            ScoreMessage();
        }

        private void Button_Question3AnswerTrue_Click(object sender, RoutedEventArgs e)
        {
            Label_Question3Result.Content = "Correct!";
            Score += 1; // Increment score for correct answer
            Label_Score.Content = $"{Score}/10"; // Update score display
            ScoreMessage();
        }

        private void Button_Question3AnswerFalse_Click(object sender, RoutedEventArgs e)
        {
            Label_Question3Result.Content = "Incorrect!";
            ScoreMessage();
        }

        private void Button_Question4AnswerTrue_Click(object sender, RoutedEventArgs e)
        {
            Label_Question4Result.Content = "Incorrect!";
            ScoreMessage();
        }

        private void Button_Question4AnswerFalse_Click(object sender, RoutedEventArgs e)
        {
            Label_Question4Result.Content = "Correct!";
            Score += 1; // Increment score for correct answer
            Label_Score.Content = $"{Score}/10"; // Update score display
            ScoreMessage();
        }

        private void Button_Question5AnswerTrue_Click(object sender, RoutedEventArgs e)
        {
            Label_Question5Result.Content = "Incorrect!";
            ScoreMessage();
        }

        private void Button_Question5AnswerFalse_Click(object sender, RoutedEventArgs e)
        {
            Label_Question5Result.Content = "Correct!";
            Score += 1; // Increment score for correct answer
            Label_Score.Content = $"{Score}/10"; // Update score display
            ScoreMessage();
        }

        private void Button_Question6Answer1_Click(object sender, RoutedEventArgs e)
        {
            Label_Question6Result.Content = "Correct!";
            Score += 1; // Increment score for correct answer
            Label_Score.Content = $"{Score}/10"; // Update score display
            ScoreMessage();
        }

        private void Button_Question6Answer2_Click(object sender, RoutedEventArgs e)
        {
            Label_Question6Result.Content = "Incorrect!";
            ScoreMessage();
        }

        private void Button_Question6Answer3_Click(object sender, RoutedEventArgs e)
        {
            Label_Question6Result.Content = "Incorrect!";
            ScoreMessage();
        }

        private void Button_Question7Answer1_Click(object sender, RoutedEventArgs e)
        {
            Label_Question7Result.Content = "Incorrect!";
            ScoreMessage();
        }

        private void Button_Question7Answer2_Click(object sender, RoutedEventArgs e)
        {
            Label_Question7Result.Content = "Incorrect!";
            ScoreMessage();
        }

        private void Button_Question7Answer3_Click(object sender, RoutedEventArgs e)
        {
            Label_Question7Result.Content = "Correct!";
            Score += 1; // Increment score for correct answer
            Label_Score.Content = $"{Score}/10"; // Update score display
            ScoreMessage();
        }

        private void Button_Question8Answer1_Click(object sender, RoutedEventArgs e)
        {
            Label_Question8Result.Content = "Correct!";
            Score += 1; // Increment score for correct answer
            Label_Score.Content = $"{Score}/10"; // Update score display
            ScoreMessage();
        }

        private void Button_Question8Answer2_Click(object sender, RoutedEventArgs e)
        {
            Label_Question8Result.Content = "Incorrect!";
            ScoreMessage();
        }

        private void Button_Question8Answer3_Click(object sender, RoutedEventArgs e)
        {
            Label_Question8Result.Content = "Incorrect!";
            ScoreMessage();
        }

        private void Button_Question9Answer1_Click(object sender, RoutedEventArgs e)
        {
            Label_Question9Result.Content = "Incorrect!";
            ScoreMessage();
        }

        private void Button_Question9Answer2_Click(object sender, RoutedEventArgs e)
        {
            Label_Question9Result.Content = "Correct!";
            Score += 1; // Increment score for correct answer
            Label_Score.Content = $"{Score}/10"; // Update score display
            ScoreMessage();
        }

        private void Button_Question9Answer3_Click(object sender, RoutedEventArgs e)
        {
            Label_Question9Result.Content = "Incorrect!";
            ScoreMessage();
        }

        private void Button_Question10AnswerTrue_Click(object sender, RoutedEventArgs e)
        {
            Label_Question10Result.Content = "Correct!";
            Score += 1; // Increment score for correct answer
            Label_Score.Content = $"{Score}/10"; // Update score display
            ScoreMessage();
        }

        private void Button_Question10AnswerFalse_Click(object sender, RoutedEventArgs e)
        {
            Label_Question10Result.Content = "incorrect!";
            ScoreMessage();
        }
    }
}
