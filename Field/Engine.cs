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

            Console.WriteLine("Press enter key to start!");
            Console.ReadLine();

            MoveListener moveListener = new MoveListener();
            Move += new MoveHandler(moveListener.Move);

            while (true)
            {
                if (Drawing.Player.Lives.Equals(0))
                    //LoadMusic(); // It seems that commiting doesnt upload the sound file and this makes the game crash
                    Drawing.WelcomeScreen();
                Thread.Sleep(1000);
                Console.Clear();
                Drawing.LetsPlay();
                Thread.Sleep(2500);
                Console.Clear();
                Drawing.UserName();
                this.TakeName();

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
                default: Console.WriteLine("You shouldn't see this!");
                    break;
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
                Drawing.Player.setName(name);
                Console.Clear();
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
