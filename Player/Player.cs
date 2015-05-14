using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWork
{
    public class Player : IPlayer
    {
        private int lives;
        private int ammo;

        private Point2D point;

        public Player()
        {
            this.Lives = lives;
            this.Ammo = ammo;

            this.Point.X = 0;
            this.Point.Y = 0;
        }

        public Point2D Point { get; set; }
        public int Ammo { get; set; }
        public int Lives { get; set; }

        public void MoveUp()
        {
            throw new System.NotImplementedException();
        }
        public void MoveDown()
        {
            throw new System.NotImplementedException();
        }
        public void MoveLeft()
        {
            throw new System.NotImplementedException();
        }
        public void MoveRight()
        {
            throw new System.NotImplementedException();
        }

    }
}
