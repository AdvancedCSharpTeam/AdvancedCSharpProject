using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWork
{
    abstract public class Entity : IEntity
    {
        private Point2D point = new Point2D(20, 20);
        private int speed;

        public Entity()
        {
            this.Point = point;
            this.Speed = this.speed;
        }

        public Entity(Point2D point)
        {
            this.Point = point;
            this.Speed = this.speed;
        }

        public Point2D Point
        {
            get {return this.point;}
            set {this.point = value;}
        }

        public int Speed { get; set; }
    }
}
