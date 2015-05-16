using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWork
{
    public class FastObject : GameObject
    {
        public FastObject()
        {
            base.Speed = 3;
        }

        public FastObject(Point2D point) : base(point)
        {
            base.Speed = 3;
        }
    }
}
