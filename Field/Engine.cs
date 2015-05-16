using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using TeamWork.Field;
using System.Media;
using System.Runtime.ExceptionServices;
using System.Security.AccessControl;

namespace TeamWork
{
    public delegate void MoveHandler(object obj, MoveArgs move);

    public class Engine
    {
        public static Random rnd = new Random();
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
        public const int WindowHeight = 32; //Window height constant to be accesed from everywhere

        //TODO: Implement Engine Class!
        public Engine()
        {
            this.Start();
        }
        public void Start()
        {
            MoveListener moveListener = new MoveListener();
            Move += new MoveHandler(moveListener.Move);
            //musicThread = new Thread(Engine.LoadMusic);
            //musicThread.Start();

            while (true)
            {
                GameIntro();
                Console.Clear();
                player.Print();
                //Drawing.DrawField();
                Interface.Table();
                Interface.UIDescription();

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
                    UpdateAndRender();
                    if (player.Lives.Equals(0))
                    {
                        break;
                    }

                    Thread.Sleep(50);
                }
                this.End();
            }
        }

        private void UpdateAndRender()
        {
            MoveAndPrintBullets();
            GenerateMeteorit();
            DrawAndMoveMeteor();
        }

        private void End()
        {
            Drawing.GameOver();
            Thread.Sleep(2500);
            Console.Clear();
            Drawing.Credits();
        }

        private void GameIntro()
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
                case ConsoleKey.Spacebar: _bullets.Add(new GameObject(new Point2D(player.Point.X + 20, player.Point.Y)));
                    break;
                //default: Console.WriteLine("You shouldn't see this!");
                //    break;
            }
        }

        #region Player Bullets

        private List<GameObject> _bullets = new List<GameObject>(); // Stores all bullets fired
        /// <summary>
        /// Print and move the bullets
        /// </summary>
        private void MoveAndPrintBullets()
        {
            List<GameObject> newBullets = new List<GameObject>(); //Stores the new coordinates of the bullets

            for (int i = 0; i < _bullets.Count; i++) // Cycle through all bullets and change their position
            {
                Drawing.ClearAtPosition(_bullets[i].Point); // Clear bullet at its current position
                if (_bullets[i].Point.X + _bullets[i].Speed + 2 >= Engine.WindowWidth)
                {
                    // If the bullet exceeds sceen size, dont add it to new Bullets list
                }
                else
                {
                    _bullets[i].Point.X += _bullets[i].Speed + 2;
                    Drawing.DrawAt(_bullets[i].Point, '-', ConsoleColor.Cyan); // Print the bullets at their new position;
                    newBullets.Add((_bullets[i]));
                }
            }
            _bullets = newBullets; // Overwrite global bullets list, with newBullets list
        }

        #endregion

        #region Object Generator
        private List<GameObject> _meteorits = new List<GameObject>();
        private int counter = 0; // Just a counter
        public int chance = 10; // Chance variable 1 per 25 loops spawn a meteor
        private void GenerateMeteorit()
        {
            if (counter % chance == 0)
            {
                _meteorits.Add(new GameObject(new Point2D(WindowWidth - 3, rnd.Next(5, WindowHeight - 5))));
                counter++;
            }
            else
            {
                counter++;
            }

        }

        private void DrawAndMoveMeteor()
        {
            List<GameObject> newMeteorits = new List<GameObject>();
            for (int i = 0; i < _meteorits.Count; i++)
            {

                Drawing.ClearAtPosition(_meteorits[i].Point); // Clear bullet at its current position
                Drawing.ClearAtPosition(_meteorits[i].Point.X, _meteorits[i].Point.Y + 1);
                Drawing.ClearAtPosition(_meteorits[i].Point.X, _meteorits[i].Point.Y - 1);

                Drawing.ClearAtPosition(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y);
                Drawing.ClearAtPosition(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y + 1);
                Drawing.ClearAtPosition(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y - 1);

                Drawing.ClearAtPosition(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y);
                Drawing.ClearAtPosition(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y + 1);
                Drawing.ClearAtPosition(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y - 1);
                if (_meteorits[i].Point.X - _meteorits[i].Speed <= 1)
                {
                    // If the meteorit exceeds sceen size, dont add it to new meteorit list
                }
                else
                {
                    _meteorits[i].Point.X -= _meteorits[i].Speed;
                    Drawing.DrawAt(_meteorits[i].Point.X, _meteorits[i].Point.Y, '|', ConsoleColor.Cyan);
                    Drawing.DrawAt(_meteorits[i].Point.X, _meteorits[i].Point.Y + 1, '|', ConsoleColor.Cyan);
                    Drawing.DrawAt(_meteorits[i].Point.X, _meteorits[i].Point.Y - 1, '|', ConsoleColor.Cyan);

                    Drawing.DrawAt(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y, '|', ConsoleColor.Cyan);
                    Drawing.DrawAt(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y + 1, '|', ConsoleColor.Cyan);
                    Drawing.DrawAt(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y - 1, '|', ConsoleColor.Cyan);

                    Drawing.DrawAt(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y, '|', ConsoleColor.Cyan);
                    Drawing.DrawAt(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y + 1, '|', ConsoleColor.Cyan);
                    Drawing.DrawAt(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y - 1, '|', ConsoleColor.Cyan);
                    newMeteorits.Add((_meteorits[i]));
                }
            }
            _meteorits = newMeteorits;
        }
        #endregion

        /*public static void LoadMusic()
        {
            var sound = new System.Media.SoundPlayer();
            sound.SoundLocation = "STARS.wav";
            sound.PlaySync();
        }*/

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
                //musicThread.Interrupt();
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
