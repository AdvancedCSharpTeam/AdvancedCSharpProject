using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWork
{
    public class Player : Entity, IPlayer, IEntity
    {
        private int lives = 3;
        private int ammo = 10;
        private string name = "Default";

        public Player()
        {
            this.Lives = this.lives;
            this.Ammo = this.ammo;
            this.Name = this.name;
        }

        public int Ammo { get; set; }
        public int Lives { get; set; }
        public string Name { get; set; }

        public void MoveUp()
        {
            if (!(base.Point.X.Equals(30)))
            {
                if ((base.Point.Y < 30))
                {
                    base.Point.Y += 1;
                    Console.WriteLine("Moving Up");
                }
            }
        }
        public void MoveDown()
        {
            if (!(base.Point.X.Equals(1)))
            {
                if ((base.Point.Y >= 0))
                {
                    base.Point.Y -= 1;
                    Console.WriteLine("Moving Down");
                }
            }
        }
        public void MoveRight()
        {
            if (!(base.Point.X.Equals(80)))
            {
                if ((base.Point.X < 80))
                {
                    base.Point.Y += 1;
                    Console.WriteLine("Moving Right");
                }
            }
        }
        public void MoveLeft()
        {
            if (!(base.Point.X.Equals(1)))
            {
                if ((base.Point.X > 0))
                {
                    base.Point.X -= 1;
                    Console.WriteLine("Moving Left");
                }
            }
        }
        public void setName(string name)
        {
            this.Name = name;
        }
    }
}
