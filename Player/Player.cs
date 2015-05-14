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

        public Player()
        {
            this.Lives = lives;
            this.Ammo = ammo;
        }

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
