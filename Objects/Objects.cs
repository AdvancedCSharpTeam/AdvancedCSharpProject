using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWork
{
    abstract public class Objects : Entity, IObject
    {
        private Point2D point;

        public Point2D Point { get; set; }
    }
}
