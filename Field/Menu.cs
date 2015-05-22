using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Windows.Media;

namespace TeamWork.Field
{
    class Menu
    {
        public static bool menuActive = true;
        public static bool validInput = true;
        public static MediaPlayer mediaPlayer = new MediaPlayer();

        public static void StartMenu()
        {       
            //If do not have INTRO_SOUND skip media player part
            mediaPlayer.Open(new Uri("Resources/INTRO_SOUND.wav", UriKind.Relative));
            mediaPlayer.Play();
            Printing.WelcomeScreen();
            Thread.Sleep(3500);
            while (menuActive)
            {
                if (validInput)
                {
                    Console.Clear();
                    Printing.StartMenu();
                    //Missing part for spaceship selection screen
                    validInput = false;
                }

                if (UserChoice(Console.ReadKey(true)))
                {
                    validInput = true;
                }
                else
                {
                    validInput = false;
                }
            }
        }      
        public static bool UserChoice(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.P: Console.Clear();
                    mediaPlayer.Stop();                  
                    menuActive = false;
                    return true;
                case ConsoleKey.S:
                    Console.Clear();
                    Printing.HighScore();
                    return true;
                case ConsoleKey.C: Console.Clear();
                    Printing.Credits();
                    return true;
                case ConsoleKey.Q: Environment.Exit(0);
                    return false;
                default:
                    return false;
            }
        }
        public static void EntryStoryLine()
        {

        }      
    }
}
