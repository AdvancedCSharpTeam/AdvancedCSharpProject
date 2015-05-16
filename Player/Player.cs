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
        private int ammo = 10;
        

        public Player()
        {
            this.Lives = this.lives;
            this.Ammo = this.ammo;
        }

        public int Ammo { get; set; }
        public int Lives { get; set; }
        public string Name { get; set; }
        
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

        public void setName(string newName) // There was issue with the private field name in this class
        {
            this.Name = newName;
        }

        //Method to print the player at its current position
        public void Print()
        {
            // Temporary ship design
            Drawing.DrawAt(Point.X, Point.Y - 2, @"        //-A-\\", ConsoleColor.Yellow);
            Drawing.DrawAt(Point.X, Point.Y - 1, @"  ___---=======---___", ConsoleColor.Yellow);
            Drawing.DrawAt(Point.X, Point.Y,     @"(=__\   /.. ..\   /__=)", ConsoleColor.Yellow);
            Drawing.DrawAt(Point.X, Point.Y + 1, @"     ---\__O__/---", ConsoleColor.Yellow);

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
            Drawing.DrawAt(Point.X, Point.Y - 2, @"                ");
            Drawing.DrawAt(Point.X, Point.Y - 1, @"                      ");
            Drawing.DrawAt(Point.X, Point.Y,     @"                        ");
            Drawing.DrawAt(Point.X, Point.Y + 1, @"                   ");
        }
    }
}
