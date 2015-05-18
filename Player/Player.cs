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
            if (this.Point.X + 1 < Engine.WindowWidth - 23) // Limit so the temporary ship does not go out of screen and crash the game
            {
                Clear();
                this.Point.X++;
                Print();
            }
        }
        public void MoveLeft()
        {
            // Limit player movement on X axis
            if (this.Point.X- 1 >= 1) 
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
            Printing.DrawAt(Point.X, Point.Y,     @" \  \_____________", ConsoleColor.Cyan);
            Printing.DrawAt(Point.X, Point.Y + 1, @" <[=)_)_)_)_______)_ >", ConsoleColor.Cyan);
            Printing.DrawAt(Point.X + 20, Point.Y + 1,"=", ConsoleColor.DarkCyan);           
        }

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
            if (this.Score % 30 * Printing.Player.Level == 0)
            {
                Printing.Player.Level++;
            }
        }
        public void DecreaseLives()
        {
            this.Lives--;
        }
    }
}
