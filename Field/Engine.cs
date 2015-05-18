using System;
using System.Collections.Generic;
using System.Threading;
using System.Media;
using System.Windows.Media;
using System.IO;
using TeamWork.Objects;

namespace TeamWork.Field
{
    public class Engine
    {
        public static Random rnd = new Random();
        public Thread musicThread;
        public Thread EffectsThread;

        public const int WindowWidth = 80; //Window Width constant to be accesed from everywhere
        public const int WindowHeight = 32; //Window height constant to be accesed from everywhere

        public Engine()
        {
            this.Start();
        }
        public void Start()
        {
            musicThread = new Thread(Engine.LoadMusic);
            musicThread.Start();
            EffectsThread = new Thread(SoundEffects);
            EffectsThread.Start();
            while (true)
            {
                GameIntro();
                Console.Clear();
                Printing.Player.Print();
                Interface.Table();
                Interface.UIDescription();
                if (Printing.Player.Lives < 1)
                {
                    End();
                    break;
                }

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
                    Thread.Sleep(100);
                }
                // Tozi kod tuk e nedostijim
                if (Printing.Player.Lives < 1) 
                {
                    Console.Clear();
                    End();
                    break;
                }
                Console.Clear();
                this.End();
                break;
            }
        }

        private void UpdateAndRender()
        {
            if (Printing.Player.Lives < 1)
            {
                End();
                Thread.Sleep(100000);
            }

            DrawAndMoveMeteor();
            MoveAndPrintBullets();
            GenerateMeteorit();
        }

        #region GameStates
        private void End()
        {
            Console.Clear();
            Printing.GameOver();
            Thread.Sleep(2500);
            Console.Clear();
            SetHighscore();
            PrintHighscore();
            Thread.Sleep(6000);
            Console.Clear();
            Printing.Credits();
            Thread.Sleep(1000000);
        }
        private void GameIntro()
        {
            Printing.WelcomeScreen();
            Thread.Sleep(3500);
            Console.Clear();
            Printing.GameName();
            Thread.Sleep(2500);
            Console.Clear();
            Printing.LetsPlay();
            Thread.Sleep(2500);
            Console.Clear();
            Printing.UserName();
            this.TakeName();
        }

        #endregion

        /// <summary>
        /// Player move handler
        /// </summary>
        /// <param name="keyPressed"></param>
        private void TakeInput(ConsoleKeyInfo keyPressed)
        {
            switch (keyPressed.Key)
            {
                case ConsoleKey.W: Printing.Player.MoveUp();
                    break;
                case ConsoleKey.S: Printing.Player.MoveDown();
                    break;
                case ConsoleKey.A: Printing.Player.MoveLeft();
                    break;
                case ConsoleKey.D: Printing.Player.MoveRight();
                    break;
                // Create a new bullet object
                case ConsoleKey.Spacebar: 
                    _bullets.Add(new GameObject(new Point2D(Printing.Player.Point.X + 20, Printing.Player.Point.Y + 1)));
                    playEffect = true;
                    break;
            }
        }

        #region Player Bullets

        private List<GameObject> _bullets = new List<GameObject>(); // Stores all bullets fired
        /// <summary>
        /// Print and move the bullets
        /// </summary>
        private void MoveAndPrintBullets()
        {
            Printing.DrawAt(Printing.Player.Point.X+20,Printing.Player.Point.Y+1,'=', ConsoleColor.DarkCyan); // Fire effect lol
            List<GameObject> newBullets = new List<GameObject>(); //Stores the new coordinates of the bullets

            for (int i = 0; i < _bullets.Count; i++) // Cycle through all bullets and change their position
            {
                Printing.ClearAtPosition(_bullets[i].Point); // Clear bullet at its current position
                if (_bullets[i].Point.X + _bullets[i].Speed + 2 >= Engine.WindowWidth)
                {
                    // If the bullet exceeds sceen size, dont add it to new Bullets list
                }
                else
                {
                    _bullets[i].Point.X += _bullets[i].Speed + 1;
                    Printing.DrawAt(_bullets[i].Point, "-", ConsoleColor.DarkCyan); // Print the bullets at their new position;
                    
                    newBullets.Add((_bullets[i]));
                }
            }
            _bullets = newBullets; // Overwrite global bullets list, with newBullets list
        }

        #endregion

        #region Object Generator

        /// <summary>
        /// Generate meteorObjects
        /// </summary>
        private List<GameObject> _meteorits = new List<GameObject>();
        private int counter = 0; // Just a counter
        public int chance = 24; // Chance variable 1 per # loops spawn a meteor
        private void GenerateMeteorit()
        {
            if (counter % chance == 0)
            {
                _meteorits.Add(new GameObject(new Point2D(WindowWidth - 3, rnd.Next(6, WindowHeight - 4)), rnd.Next(0, 5)));
                counter++;
            }
            else
            {
                counter++;
            }
        }

        /// <summary>
        /// Print and move meteorites
        /// </summary>
        private void DrawAndMoveMeteor()
        {
            List<GameObject> newMeteorits = new List<GameObject>();
            if (counter % 1 == 0)
            {
                for (int i = 0; i < _meteorits.Count; i++)
                {
                    _meteorits[i].ClearObject();
                    if (_meteorits[i].Point.X - _meteorits[i].Speed <= 1)
                    {
                        // If the meteorit exceeds sceen size, dont add it to new meteorit list
                    }
                    else
                    {
                        // Collision handling
                        if (BulletCollision(_meteorits[i]) || ShipCollision(_meteorits[i])) // Bullet and ship collision check
                        {
                            playMeteorEffect = true;
                            _meteorits[i].ClearObject();
                        }
                        else
                        {
                            _meteorits[i].Point.X -= _meteorits[i].Speed;
                            _meteorits[i].PrintObject();
                            newMeteorits.Add((_meteorits[i]));
                        }
                    }
                }
                _meteorits = newMeteorits;

            }
        }
        #endregion

