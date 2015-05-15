using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWork
{
    public class Player : Entity, IPlayer, IEntity
    {
        private int lives;
        private int ammo;
        private string name;

        public Player()
        {
            this.Lives = lives;
            this.Ammo = ammo;
            this.Name = name;
        }

        public int Ammo { get; set; }
        public int Lives { get; set; }
        public string Name { get; set; }

        public void MoveUp()
        {
            if (!(base.Point.Y <= 30 && base.Point.Y >= 0))
            {
                base.Point.Y += 1;
            }
        }
        public void MoveDown()
        {
            if (!(base.Point.Y <= 30 && base.Point.Y >= 0))
            {
                base.Point.Y -= 1;
            }
        }
        public void MoveRight()
        {
            if (!(base.Point.Y <= 80 && base.Point.Y >= 0))
            {
                base.Point.Y += 1;
            }
        }
        public void MoveLeft()
        {
            if (!(base.Point.X <= 80 && base.Point.X >= 0))
            {
                base.Point.X -= 1;
            }
        }

        public void setName(string name)
        {
            this.Name = name;
        }
    }
}
