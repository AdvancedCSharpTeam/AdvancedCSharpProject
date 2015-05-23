using System;
using TeamWork.Field;
using TeamWork.Objects;

namespace TeamWork
{
    public class Player : Entity, IPlayer
    {
        private int lives = 3;
        private int score = 0;
        private int level = 1;

        public static Point2D PlayerPoint = new Point2D(10, 15);

        public Player()
        {
            this.Lives = this.lives;
            this.Score = this.score;
            this.Level = this.level;

        }

        public int Score { get; set; }
        public int Lives { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public void MoveUp()
        {
            // Limit player movement on Y axis
            if (this.Point.Y - 1 >= 3) // Limit so the temporary ship does not go out of screen and crash the game
            {

                Clear();
                this.Point.Y--;
                Print();
            }
        }

        public void MoveDown()
        {
            // Limit player movement on Y axis
            if (this.Point.Y + 1 < Engine.WindowHeight - 4)
            {
                Clear();
                this.Point.Y++;
                Print();
            }
        }

        public void MoveRight()
        {
            // Limit player movement on X axis
            if (this.Point.X + 1 < Engine.WindowWidth - 23)
            // Limit so the temporary ship does not go out of screen and crash the game
            {
                Clear();
                this.Point.X++;
                Print();
            }
        }

        public void MoveLeft()
        {
            // Limit player movement on X axis
            if (this.Point.X - 1 >= 1)
            {
                Clear();
                this.Point.X--;
                Print();
            }
        }

        public void setName(string newName)
        {
            this.Name = newName;
        }

        //Method to print the player at its current position
        public void Print()
        {
            Printing.DrawAt(Point.X, Point.Y - 1, @"____", ConsoleColor.Cyan);
            Printing.DrawAt(Point.X, Point.Y, @" \  \_____________", ConsoleColor.Cyan);
            Printing.DrawAt(Point.X, Point.Y + 1, @" <[=)_)_)_)_______)_ >", ConsoleColor.Cyan);
            Printing.DrawAt(Point.X + 20, Point.Y + 1, "=", ConsoleColor.DarkCyan);
        }
        //To Do one more Player???
        // Method to clear players last position
        public void Clear()
        {
            //Had to use strings to get rid of artefacts
            Printing.DrawAt(Point.X, Point.Y - 1, @"    ");
            Printing.DrawAt(Point.X, Point.Y, @"                  ");
            Printing.DrawAt(Point.X, Point.Y + 1, @"                      ");
        }

        public void IncreasePoints()
        {
            this.Score++;
            Engine.Player.Level = Engine.Player.Score/ 50 + 1;
        }

        public void IncreasePoints(int points)
        {
            this.Score += points;
            Engine.Player.Level = Engine.Player.Score / 50 + 1;
        }

        public void DecreaseLives()
        {
            this.Lives--;
        }

        public bool ShipCollided(int x, int y)
        {
            if ((x == Point.X + 21 && y == Point.Y) ||
                (x == Point.X + 21 && y == Point.Y + 1) || // Front collision
                (x == Point.X + 19 && y == Point.Y) ||
                (x == Point.X + 18 && y == Point.Y) || // Top collision
                (x == Point.X + 17 && y == Point.Y) ||
                (x == Point.X + 16 && y == Point.Y) || // Top collision
                (x == Point.X + 15 && y == Point.Y) ||
                (x == Point.X + 14 && y == Point.Y) || // Top collision
                (x == Point.X + 13 && y == Point.Y) ||
                (x == Point.X + 12 && y == Point.Y) || // Top collision
                (x == Point.X + 11 && y == Point.Y) ||
                (x == Point.X + 10 && y == Point.Y) || // Top collision
                (x == Point.X + 9 && y == Point.Y) ||
                (x == Point.X + 8 && y == Point.Y) || // Top collision
                (x == Point.X + 7 && y == Point.Y) ||
                (x == Point.X + 6 && y == Point.Y) || // Top collision
                (x == Point.X + 5 && y == Point.Y) ||
                (x == Point.X + 4 && y == Point.Y) || // 
                (x == Point.X + 19 && y == Point.Y + 1) ||
                (x == Point.X + 18 && y == Point.Y + 1) || // Bottom collision
                (x == Point.X + 17 && y == Point.Y + 1) ||
                (x == Point.X + 16 && y == Point.Y + 1) || // Bottom collision
                (x == Point.X + 15 && y == Point.Y + 1) ||
                (x == Point.X + 14 && y == Point.Y + 1) ||
                (x == Point.X + 13 && y == Point.Y + 1) || // Bottom collision
                (x == Point.X + 12 && y == Point.Y + 1) ||
                (x == Point.X + 11 && y == Point.Y + 1) || // Bottom collision
                (x == Point.X + 10 && y == Point.Y + 1) ||
                (x == Point.X + 9 && y == Point.Y + 1) || // Bottom collision
                (x == Point.X + 8 && y == Point.Y + 1) ||
                (x == Point.X + 7 && y == Point.Y + 1) || // Bottom collision
                (x == Point.X + 6 && y == Point.Y + 1) ||
                (x == Point.X + 5 && y == Point.Y + 1) ||
                (x == Point.X + 4 && y == Point.Y + 1) || // Bottom collision
                (x == Point.X + 3 && y == Point.Y + 1) ||
                (x == Point.X + 2 && y == Point.Y + 1) || // Bottom collision
                (x == Point.X + 3 && y == Point.Y - 1) ||
                (x == Point.X + 1 && y == Point.Y + 1)) // Tail collision
            {
                Engine.Player.DecreaseLives();

                Menu.Table();
                Menu.UIDescription();

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ShipCollided(Point2D p)
        {
            return ShipCollided(p.X, p.Y);
        }
    }
}