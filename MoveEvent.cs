using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamWork.Field;

namespace TeamWork
{

    public class MoveArgs : EventArgs
    {
        public ConsoleKeyInfo key;
        public MoveArgs()
        {
            this.key = Console.ReadKey();
            if (this.key.KeyChar.Equals('a'))
            {
                Drawing.Player.MoveLeft();
            }
            else if (this.key.KeyChar.Equals('d'))
            {
                Drawing.Player.MoveRight();
            }
            else if (this.key.KeyChar.Equals('s'))
            {
                Drawing.Player.MoveDown();
            }
            else if (this.key.KeyChar.Equals('w'))
            {
                Drawing.Player.MoveUp();
            }
        }
    }
}
