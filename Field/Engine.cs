using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TeamWork.Field;
using System.Media;

namespace TeamWork
{
    public delegate void MoveHandler(object obj, MoveArgs move);

    public class Engine
    {
        public static event MoveHandler Move;
        public Thread musicThread;
              
        public static void OnEventMove(MoveArgs moveArgs)
        {
            var handler = Move;
            if (Move != null)
                Move(null, moveArgs);
        }

        public static Player player = new Player();

        public const int WindowWidth = 80; //Window Width constant to be accesed from everywhere
        public const int WindowHeight = 30; //Window height constant to be accesed from everywhere
        
        //TODO: Implement Engine Class!
        public Engine()
        {
            this.Start();
        }
        public void Start()
        {
            MoveListener moveListener = new MoveListener();
            Move += new MoveHandler(moveListener.Move);

            while (true)
            {
                musicThread = new Thread(Engine.LoadMusic);
                musicThread.Start();
                GameIntor();               
                Console.Clear();
                player.Print();
                Drawing.DrawField();
                
                while (true)
                {

                    if (Console.KeyAvailable)
                    {
                        this.TakeInput(Console.ReadKey(true));
                        while (Console.KeyAvailable)
                        {
                            Console.ReadKey(true); // Seems to clear the buffer of keys
                        }
                    }
                    MoveAndPrintBullets();


                    if (player.Lives.Equals(0))
                    {
                        break;
                    }
                    Thread.Sleep(50);
                }
                this.End();
            }
        }
        private void End()
        {
            Drawing.GameOver();
            Thread.Sleep(2500);
            Console.Clear();
            Drawing.Credits();
        }
        private void GameIntor()
        {
            Drawing.WelcomeScreen();
            Thread.Sleep(3500);
            Console.Clear();
            Drawing.GameName();
            Thread.Sleep(2500);
            Console.Clear();
            Drawing.LetsPlay();
            Thread.Sleep(2500);
            Console.Clear();
            Drawing.UserName();
            this.TakeName();
        }
        private void TakeInput(ConsoleKeyInfo keyPressed)
        {
            Console.ReadKey();
            switch (keyPressed.Key)
            {
                case ConsoleKey.W: player.MoveUp();
                    break;
                case ConsoleKey.S: player.MoveDown();
                    break;
                case ConsoleKey.A: player.MoveLeft();
                    break;
                case ConsoleKey.D: player.MoveRight();
                    break;
                // Create a new bullet object
                case ConsoleKey.Spacebar: bullets.Add(new FastObject(new Point2D(player.Point.X + 20, player.Point.Y)));
                    break;
                //default: Console.WriteLine("You shouldn't see this!");
                //    break;
            }
        }

        #region Player Bullets

        private List<FastObject> bullets = new List<FastObject>(); // Stores all bullets fired
        /// <summary>
        /// Print and move the bullets
        /// </summary>
        private void MoveAndPrintBullets()
        {
            List<FastObject> newBullets = new List<FastObject>(); //Stores the new coordinates of the bullets

            for (int i = 0; i < bullets.Count; i++) // Cycle thru all bullets and change their position
            {
                Drawing.ClearAtPosition(bullets[i].Point); // Clear bullet at its current position
                if (bullets[i].Point.X + bullets[i].Speed >= Engine.WindowWidth)
                {
                    // If the bullet exceeds sceen size, dont add it to new Bullets list
                }
                else
                {
                    bullets[i].Point.X += bullets[i].Speed;
                    Drawing.DrawAt(bullets[i].Point, '-', ConsoleColor.Cyan); // Print the bullets at their new position;
                    newBullets.Add((bullets[i]));
                }
            }
            bullets = newBullets; // Overwrite global bullets list, with newBullets list
        }

        #endregion

        public static void LoadMusic()
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
                Console.WriteLine("\t\t\t    Please entry your name");
                Thread.Sleep(2000);
                Console.Clear();
                Drawing.UserName();
                TakeName();               
            }
            else
            {
                Drawing.Player.setName(name);               
                Console.Clear();
                musicThread.Interrupt();
            }
        }

        /// <summary>
        /// Initialize Console size;
        /// </summary>
        public static void InitConsole()
        {
            Console.CursorVisible = false;
            Console.WindowWidth = WindowWidth;
            Console.BufferWidth = WindowWidth;
            Console.WindowHeight = WindowHeight;
            Console.BufferHeight = WindowHeight;
        }
    }
}
