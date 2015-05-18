using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TeamWork.Field
{
    class Menu
    {
        public static  bool menuActive = true;

        public static void StartMenu()
        {
            Printing.WelcomeScreen();
            Thread.Sleep(3500);
            Console.Clear();
            Printing.StartMenu();
            while (menuActive)
            {
                if (Console.KeyAvailable)
                {
                    UserChoice(Console.ReadKey(true));            
                }
            }
        }
        public static void UserChoice(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.P: Printing.Player.MoveUp();
                    break;
                case ConsoleKey.S: Printing.HighScore();
                    break;
                case ConsoleKey.C: Printing.Credits();
                    break;
                case ConsoleKey.Q: Environment.Exit(0);
                    break;
            }
        }
    }
}
