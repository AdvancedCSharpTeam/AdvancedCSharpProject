using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWork
{
    public class SlowObject : GameObject
    {
        public SlowObject()
        {
            base.Speed = 1;
        }
        public SlowObject(Point2D point) : base(point)
        {
            base.Speed = 1;
        }
    }
}
