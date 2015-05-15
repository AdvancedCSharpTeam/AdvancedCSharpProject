using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWork
{
    abstract public class Objects : Entity, IObject, IEntity
    {
        
        public Objects()
        {

        }
        public Objects(Point2D point) : base(point)
        {

        }
    }
}
