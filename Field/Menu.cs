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

        //Main menu load screen
        public static void StartMenu()
        {       
            //Menu Music Thread
            mediaPlayer.Open(new Uri("Resources/INTRO_SOUND.wav", UriKind.Relative));
            mediaPlayer.Play();
            Printing.WelcomeScreen();
            Thread.Sleep(2000);
            while (menuActive)
            {
                if (validInput)
                {
                    Console.Clear();
                    Printing.StartMenu();
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
        //Menu interface buttons
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
        //Entry story line
        public static void EntryStoryLine()
        {
            Printing.LoadStory();
            Thread.Sleep(2500);
            Console.Clear();
            Printing.LoadContent();
            Thread.Sleep(3000);
            Console.Clear();          
        }
    }
}
