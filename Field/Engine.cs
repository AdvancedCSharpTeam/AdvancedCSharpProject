using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TeamWork.Field;

namespace TeamWork
{
    public delegate void MoveHandler(object obj, MoveArgs move);

    public class Engine
    {
        public static event MoveHandler Move;

        public static void OnEventMove(MoveArgs moveArgs)
        {
            var handler = Move;
            if (Move != null)
                Move(null, moveArgs);
        }

        public Engine()
        {
            this.Start();
        }


        public void Start()
        {
            //Drawing.WelcomeScreen();
            //Thread.Sleep(2500);
            //Console.Clear();       
            //Drawing.LetsPlay();
            //Thread.Sleep(2500);
            //Console.Clear();            
            //Drawing.UserName();           
            //this.TakeName();

            Console.WindowWidth = 80;
            Console.BufferWidth = 80;
            Console.WindowHeight = 30;
            Console.BufferHeight = 30;

            //Drawing.DrawHLineAt(0, 0, 30, '*');
            //Drawing.DrawHLineAt(0, 5, 30, '*');
            //Drawing.DrawHLineAt(0, 10, 30, '*');
            //Drawing.DrawHLineAt(0, 15, 30, '*');
            //Drawing.DrawHLineAt(0, 20, 30, '*');
            //Drawing.DrawHLineAt(0, 25, 80, '*');
            //Drawing.DrawVLineAt(5, 5, 25, '~', ConsoleColor.Yellow);
            //Console.ReadKey();
            //Drawing.ClearFromTo(1, 0, 20, 20);
            //Console.ReadKey();
            //Drawing.ClearY(25);
            //Drawing.ClearX(5);

            //Drawing.Credits();
            //Console.ReadKey();

            //Drawing.DrawRectangleAt(new Point2D(3, 4), 5, '*');

            Console.WriteLine("Press any key to start!");
            Console.ReadLine();

            MoveListener moveListener = new MoveListener();
            Move += new MoveHandler(moveListener.Move);

            while (true)
            {
                
                Drawing.DrawField();
                Thread.Sleep(0);
                
                if (Drawing.Player.Lives.Equals(0))
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
            Console.ReadKey();
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
                Drawing.Player.setName(name);
                Console.Clear();
            }
        }
    }
}
