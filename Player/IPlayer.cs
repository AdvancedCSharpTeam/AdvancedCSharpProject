using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWork
{
    public interface IPlayer : IEntity
    {
        int Ammo { get; set; }
        string Name { get; set; }
        int Lives { get; set; }

        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void setName(string name);
    }
}
