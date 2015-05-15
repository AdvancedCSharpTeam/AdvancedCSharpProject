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
        
        //TODO: We need to implement new moving methods, because the last ones weren't going to work!
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveRight()
        {

        }
        public void MoveLeft()
        {

        }
        public void setName(string name)
        {
            this.Name = name;
        }
    }
}
