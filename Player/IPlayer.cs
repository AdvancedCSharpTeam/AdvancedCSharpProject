using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWork
{
    public interface IPlayer
    {
        int Ammo { get; set; }

        int Lives { get; set; }

        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
    }
}
