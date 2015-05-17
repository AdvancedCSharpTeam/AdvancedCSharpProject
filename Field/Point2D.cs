using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TeamWork
{
    public class Point2D
    {
        private int x;
        private int y;

        public Point2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        
        public static bool operator ==(Point2D point,Point2D point2) 
        {
            return point.X == point2.X && point.Y == point2.Y;
        }
        public static bool operator !=(Point2D point, Point2D point2)
        {
            return point.X != point2.X || point.Y != point2.Y;
        }

        public override bool Equals(object obj) // Should be overrided
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.X + this.Y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
