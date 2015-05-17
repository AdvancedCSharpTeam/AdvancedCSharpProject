using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWork
{
    public interface IPlayer : IEntity
    {
        string Name { get; set; }
        int Lives { get; set; }
        int Score { get; set; }
        int Level { get; set; }

        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void setName(string name);

        void IncreasePoints();
        void DecreaseLives();
        void Print();
    }
}
