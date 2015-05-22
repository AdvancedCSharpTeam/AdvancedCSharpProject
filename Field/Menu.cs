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
            Printing.LoadStory();
            Thread.Sleep(2500);
            Console.Clear();
            Printing.LoadContent();
            Thread.Sleep(3000);
            Console.Clear();
           
            //Planet "Murth" was completely destroyed 
            //nothing but ashes remains,
            //you are our last hope.
            //Your goal is to find and destroy evil aliens,
            //but be prepared they are very strong enemies.
            //Good luck on your new and though adventure.
            //And don't be late for the public defence
            //in SoftUni. 
        }
    }
}