        #region Collision Handling Methods
        /// <summary>
        /// Bullet collision check
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>If any bullet hits a meteorite</returns>
        private bool BulletCollision(GameObject obj)
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                if (obj.Collided(_bullets[i].Point))
                {
                    Printing.ClearAtPosition(_bullets[i].Point);
                    _bullets.RemoveAt(i);
                    
                    Printing.Player.IncreasePoints();
                    
                    Interface.Table();
                    Interface.UIDescription();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Ship collision handling
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>If ship was struck by meteorite</returns>
        private bool ShipCollision(GameObject obj)
        {
            Point2D point = Printing.Player.Point;
            if (obj.Collided(point.X + 21, point.Y) || obj.Collided(point.X + 21, point.Y + 1) || // Front collision
                obj.Collided(point.X + 18, point.Y) || obj.Collided(point.X + 15, point.Y) || // Top collision
                obj.Collided(point.X + 11, point.Y) || obj.Collided(point.X + 6, point.Y) ||  // Top collision
                obj.Collided(point.X + 18, point.Y + 1) || obj.Collided(point.X + 15, point.Y + 1) ||// Bottom collision
                obj.Collided(point.X + 11, point.Y + 1) || obj.Collided(point.X + 6, point.Y + 1) || // Bottom collision
                obj.Collided(point.X + 3, point.Y - 1) || obj.Collided(point.X + 3, point.Y + 1)) // Tail collision
            {
                Printing.Player.DecreaseLives();

                Interface.Table();
                Interface.UIDescription();
                return true;
            }
            return false;
        }
        #endregion

        #region Highscore and Score Methods
        //Checks if the oldHighScore and the CurrentHighScore are different, and sets the higher value as the new HighScore
        //Also adds all scores to the Scores.txt file
        private void SetHighscore()
        {
            string highscore = string.Format("Player {0}, Highscore {1}, Time Achieved: {2} / {3} / {4}", 
                Printing.Player.Name, Printing.Player.Score, DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);

            string[] oldText = File.ReadAllText("Highscore.txt").Split();

            string oldHighScore = oldText[3].Remove(oldText[3].Length - 1);
            int oldHighScoreToInt = int.Parse(oldHighScore);

            if (oldHighScoreToInt < Printing.Player.Score)
                File.WriteAllText("Highscore.txt", highscore);

            string currentScores = File.ReadAllText("Scores.txt");
            highscore = string.Format("Player {0}, Score {1}, Time Achieved: {2} / {3} / {4}",
                Printing.Player.Name, Printing.Player.Score, DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);
            currentScores += "#" + highscore + @"
";
            File.WriteAllText("Scores.txt", currentScores);
        }
        public void PrintHighscore()
        {
            Printing.DrawAt(0, 5, Printing.highScore, ConsoleColor.Green);
            string currentHighscore = File.ReadAllText("Highscore.txt");
            Printing.DrawAt(new Point2D(15, 14), "Current Highscore: ", ConsoleColor.Green);
            Printing.DrawAt(new Point2D(15, 15), currentHighscore, ConsoleColor.Green);
            Printing.DrawAt(new Point2D(15, 17), "Last Achieved Scores: ", ConsoleColor.Green);

            string[] currentScores = File.ReadAllLines("Scores.txt");
            int y = 17;
            int counter = 0;
            for (int i = currentScores.Length-1; i >= currentScores.Length-10; i--)
            {
                y++;
                counter++;
                Printing.DrawAt(new Point2D(15, y), counter + " " + currentScores[i], ConsoleColor.Green);
            }
        }
        #endregion

        #region Music
        private static bool playMeteorEffect;
        private static bool playEffect;
        private static void LoadMusic()
        {
            var sound = new SoundPlayer();
            sound.SoundLocation = "STARS.wav";
            sound.PlayLooping();
           
        }
        
        private void SoundEffects()
        {

            MediaPlayer soundFX = new MediaPlayer();
            MediaPlayer soundFX2 = new MediaPlayer();
           
            while (true)
            {
                if (playMeteorEffect)
                {
                    soundFX.Open(new Uri("meteor.wav", UriKind.Relative));
                    
                    soundFX.Volume = 60;
                    soundFX.Play();
                    playMeteorEffect = false;
                }
                if (playEffect)
                {
                    soundFX2.Open(new Uri("laser.wav", UriKind.Relative));
                    soundFX2.Volume = 400;
                    soundFX2.Play();
                    playEffect = false;
                }
            }
        }

        #endregion

        private void TakeName()
        {
            Console.WriteLine();
            Console.Write("\n\t\t\t\tName:");
            string name = Console.ReadLine();
            if (String.IsNullOrEmpty(name) || name.Length >= 10)
            {
                Console.WriteLine("\t\t\t    Please enter your name! Name must also be less than/or 10 symbols");
                Thread.Sleep(2000);
                Console.Clear();
                Printing.UserName();
                TakeName();
            }
            else
            {
                Printing.Player.setName(name);
                Console.Clear();
                musicThread.Abort();
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
