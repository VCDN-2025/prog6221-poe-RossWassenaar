using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figgle;

namespace Cyber_Security_Awareness_Assistant
{
    /*
     * Name: Microsoft
     * Year: 2025
     * Title: Bitmap Class
     * [Online]
     * Available at: https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=windowsdesktop-9.0
     * Accessed: 15 April 2025
     * Reason: Create a logo using ASCII alone to be viewed in the console interface
     */
    class UXHelper
    {
        public static void DisplayLogo()
        {
            const string CYBER_SECURITY_LOGO = "Assets/Cyber Security Logo.png"; //saving path as a constant

            //definining width and height of the ascii logo
            const int WIDTH = 100;
            const int HEIGHT = 50;

            //using bitmap to map the ascii characters to the light and darkness of the image
            Bitmap logoUnsized = new Bitmap(CYBER_SECURITY_LOGO);
            Bitmap logo = new Bitmap(logoUnsized, new Size(WIDTH, HEIGHT));

            //defining the ascii characters to be used
            string asciiChars = "@%#*+=-:. ";

            //looping through the pixels of the image using x and y axis and mapping them to the ascii characters
            for (int y = 0; y < HEIGHT; y++)
            {
                for (int x = 0; x < WIDTH; x++)
                {
                    Color pixelColor = logo.GetPixel(x, y);
                    int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int index = grayValue * (asciiChars.Length - 1) / 255;
                    Console.Write(asciiChars[index]);
                }
                Console.WriteLine();
            }
        }

        //using figgle fonts to display an ascii art title
        public static void DisplayTitle()
        {
            Console.WriteLine(FiggleFonts.Big.Render("Cyber    Security"));
            Console.WriteLine();
            Console.WriteLine(FiggleFonts.Big.Render("Awareness    Assistant"));
        }

        //ascii art text-based welcoming message
        public static void DisplayWelcomeMessage(string name)
        {
            string message = $"║ Welcome {name} to the Cybersecurity Awareness Bot ║";
            int border = message.Length;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔" + new String('═', border - 2) + "╗");
            Console.WriteLine(message);
            Console.WriteLine("╚" + new String('═', border - 2) + "╝");

        }
    }
}

