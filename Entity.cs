using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWork
{
    abstract public class Entity : IEntity
    {
        private int speed;

        public Entity()
        {
            this.Speed = speed;
        }
        
        public int Speed { get; set; }
    }
}
