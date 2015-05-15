using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TeamWork.Field;
using System.Media;

namespace TeamWork
{
    public class Engine
    {
        public static IPlayer player = new Player();

        public const int WindowWidth = 80; //Window Width constant to be accesed from everywhere
        public const int WindowHeight = 30; //Window height constant to be accesed from everywhere
        
        //TODO: Implement Engine Class!
        public Engine()
        {
            this.Start();
        }
        public void Start()
        {
            LoadMusic();
            Drawing.WelcomeScreen();
            Thread.Sleep(2500);
            Console.Clear();       
            Drawing.LetsPlay();
            Thread.Sleep(2500);
            Console.Clear();            
            Drawing.UserName();           
            this.TakeName();  
                        
            while (true)
            {
                this.TakeInput();

                if (player.Lives.Equals(0))
                {
                    break;
                }
            }
            this.End();            
        }
        private void End()
        {
            Drawing.GameOver();
            Thread.Sleep(2500);
            Console.Clear();
            Drawing.Credits();
        }
        private void TakeInput()
        {
            //TODO: Implement reading input for using the methods for moving in the Class Player!
            ConsoleKeyInfo currentkey = Console.ReadKey();
            switch (currentkey.KeyChar)
            {
                case 'w': player.MoveUp();
                    break;
                case 's': player.MoveDown();
                    break;
                case 'a': player.MoveLeft();
                    break;
                case 'd': player.MoveRight();
                    break;
                default: Console.WriteLine("You shouldn't see this!");
                    break;
            }
        }
        private void LoadMusic()
        {
            var sound = new System.Media.SoundPlayer();
            sound.SoundLocation = "STARS.wav";
            sound.PlaySync();
        }
        private void TakeName()
        {
            Console.WriteLine();
            Console.Write("\n\t\t\t\tName:");
            string name = Console.ReadLine();
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("\t\t\t\tPlease entry your name");
                Thread.Sleep(2000);
                Console.Clear();
                Drawing.UserName();
                TakeName();
            }
            else
            {
                player.setName(name);
                Console.Clear();
            }
        }

        /// <summary>
        /// Initialize Console size;
        /// </summary>
        public static void InitConsole()
        {
            Console.WindowWidth = WindowWidth;
            Console.BufferWidth = WindowWidth;
            Console.WindowHeight = WindowHeight;
            Console.BufferHeight = WindowHeight;
        }
    }
}
