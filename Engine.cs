using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TeamWork.Field;

namespace TeamWork
{
    public class Engine
    {
        public static IPlayer player = new Player();

        //TODO: Implement Engine Class!
        public Engine()
        {
            this.Start();
        }


        public void Start()
        {
            Drawing.WelcomeScreen();
            Thread.Sleep(2000);
            Console.Clear();
            Drawing.Credits();
            Thread.Sleep(2000);
            Console.Clear();
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
            Console.Clear();
        }
        private void TakeInput()
        {
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

        private void TakeName()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            player.setName(name);
            Console.Clear();
        }
    }
}
