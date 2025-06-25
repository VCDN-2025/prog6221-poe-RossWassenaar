using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Cyber_Security_Awareness_Assistant
{
    /*
     * Name: Microsoft
     * Year: 2025
     * Title: SoundPlayer Class
     * [Online]
     * Available at: https://learn.microsoft.com/en-us/dotnet/api/system.media.soundplayer?view=windowsdesktop-9.0
     * Accessed: 15 April 2025
     * Reason: Play a .wav audio file in the console, while it runs other tasks.
     */
    class Greeting
    {
        public static void PlayGreeting()
        {
            const string VOICE_GREETING = "Assets/Voice Greeting.wav"; //saving path as a constant
            try
            {
                using (SoundPlayer player = new SoundPlayer(VOICE_GREETING)) //creating a new SoundPlayer object and using SoundPlayer class to play the .wav audio file
                {
                    player.PlaySync();
                }
            }
            catch
            {
                Console.WriteLine("Error: Sound did not play correctly");
            }

        }
    }
}
