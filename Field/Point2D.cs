namespace TeamWork.Field
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

        public static bool operator ==(Point2D point, Point2D point2)
        {
            return point.X == point2.X && point.Y == point2.Y;
        }
        public static bool operator !=(Point2D point, Point2D point2)
        {
            return point.X != point2.X || point.Y != point2.Y;
        }

        public static Point2D operator -(Point2D point, Point2D point2)
        {
            int x = point.X - point2.X;
            int y = point.Y - point2.Y;
            return new Point2D(x, y);
        }

        public static Point2D operator +(Point2D point, Point2D point2)
        {
            int x = point.X + point2.X;
            int y = point.Y + point2.Y;
            return new Point2D(x, y);
        }
        public static Point2D operator *(Point2D point, int multiplier)
        {
            int x = point.X * multiplier;
            int y = point.Y * multiplier;
            return new Point2D(x, y);
        }


        public override bool Equals(object obj) 
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