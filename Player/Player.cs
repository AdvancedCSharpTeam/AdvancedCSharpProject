using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using TeamWork.Field;

namespace TeamWork
{
    public class Player : Entity, IPlayer, IEntity
    {
        private int lives = 3;
        private int ammo = 50;
        private int score = 0;
        private int level = 1;
        

        public Player()
        {
            this.Lives = this.lives;
            this.Ammo = this.ammo;
            this.Score = this.score;
            this.Level = this.level;
        }

        public int Score { get; set; }
        public int Ammo { get; set; }
        public int Lives { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        
        public void MoveUp()
        {
            // Limit player movement on Y axis
            if (this.Point.Y - 1 >= 5) // Limit so the temporary ship does not go out of screen and crash the game
            {
                
                Clear();
                this.Point.Y--;
                Print();
            }
        }
        public void MoveDown()
        {
            // Limit player movement on Y axis
            if (this.Point.Y + 1 < Engine.WindowHeight - 5) 
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
            // Temporary ship design
            //Printing.DrawAt(Point.X, Point.Y - 2, @"        //-A-\\", ConsoleColor.Yellow);
            //Printing.DrawAt(Point.X, Point.Y - 1, @"  ___---=======---___", ConsoleColor.Yellow);
            //Printing.DrawAt(Point.X, Point.Y,     @"(=__\   /.. ..\   /__=)", ConsoleColor.Yellow);
            //Printing.DrawAt(Point.X, Point.Y + 1, @"     ---\__O__/---", ConsoleColor.Yellow);

            Printing.DrawAt(Point.X, Point.Y - 1, @"____", ConsoleColor.Cyan);
            Printing.DrawAt(Point.X, Point.Y,     @" \  \_____________", ConsoleColor.Cyan);
            Printing.DrawAt(Point.X, Point.Y + 1, @" <[=)_)_)_)_______)_=>", ConsoleColor.Cyan);

              //you can change it with this it is smaller    
              //    ____
              //     \  \_____________
              //     <[=)_)_)_)star)_=>
              //    _/__/

        }

        // Method to clear players last position
        public void Clear() 
        {
            //Had to use strings to get rid of artefacts
            Printing.DrawAt(Point.X, Point.Y - 2, @"                ");
            Printing.DrawAt(Point.X, Point.Y - 1, @"                         ");
            Printing.DrawAt(Point.X, Point.Y,     @"                           ");
            Printing.DrawAt(Point.X, Point.Y + 1, @"                           ");
        }

        public void IncreasePoints()
        {
            this.Score++;
        }
        public void DecreaseAmmo()
        {
            this.Ammo--;
        }
        public void DecreaseLives()
        {
            this.Lives--;
        }
    }
}
