﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using TeamWork.Field;
using System.Media;
using System.Windows.Media;
using System.Runtime.ExceptionServices;
using System.Security.AccessControl;
using System.Drawing;
using System.IO;

namespace TeamWork
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
                    _bullets.Add(new GameObject(new Point2D(Printing.Player.Point.X + 22, Printing.Player.Point.Y + 1)));
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
                    Printing.DrawAt(_bullets[i].Point, ".", ConsoleColor.Cyan); // Print the bullets at their new position;
                    newBullets.Add((_bullets[i]));
                }
            }
            _bullets = newBullets; // Overwrite global bullets list, with newBullets list
        }

        #endregion

        #region Object Generator
        private List<GameObject> _meteorits = new List<GameObject>();
        private int counter = 0; // Just a counter
        public int chance = 24; // Chance variable 1 per 25 loops spawn a meteor
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
            if (counter % 1 == 0)
            {

                for (int i = 0; i < _meteorits.Count; i++)
                {

                    Printing.ClearAtPosition(_meteorits[i].Point); // Clear meteorit at its current position
                    Printing.ClearAtPosition(_meteorits[i].Point.X, _meteorits[i].Point.Y + 1);
                    Printing.ClearAtPosition(_meteorits[i].Point.X, _meteorits[i].Point.Y - 1);

                    Printing.ClearAtPosition(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y);
                    Printing.ClearAtPosition(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y + 1);
                    Printing.ClearAtPosition(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y - 1);

                    Printing.ClearAtPosition(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y);
                    Printing.ClearAtPosition(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y + 1);
                    Printing.ClearAtPosition(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y - 1);
                    if (_meteorits[i].Point.X - _meteorits[i].Speed <= 1)
                    {
                        // If the meteorit exceeds sceen size, dont add it to new meteorit list
                    }
                    else
                    {
                        //Collision Handling

                        if (BulletCollision(_meteorits[i].Point) ||
                            BulletCollision(new Point2D(_meteorits[i].Point.X, _meteorits[i].Point.Y)) ||
                            BulletCollision(new Point2D(_meteorits[i].Point.X, _meteorits[i].Point.Y + 1)) ||
                            BulletCollision(new Point2D(_meteorits[i].Point.X, _meteorits[i].Point.Y - 1)) ||

                            BulletCollision(new Point2D(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y)) ||
                            BulletCollision(new Point2D(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y + 1)) ||
                            BulletCollision(new Point2D(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y - 1)) ||

                            BulletCollision(new Point2D(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y)) ||
                            BulletCollision(new Point2D(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y + 1)) ||
                            BulletCollision(new Point2D(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y - 1)))
                        {
                            playMeteorEffect = true;
                            //SoundEffects(1);
                            Printing.ClearAtPosition(_meteorits[i].Point);
                            Printing.ClearAtPosition(_meteorits[i].Point.X, _meteorits[i].Point.Y + 1);
                            Printing.ClearAtPosition(_meteorits[i].Point.X, _meteorits[i].Point.Y - 1);

                            Printing.ClearAtPosition(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y);
                            Printing.ClearAtPosition(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y + 1);
                            Printing.ClearAtPosition(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y - 1);

                            Printing.ClearAtPosition(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y);
                            Printing.ClearAtPosition(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y + 1);
                            Printing.ClearAtPosition(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y - 1);


                        }
                        else
                        {
                            //Collision Handling
                            if (MeteoriteCollision(_meteorits[i].Point) ||
                            MeteoriteCollision(new Point2D(_meteorits[i].Point.X, _meteorits[i].Point.Y)) ||
                            MeteoriteCollision(new Point2D(_meteorits[i].Point.X, _meteorits[i].Point.Y + 1)) ||
                            MeteoriteCollision(new Point2D(_meteorits[i].Point.X, _meteorits[i].Point.Y - 1)) ||

                            MeteoriteCollision(new Point2D(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y)) ||
                            MeteoriteCollision(new Point2D(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y + 1)) ||
                            MeteoriteCollision(new Point2D(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y - 1)) ||

                            MeteoriteCollision(new Point2D(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y)) ||
                            MeteoriteCollision(new Point2D(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y + 1)) ||
                            MeteoriteCollision(new Point2D(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y - 1)))
                            {
                                playMeteorEffect = true;
                                //SoundEffects(2);
                                Printing.ClearAtPosition(_meteorits[i].Point);
                                Printing.ClearAtPosition(_meteorits[i].Point.X, _meteorits[i].Point.Y + 1);
                                Printing.ClearAtPosition(_meteorits[i].Point.X, _meteorits[i].Point.Y - 1);

                                Printing.ClearAtPosition(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y);
                                Printing.ClearAtPosition(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y + 1);
                                Printing.ClearAtPosition(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y - 1);

                                Printing.ClearAtPosition(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y);
                                Printing.ClearAtPosition(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y + 1);
                                Printing.ClearAtPosition(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y - 1);
                            }
                            else
                            {
                                _meteorits[i].Point.X -= _meteorits[i].Speed;

                                Printing.DrawAt(_meteorits[i].Point.X, _meteorits[i].Point.Y, _meteorits[i].ToString(), ConsoleColor.Green);
                                Printing.DrawAt(_meteorits[i].Point.X, _meteorits[i].Point.Y + 1, _meteorits[i].ToString(), ConsoleColor.Green);
                                Printing.DrawAt(_meteorits[i].Point.X, _meteorits[i].Point.Y - 1, _meteorits[i].ToString(), ConsoleColor.Green);

                                Printing.DrawAt(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y, _meteorits[i].ToString(), ConsoleColor.Yellow);
                                Printing.DrawAt(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y + 1, _meteorits[i].ToString(), ConsoleColor.Yellow);
                                Printing.DrawAt(_meteorits[i].Point.X + 1, _meteorits[i].Point.Y - 1, _meteorits[i].ToString(), ConsoleColor.Yellow);

                                Printing.DrawAt(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y, _meteorits[i].ToString(), ConsoleColor.Red);
                                Printing.DrawAt(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y + 1, _meteorits[i].ToString(), ConsoleColor.Red);
                                Printing.DrawAt(_meteorits[i].Point.X + 2, _meteorits[i].Point.Y - 1, _meteorits[i].ToString(), ConsoleColor.Red);

                                newMeteorits.Add((_meteorits[i]));
                            }
                        }

                    }
                }
                _meteorits = newMeteorits;

            }
        }

        #region Collision Handling Methods
        //Collision Handling Methods
        private bool BulletCollision(Point2D point)
        {
            if (_bullets.Any(bullet => point == bullet.Point))
            {
                Point2D currentBulletPoint = _bullets.FirstOrDefault(bullet => point == bullet.Point).Point;
                _bullets.Remove(_bullets.FirstOrDefault(bullet => point == bullet.Point));

                Printing.ClearAtPosition(currentBulletPoint.X, currentBulletPoint.Y);
                Printing.Player.IncreasePoints();

                Interface.Table();
                Interface.UIDescription();
                return true;
            }
            return false;
        }
        //Collision Handling Methods
        private bool MeteoriteCollision(Point2D point)
        {
            if (Printing.Player.Point.X + 22 == point.X && (Printing.Player.Point.Y == point.Y || Printing.Player.Point.Y == point.Y - 1 || Printing.Player.Point.Y == point.Y + 1))
            {
                Printing.Player.DecreaseLives();

                Interface.Table();
                Interface.UIDescription();
                return true;
            }
            return false;
        }
        #endregion

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

        public static void LoadMusic()
        {
            var sound = new System.Media.SoundPlayer();
            sound.SoundLocation = "STARS.wav";
            sound.PlayLooping();
        }
        private bool playMeteorEffect;
        private bool playEffect;
        public void SoundEffects()
        {
            var soundFX = new MediaPlayer();
            var soundFX2 = new MediaPlayer();

            while (true)
            {
                if (playMeteorEffect)
                {
                    soundFX.Open(new Uri("meteor.wav", UriKind.Relative));
                    soundFX.Volume = 500;
                    soundFX.Play();
                    playMeteorEffect = false;
                }
                if (playEffect)
                {
                    soundFX2.Open(new Uri("laser.wav", UriKind.Relative));
                    soundFX2.Volume = 300;
                    soundFX2.Play();
                    playEffect = false;
                }
            }
        }
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
