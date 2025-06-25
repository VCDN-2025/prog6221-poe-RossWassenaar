using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cyber_Security_Awareness_Assistant
{
    /*
    * Title: Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming, 11th Edition
    * Authors: Andrew Troelsen, Philip Japikse
    * Year: 2022
    * Publication: New York: Apress
    */

    /*
     * AI Usage
     * Purpose: generating responses to follow-up questions, specifically for the question "why is this important?"
     * AI Used: ChatGPT
     * Year of knowledge: April 2024
     * Prompt: "Can you come up with responses to the user asking "why is this important" to each of these responses:..."
     * Available at: https://chatgpt.com/share/683482a0-2834-800e-8c9d-cfe45baae526
     */
    internal class ChatBot
    {
        //Creating a dictionary to store the questions and their corresponding answers
        public Dictionary<string, List<string>> responses = new Dictionary<string, List<string>>
                {
                    { "how are you", ["I am doing well, thank you for asking!",
                        "I'm great, thanks for checking in!",
                        "I'm doing well! How about you?" ] },
                    { "what is your purpose", ["I am here to help you with your cyber security awareness.",
                        "I’m here to assist you with cybersecurity and online safety.",
                        "My purpose is to help you stay informed and protected in the digital world."] },
                    { "what can i ask you about", ["You can ask me about cyber security tips, best practices, and common threats.",
                        "Feel free to ask me about cybersecurity, online safety, and digital threats.",
                        "You can ask me about protecting your devices, securing your accounts, and identifying online risks."] },
                    { "what is a computer virus",  ["A computer virus is a type of malicious software (malware) that can attach itself to legitimate programs and self-replicate, spreading from one computer to another.",
                        "A computer virus is a malicious program that spreads by attaching itself to files and programs.",
                        "It’s a type of malware that replicates and infects systems, often causing damage or data loss." ] },
                    { "what is a firewall", ["A firewall is a network security device that monitors and controls incoming and outgoing network traffic based on predetermined security rules.",
                        "A firewall acts as a protective barrier between your network and potential threats.",
                        "It's a security tool that filters and blocks malicious traffic to safeguard your devices." ] },
                    { "what is social engineering", ["Social engineering is the psychological manipulation of people into performing actions or divulging confidential information.",
                        "Social engineering manipulates people into revealing confidential information or taking harmful actions.",
                        "It’s a deceptive tactic used by cybercriminals to trick individuals into compromising security." ] },
                    { "what is a ddos attack", ["A Distributed Denial of Service (DDoS) attack is an attempt to make an online service unavailable by overwhelming it with traffic from multiple sources.",
                        "A DDoS attack overwhelms a network or website with excessive traffic, rendering it unavailable.",
                        "It’s a cyber attack that floods a system with requests, disrupting normal operations." ] },
                    { "what is phishing", ["Phishing is a cyber attack that uses disguised email as a weapon. The goal is to trick the email recipient into believing that the message is something they want or need, such as a request from their bank or a note from someone in their company.",
                        "Phishing is a scam where attackers impersonate trusted sources to steal sensitive information.",
                        "It’s a deceptive technique used to trick people into revealing personal or financial details." ] },
                    { "what is malware", ["Malware is software designed to disrupt, damage, or gain unauthorized access to computer systems.",
                        "Malware refers to harmful software designed to disrupt or damage computer systems.",
                        "It's malicious code that can steal, corrupt, or exploit data on a device." ] },
                    { "what is ransomware", ["Ransomware is a type of malicious software that encrypts files on a device, rendering them inaccessible until a ransom is paid.",
                        "Ransomware locks or encrypts files, demanding payment for their release.",
                        "It’s malware that holds your data hostage until a ransom is paid." ] },
                    { "what is two-factor authentication", ["Two-factor authentication (2FA) is an extra layer of security used to ensure that people trying to gain access to an online account are who they say they are.",
                        "2FA enhances security by requiring two forms of verification to access an account.",
                        "It’s an added layer of protection that reduces the risk of unauthorized access." ] },
                    { "what is a strong password", ["A strong password is a password that is difficult for others to guess, typically containing a mix of letters, numbers, and symbols.",
                        "A strong password is complex, unique, and difficult for hackers to guess.",
                        "It should include a mix of uppercase and lowercase letters, numbers, and symbols." ] },
                    { "what is a vpn", ["A VPN, or Virtual Private Network, allows you to create a secure connection to another network over the Internet.",
                        "A VPN encrypts your internet connection, keeping your online activity private and secure.",
                        "It’s a tool that protects your data by routing it through a secure server." ] },
                    { "what is encryption", ["Encryption is the process of converting information or data into a code to prevent unauthorized access.",
                        "Encryption scrambles data into unreadable code to prevent unauthorized access.",
                        "It’s a security technique that ensures only authorized parties can read sensitive information." ] },
                    { "what is a data breach", ["A data breach is an incident where unauthorized access to sensitive, protected, or confidential data occurs.",
                        "A data breach occurs when hackers gain unauthorized access to private information.",
                        "It’s a security incident where confidential data is exposed or stolen." ] },
                    { "what is identity theft", ["Identity theft is the act of obtaining and using someone else's personal information, such as their name, social security number, or credit card number, without their permission.",
                        "Identity theft happens when someone steals personal information for fraudulent purposes.",
                        "It’s a crime where a person's details are misused for financial or legal exploitation." ] },
                    { "what is a secure website", ["A secure website is one that uses HTTPS (Hypertext Transfer Protocol Secure) to encrypt data exchanged between the user's browser and the server.",
                        "A secure website uses HTTPS encryption to protect data exchanged between users and servers.",
                        "It ensures safe communication by encrypting sensitive information, like passwords and payments." ] },
                    { "what is a botnet", ["A botnet is a network of computers infected with malware and controlled as a group without the owners' knowledge.",
                        "A botnet is a group of compromised computers controlled remotely for malicious activities.",
                        "It’s a network of infected devices used to launch cyber attacks or distribute malware." ] },
                    { "what is a zero-day exploit", ["A zero-day exploit is a cyber attack that occurs on the same day a weakness is discovered in software.",
                        "A zero-day exploit targets vulnerabilities before developers can issue a security patch.",
                        "It’s an attack that takes advantage of undiscovered software flaws." ] },
                    { "what should i do if i think my computer has a virus", ["If you suspect your computer has a virus, run a full system scan with your antivirus software and follow its recommendations.",
                        "Run a full antivirus scan and disconnect from the internet to prevent further infection.",
                        "Use reputable security software to detect and remove any threats." ] },
                    { "how can i protect my personal information online", ["To protect your personal information online, use strong passwords, enable two-factor authentication, and be cautious about sharing sensitive information.",
                        "Avoid sharing sensitive details publicly and use privacy settings wisely.",
                        "Keep your passwords secure and be cautious when clicking on links or downloading files." ] },
                    { "what is the best way to back up my data", ["The best way to back up your data is to use a combination of local and cloud storage solutions.",
                        "Regularly back up files to an external drive and cloud storage for redundancy.",
                        "Use automated backup solutions to ensure your data is protected from loss or corruption." ] },
                    { "what should i do if i receive a suspicious email", ["If you receive a suspicious email, do not click on any links or download attachments. Report it as spam or phishing.",
                        "Ignore unexpected emails requesting personal information and report them as phishing.",
                        "Verify the sender before responding and never click on unknown links or attachments." ] },
                    { "how often should i update my software", ["You should update your software regularly, ideally as soon as updates are available.",
                        "Install updates as soon as they are available to keep your system secure.",
                        "Regular updates patch vulnerabilities and improve overall performance." ] },
                    { "what is the purpose of antivirus software", ["Antivirus software is designed to detect, prevent, and remove malware from your computer.",
                        "Antivirus software detects, prevents, and removes malicious programs from your computer.",
                        "It safeguards your system against threats like viruses, trojans, and spyware." ] },
                    { "how can i recognize a secure website", ["You can recognize a secure website by looking for 'https://' in the URL and a padlock icon in the address bar.",
                        "Look for a padlock icon in the address bar and ensure the URL starts with 'https://'.",
                        "Check for security certificates and avoid sites with outdated encryption methods." ] },
                    { "what is the importance of regular software updates", ["Regular software updates are important because they fix security vulnerabilities and improve performance.",
                        "Updates fix security weaknesses and protect against new cyber threats.",
                        "Keeping software updated ensures optimal functionality and minimizes risks." ] },
                    { "how can i avoid falling for social engineering attacks", ["To avoid falling for social engineering attacks, be cautious about sharing personal information and verify requests through trusted channels.",
                        "Be skeptical of unsolicited requests for personal information and always verify sources.",
                        "Stay vigilant and educate yourself about common social engineering techniques."] }
                };

        //Creating a dictionary to store non question responses
        public Dictionary<string, List<string>> nonQuestionResponses = new Dictionary<string, List<string>>
            {
                { "password", [ "A strong password is your first line of defense! Use a mix of letters, numbers, and symbols, and avoid using the same password for multiple accounts.",
                    "Your password is like the lock on your digital door—make it strong! Use a combination of characters and never reuse passwords across accounts.",
                    "A good password is tough to crack but easy to remember! Consider using a passphrase or a password manager to keep your accounts secure" ] },
                { "scam", [ "Scams can be sneaky, but knowing what to look for helps! Stay cautious of suspicious links and messages. If something feels off, it's worth double-checking.",
                    "Scammers are always evolving their tricks, so stay alert! If a deal or message seems too good to be true, it probably is.",
                    "Avoid falling for scams by verifying sources before sharing information or clicking on links. When in doubt, take a step back and investigate" ] },
                { "privacy", [ "Keeping your personal information safe is important! Always be mindful of what you share online.",
                    "Your personal data is valuable—protect it by using strong privacy settings and limiting what you share publicly.",
                    "Online privacy starts with awareness! Be cautious with the information you post and adjust your settings to control what others can see" ] }
            };

        public Dictionary<string, List<string>> sentimentResponses = new Dictionary<string, List<string>>
            {
                { "worried", [ "It's normal to feel worried or concerned about this. Let me share some helpful information with you so you will be better equipped. ",
                    "Feeling worried is completely understandable. Let’s explore this together so you can feel more confident moving forward.",
                    "Concern is natural, but knowledge is power! I’ll provide insights to help ease your worries." ] },
                { "curious", [ "It's an interesting topic, isn't it. Let's dive deeper and improve our understanding... ",
                    "Curiosity is the key to learning! Let’s dig deeper and uncover more details about this topic.",
                    "Great question! Let’s explore the fascinating aspects of this subject and broaden our understanding." ] },
                { "frustrated", [ "I understand how you feel, it can be incredibly frustrating. Let's go over some useful information to better understand this topic. ",
                    "That frustration is valid, and I’m here to help clarify things. Let’s break this down together and find a way forward.",
                    "It’s tough when things don’t go as expected. Let’s take a closer look at the situation and find a helpful solution." ] }
            };

        public Dictionary<string, List<string>> favouriteTopics = new Dictionary<string, List<string>>
            {
                { "Passwords", ["Passwords are crucial for protecting your accounts. A strong password is your first line of defense!"] },
                { "Scams", ["Scams can be sneaky, but knowing what to look for helps!"] },
                { "Privacy", ["Keeping your personal information safe is important!"] },
                { "Online safety", ["Online safety is crucial to protect yourself from threats."] }
            };

        //Follow Up Question answers: the user asks why is this important?
        public Dictionary<string, string> whyResponses = new Dictionary<string, string>
        {
            { "how are you", "Because it's important to let you know I'm functioning properly and ready to help!" },
            { "what is your purpose", "Because having a clear purpose helps guide how I assist you effectively." },
            { "what can i ask you about", "Because understanding what you can ask helps you get the most relevant and helpful information." },
            { "what is a computer virus", "Because knowing what a computer virus is helps you recognize and avoid threats." },
            { "what is a firewall", "Because firewalls are a fundamental defense mechanism in cybersecurity." },
            { "what is social engineering", "Because understanding social engineering helps you avoid being tricked or manipulated." },
            { "what is a ddos attack", "Because DDoS attacks can disrupt services, and it's important to recognize the threat." },
            { "what is phishing", "Because phishing is a common and dangerous cyber threat you need to be aware of." },
            { "what is malware", "Because malware can compromise your data and security if you're not cautious." },
            { "what is ransomware", "Because ransomware can lock your files and demand payment, understanding it helps you prevent attacks." },
            { "what is two-factor authentication", "Because 2FA greatly improves account security by adding another layer of verification." },
            { "what is a strong password", "Because a strong password helps protect your accounts from unauthorized access." },
            { "what is a vpn", "Because a VPN protects your online privacy by encrypting your internet connection." },
            { "what is encryption", "Because encryption secures your data so unauthorized people can’t read it." },
            { "what is a data breach", "Because data breaches can expose sensitive information, leading to identity theft or worse." },
            { "what is identity theft", "Because identity theft can have serious financial and legal consequences." },
            { "what is a secure website", "Because recognizing secure websites helps protect your personal and financial data online." },
            { "what is a botnet", "Because botnets are used in large-scale attacks and it's important to keep your device from being part of one." },
            { "what is a zero-day exploit", "Because zero-day exploits are dangerous and hard to detect until damage is done." },
            { "what should i do if i think my computer has a virus", "Because acting quickly can stop the virus from spreading or causing more damage." },
            { "how can i protect my personal information online", "Because taking steps to protect your information can prevent identity theft and fraud." },
            { "what is the best way to back up my data", "Because having backups ensures you won’t lose important files during a crash or attack." },
            { "what should i do if i receive a suspicious email", "Because handling suspicious emails correctly can prevent phishing or malware infections." },
            { "how often should i update my software", "Because frequent updates fix vulnerabilities that attackers could exploit." },
            { "what is the purpose of antivirus software", "Because antivirus software protects your system against malicious threats." },
            { "how can i recognize a secure website", "Because knowing what to look for helps you avoid fake or unsafe websites." },
            { "what is the importance of regular software updates", "Because updates patch vulnerabilities and help keep your system secure." },
            { "how can i avoid falling for social engineering attacks", "Because awareness and caution are your best defense against manipulation and deception." },
            { "password", "Because strong and unique passwords help prevent unauthorized access to your accounts." },
            { "scam", "Because recognizing scams early can save you from financial loss or stolen information." },
            { "privacy", "Because protecting your privacy reduces the risk of identity theft and misuse of your personal information." },
            { "worried", "Because addressing your concerns with the right information can help reduce anxiety and increase awareness." },
            { "curious", "Because curiosity drives learning and leads to better understanding of important topics." },
            { "frustrated", "Because frustration often means there's a gap in knowledge or clarity, and I'm here to help bridge that." }
        };


        //PrintMessage method that prints a message with the typing effect
        public void PrintMessage(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(30);
            }
        }

        //AskForQuestion method that asks the user for a question and captures their response
        public string AskForQuestion(string name)
        {
            int index = 0;
            string input = "";
            string question = "";

            //Spacing
            Console.WriteLine();

            //asking the user for a question they have about cyber security and capturing their question
            Console.ResetColor();
            //Console.WriteLine("What is your question about cyber-security?\nI am happy to help you with anything you need to know:");
            Console.WriteLine("What is your question about cyber-security?\nI am happy to help you with anything you need to know:");


            Console.ForegroundColor = ConsoleColor.Cyan; //changing the color of the text to cyan for better visibility
            Console.Write($"{name}: ");
            input = Console.ReadLine();
            index = input.IndexOf(":"); //finding the index of the first space, in order to remove the text before the actual user input
            question = input.Substring(index + 1).Trim();
            question = question.ToLower();
            if (question.EndsWith("?"))
            {
                question = question.Substring(0, question.Length - 1);
            }
            return question;
        }

        //SuccessfulQuestion method that displays the response to the user's question
        public void SuccessfulQuestion(string question)
        {
            Console.WriteLine();

            //changing the text color to green for better visibility
            Console.ForegroundColor = ConsoleColor.Green;

            Random random = new Random();
            string randomResponse = responses[question][random.Next(responses[question].Count)];

            PrintMessage(randomResponse);

            Console.WriteLine();

            //changing the text color back to white
            Console.ResetColor();

            Console.WriteLine();

            followUp(question);

            Console.WriteLine();

            favouriteTopic(Program.favouriteTopic);

            Console.WriteLine();

            Console.WriteLine("Would you like to ask another question?");


        }

        //UnsuccessfulQuestion method that displays a message when the question is not found in the dictionary
        public void UnsuccessfulQuestion()
        {
            Console.WriteLine();
            //changing color to red for visibility and better understanding that the program did not understand the question
            Console.ForegroundColor = ConsoleColor.Red;

            PrintMessage("I'm sorry, I don't have an answer for that question.");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

            favouriteTopic(Program.favouriteTopic);

            Console.WriteLine();

        }

        //ShowList method that displays a list of questions the program can answer
        public void ShowList()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            //Title for the list of questions
            string message = "QUESTIONS\n" +
            "===============================================================\n";
            foreach (string possibleQuestion in responses.Keys)
            {
                message += possibleQuestion + "\n";
            }
            message += "===============================================================";

            PrintMessage(message);

            Console.WriteLine();

            //Console.WriteLine("QUESTIONS");

            ////Showing a basic border for readability
            //Console.WriteLine("===============================================================");

            //foreach (string possibleQuestion in responses.Keys)
            //{
            //    Console.WriteLine(possibleQuestion);
            //}
            ////Showing a bottom border
            //Console.WriteLine("===============================================================");
        }

        //CheckDictionary method that checks if the question is a key in the dictionary
        public bool CheckDictionary(string dictionary, string question)
        {
            bool inDictionary = false;
            switch (dictionary)
            {
                case "responses":
                    //checking if the question is in the dictionary and displaying the response
                    if (responses.ContainsKey(question))
                    {
                        //return true;
                        inDictionary = true;
                    }
                    //else
                    //{
                    //    return false;
                    //}
                    break;
                case "nonQuestionResponses":
                    if (nonQuestionResponses.ContainsKey(question))
                    {
                        inDictionary = true;
                    }
                    //else
                    //{
                    //    return false;
                    //}
                    break;
                case "sentimentResponses":
                    if (sentimentResponses.ContainsKey(question))
                    {
                        inDictionary = true;
                    }
                    //else
                    //{
                    //    return false;
                    //}
                    break;
                default:
                    inDictionary = false;
                    break;
            }
            return inDictionary;
        }

        public void keywordResponse(string keyword)
        {
            string response = "";

            Random random = new Random();
            string randomResponse = nonQuestionResponses[keyword][random.Next(nonQuestionResponses[keyword].Count)];

            response = randomResponse;

            Console.WriteLine();

            //changing the text color to green for better visibility
            Console.ForegroundColor = ConsoleColor.Green;

            PrintMessage(response);

            Console.WriteLine();

            //changing the text color back to white
            Console.ResetColor();

            Console.WriteLine();

            followUp(keyword);

            Console.WriteLine();

            favouriteTopic(Program.favouriteTopic);

            Console.WriteLine();

            Console.WriteLine("Would you like to ask another question?");

        }

        public void sentimentResponse(string sentiment)
        {
            string response = "";

            Random random = new Random();
            string randomResponse = sentimentResponses[sentiment][random.Next(sentimentResponses[sentiment].Count)];

            response = randomResponse;

            Console.WriteLine();

            //changing the text color to green for better visibility
            Console.ForegroundColor = ConsoleColor.Green;

            PrintMessage(response);

            Console.WriteLine();

            //changing the text color back to white
            Console.ResetColor();

        }

        public void followUp(string userInput)
        {
            string name = Program.name;
            string input = "";
            int index = 0;
            string followUpQuestion = "";
            Console.WriteLine("What else you would like to know about this topic? If you don't want to know anything else, just say 'no' :) ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{name}: ");
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            index = input.IndexOf(":");
            followUpQuestion = input.Substring(index + 1).Trim().ToLower();
            if (followUpQuestion.EndsWith("?"))
            {
                followUpQuestion = followUpQuestion.Substring(0, followUpQuestion.Length - 1);
            }
            Console.WriteLine();

            if (followUpQuestion.Equals("why is this important"))
            {

                Console.ForegroundColor = ConsoleColor.Green;
                PrintMessage(whyResponses[userInput]);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (followUpQuestion.Equals("no", StringComparison.OrdinalIgnoreCase))
            {

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                PrintMessage("I'm sorry I don't understand.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }

        public void favouriteTopic(string topicName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintMessage($"Would you like to know more about {topicName}?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            string answer = Program.acceptUserInput();
            if (answer.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Random random = new Random();
                string randomResponse = favouriteTopics[topicName][random.Next(favouriteTopics[topicName].Count)];
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                PrintMessage(randomResponse);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }

        }

    }
}
