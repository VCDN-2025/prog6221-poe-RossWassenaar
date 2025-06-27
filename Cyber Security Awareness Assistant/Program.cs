using CyberSecurityAwarenessAssistant;
using Figgle;
using System;
using System.ComponentModel.Design;
using System.Windows;


namespace Cyber_Security_Awareness_Assistant
{
    /*
     * Title: Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming, 11th Edition
     * Authors: Andrew Troelsen, Philip Japikse
     * Year: 2022
     * Publication: New York: Apress
     */
    internal class Program
    {
        public static string name = "";
        public static string favouriteTopic = "";
        [STAThread]

        static void Main(string[] args)
        {
            //Initializing variables
            //string name = "name";
            string question = "";
            bool endProgram = false;
            int index = 0;
            string input = "";
            int topic = 0;
            //Console.ForegroundColor = ConsoleColor.White;
            //Creating objects
            ChatBot bot = new ChatBot();

            //Displaying the Cyber Security logo
            UXHelper.DisplayLogo();

            //Displaying the title of the program
            UXHelper.DisplayTitle();

            //Playing voice greeting audio file, using Task.Run to be able to play the audio file in the background while the program continues to run
            Task.Run(() => Greeting.PlayGreeting());

            //Prompting the user to enter their name and capturing their response
            Console.WriteLine("What is your name?");

            Console.ForegroundColor = ConsoleColor.Cyan; //changing the color of the text to cyan for better visibility
            Console.Write("You: ");
            input = Console.ReadLine();
            index = input.IndexOf(" "); //finding the index of the first space, in order to remove the text before the actual user input
            name = input.Substring(index + 1).Trim(); //capturing the user's name by removing the text before the colon and trimming any extra spaces
            Console.ForegroundColor = ConsoleColor.White;

            TaskReminderService.StartReminderMonitor(); //starting the task reminder service to monitor tasks, enables notifications for tasks

            Console.WriteLine("Out of the following list: what is your favourite cyber security topic?");
            showListOfTopics();

            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.Write($"{name}: ");
            //input = Console.ReadLine();
            //index = input.IndexOf(":");
            topic = int.Parse(acceptUserInput()); //capturing the user's favourite topic by removing the text before the colon and trimming any extra spaces
            Console.ForegroundColor = ConsoleColor.White;

            setFavouriteTopic(topic); //calling the getFavouriteTopic method to set the favourite topic

            //Console.ResetColor();
            //Clearing the console for better visibility
            Console.Clear();

            //Displaying the personalized welcoming message using the user's name
            UXHelper.DisplayWelcomeMessage(name);

            var app = new Application();
            string taskChoice = ""; //initializing taskChoice variable to capture the user's choice of task

            do
            {
                
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please select a task\n1: Chat with the chatbot\n2: Open the task assistant\n3: Play the cybersecurity quiz\n4: Open Activity Log");
                do
                {
                    
                    Console.WriteLine("Please select a task by typing in the corresponding number: (1 or 2)"); //prompting the user to select a task
                    taskChoice = acceptUserInput(); //capturing the user's choice of task
                    if (taskChoice == "2")
                    {
                        //var app = new Application();
                        var window = new MainWindow();
                        window.ShowDialog();

                        
                    }
                    else if (taskChoice == "3")
                    {
                        //var app = new Application();
                        var window = new Quiz();
                        window.ShowDialog();

                        ActivityLog.QuizAttempts++; //incrementing the quiz attempts counter for the Activity Log
                        ActivityLog.activityLog.Add($"Quiz attempted by {name} on {DateTime.Now.ToShortDateString()} at {DateTime.Now.ToShortTimeString()}.");
                    }
                    else if (taskChoice == "4")
                    {
                        var window = new ActivityLog(); //creating a new instance of the ActivityLog window
                        window.ShowDialog(); //showing the ActivityLog window
                    }
                } while (taskChoice != "1"); //looping until the user selects the chat task


                //prompting the user for a question and capturing their response
                question = bot.AskForQuestion(name);

                //checking if the question is in the dictionary and displaying the response
                if (bot.CheckDictionary("responses", question))
                {
                    //printing using the successful question format
                    bot.SuccessfulQuestion(question);


                    string answer = acceptUserInput(); //calling the acceptUserInput method to capture the user's answer

                    //ending the program if the user answers "no" to asking another question
                    if (answer.Equals("no", StringComparison.OrdinalIgnoreCase))
                    {
                        endProgram = true;
                    }
                }
                else if (question.Contains("password") || question.Contains("scam") || question.Contains("privacy"))
                {

                    string keyword = "";
                    if (question.Contains("password")) { keyword = "password"; }
                    if (question.Contains("scam")) { keyword = "scam"; }
                    if (question.Contains("privacy")) { keyword = "privacy"; }


                    if (question.Contains("worried") || question.Contains("curious") || question.Contains("frustrated"))
                    {

                        string sentiment = "";
                        if (question.Contains("worried")) { sentiment = "worried"; }
                        if (question.Contains("curious")) { sentiment = "curious"; }
                        if (question.Contains("frustrated")) { sentiment = "frustrated"; }
                        bot.sentimentResponse(sentiment);

                    }
                    bot.keywordResponse(keyword);

                    //Console.ForegroundColor = ConsoleColor.Cyan; //changing the color of the text to cyan for better visibility
                    //Console.Write($"{name}: ");
                    //input = Console.ReadLine();
                    //index = input.IndexOf(":");
                    string answer = acceptUserInput();
                    Console.ForegroundColor = ConsoleColor.White;

                    //ending the program if the user answers "no" to asking another question
                    if (answer.Equals("no", StringComparison.OrdinalIgnoreCase))
                    {
                        endProgram = true;
                    }
                }
                else
                {
                    //printing using the unsuccessful question format
                    bot.UnsuccessfulQuestion();

                    //prompting user to see a list of questions the program can answer
                    Console.WriteLine("Would you like to see a list of questions I am capable of answering?");

                    //Console.ForegroundColor = ConsoleColor.Cyan; //changing the color of the text to cyan for better visibility
                    //Console.Write($"{name}: ");
                    //input = Console.ReadLine();
                    //index = input.IndexOf(":");
                    string answer = acceptUserInput();
                    //Console.ForegroundColor = ConsoleColor.White;

                    bot.favouriteTopic(favouriteTopic);

                    //Showing a list of questions if the user answers "yes" to seeing a list of questions
                    if (answer.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        bot.ShowList();
                    }
                    else
                    {
                        //prompting the user to ask another question or ending the program
                        Console.WriteLine("Would you like to ask another question?");

                        //Console.ForegroundColor = ConsoleColor.Cyan; //changing the color of the text to cyan for better visibility
                        //Console.Write($"{name}: ");
                        //input = Console.ReadLine();
                        //index = input.IndexOf(":");
                        answer = acceptUserInput();
                        //Console.ForegroundColor = ConsoleColor.White;

                        if (answer.Equals("no", StringComparison.OrdinalIgnoreCase))
                        {
                            //ending the program if the user answers "no" to asking another question
                            endProgram = true;
                        }
                    }
                }
                //Console.Clear(); 
            } while (!endProgram); //keeps the program looping until the user decides not to answer anymore questions
        }

        public static void showListOfTopics()
        {
            int count = 1; //counter to display the list of topics
            ChatBot bot = new ChatBot();
            foreach (string topic in bot.favouriteTopics.Keys)
            {
                bot.PrintMessage($"{count}. {topic}\n");
                count++; //incrementing the counter for each topic
            }
        }

        public static void setFavouriteTopic(int topic)
        {
            string topicName = "";
            switch (topic)
            {
                case 1: topicName = "Passwords"; break;
                case 2: topicName = "Scams"; break;
                case 3: topicName = "Privacy"; break;
                case 4: topicName = "Online safety"; break;
            }
            favouriteTopic = topicName;
        }

        public static string acceptUserInput()
        {
            string input = "";
            int index = 0;
            Console.ForegroundColor = ConsoleColor.Cyan; //changing the color of the text to cyan for better visibility
            Console.Write($"{name}: ");
            input = Console.ReadLine();
            index = input.IndexOf(":");
            Console.ForegroundColor = ConsoleColor.White; //resetting the color of the text to white
            return input.Substring(index + 1).Trim().ToLower();
        }



    }
}
