using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWork
{
    public class NormalObject : GameObject
    {
        public NormalObject()
        {
            base.Speed = 2;
        }

        public NormalObject(Point2D point) : base(point)
        {
            base.Speed = 2;
        }
    }
}
