using System;
using System.Data.SqlClient;
using TeamWork.Field;

namespace TeamWork.Objects
{
    public class GameObject : Entity
    {
        public enum ObjectType
        {
            Bullet,
            Normal, // 0
            Small, // 1
            Silver, // 2
            Gold, // 3
            Lenghty // 4
        }

        private ObjectType objectType;
        public GameObject()
        {
            base.Speed = 1;

        }

        public GameObject(Point2D point)
            : base(point)
        {
            base.Speed = 1;
            base.Point = point;
            objectType = 0;
        }

        public GameObject(Point2D point, int type)
            : base(point)
        {
            base.Speed = 1;
            base.Point = point;
            objectType = (ObjectType)type;
        }

        public override string ToString()
        {
            return string.Format("|");
        }

        /// <summary>
        /// Print GameObject based on its type
        /// </summary>
        public void PrintObject()
        {
            switch (objectType)
            {
                case ObjectType.Bullet:
                    Printing.DrawAt(this.Point, '-', ConsoleColor.DarkCyan);
                    break;
                case ObjectType.Normal:
                    Printing.DrawAt(this.Point, "/\\", ConsoleColor.Gray);
                    Printing.DrawAt(this.Point.X, Point.Y + 1, "\\/", ConsoleColor.Gray);
                    break;
                case ObjectType.Small:
                    Printing.DrawAt(this.Point, "<>");
                    break;
                case ObjectType.Silver:
                    Printing.DrawAt(this.Point.X, this.Point.Y - 1, "\\ /", ConsoleColor.Gray);
                    Printing.DrawAt(this.Point, " X ", ConsoleColor.Gray);
                    Printing.DrawAt(this.Point.X, this.Point.Y + 1, "/ \\", ConsoleColor.Gray);
                    break;
                case ObjectType.Gold:
                    Printing.DrawAt(this.Point.X, this.Point.Y - 1, " \u25B2", ConsoleColor.Yellow);
                    Printing.DrawAt(this.Point, "\u25C4\u25A0\u25BA", ConsoleColor.Yellow);
                    Printing.DrawAt(this.Point.X, this.Point.Y + 1, " \u25BC", ConsoleColor.Yellow);
                    break;
                case ObjectType.Lenghty:
                    Printing.DrawAt(this.Point, "{\u25A0\u25A0\u25BA");
                    break;

            }
        }

        /// <summary>
        /// Clear GameObject based on its type
        /// </summary>
        public void ClearObject()
        {
            switch (objectType)
            {
                case ObjectType.Bullet:
                    Printing.DrawAt(this.Point.X, this.Point.Y, ' ');
                    break;
                case ObjectType.Normal:
                    Printing.DrawAt(this.Point, "  ");
                    Printing.DrawAt(this.Point.X, Point.Y + 1, "  ");
                    break;
                case ObjectType.Small:
                    Printing.DrawAt(this.Point, "  ");
                    break;
                case ObjectType.Silver:
                    Printing.DrawAt(this.Point.X, this.Point.Y - 1, "   ");
                    Printing.DrawAt(this.Point, "   ");
                    Printing.DrawAt(this.Point.X, this.Point.Y + 1, "   ");
                    break;
                case ObjectType.Gold:
                    Printing.DrawAt(this.Point.X, this.Point.Y - 1, "  ");
                    Printing.DrawAt(this.Point, "   ");
                    Printing.DrawAt(this.Point.X, this.Point.Y + 1, "  ");
                    break;
                case ObjectType.Lenghty:
                    Printing.DrawAt(this.Point, "    ");
                    break;

            }
        }
        /// <summary>
        /// Collision check
        /// </summary>
        /// <param name="x">X to check with</param>
        /// <param name="y">Y to check with</param>
        /// <returns>If there is a collision</returns>
        public bool Collided(int x, int y)
        {
            switch (objectType)
            {
                case ObjectType.Normal:
                    /*
                     * (.)AB
                     * (.)CD
                     */
                    if ((x == this.Point.X && (y == this.Point.Y || y == this.Point.Y + 1)) || // A / C
                        (x == this.Point.X + 1 &&
                        (y == this.Point.Y || y == this.Point.Y + 1)) || // B / D
                        (x == this.Point.X - 1 &&
                        (y == this.Point.Y || y == this.Point.Y + 1)))// ..
                        return true;
                    return false;
                case ObjectType.Small:
                    /*
                     * (.)AB              
                     */
                    if ((x == this.Point.X && y == this.Point.Y) || // A
                        (x == this.Point.X + 1 && y == this.Point.Y) || // B
                        (x == this.Point.X - 1 && y == this.Point.Y)) // .
                        return true;
                    return false;
                case ObjectType.Silver:
                    /*  
                     * CFI
                     * ADG
                     * BEH
                     */
                    if ((x == this.Point.X && y == this.Point.Y) || //A
                        (x == this.Point.X &&
                        (y == this.Point.Y + 1 || y == this.Point.Y - 1)) || // B / C
                        (x == this.Point.X + 1 &&
                        (y == this.Point.Y || y == this.Point.Y + 1 || y == this.Point.Y - 1)) || // D / E / F
                        (x == this.Point.X + 2 &&
                        (y == this.Point.Y || y == this.Point.Y + 1 || y == this.Point.Y - 1))) // G / H / I
                        return true;
                    return false;
                case ObjectType.Gold:
                    /*  
                     * CF(.)
                     * ADG
                     * BE(.)
                     */
                    if ((x == this.Point.X &&
                        (y == this.Point.Y || y == this.Point.Y + 1 || y == this.Point.Y - 1)) || // A / B / C
                        (x == this.Point.X + 1 &&
                        (y == this.Point.Y || y == this.Point.Y + 1 || y == this.Point.Y - 1)) || // D / E / F
                        (x == this.Point.X + 2 &&
                        (y == this.Point.Y || y == this.Point.Y + 1 || y == this.Point.Y - 1))) // G / . / .
                        return true;
                    return false;
                case ObjectType.Lenghty:
                    /*
                     * ABCD
                     */
                    if ((x == this.Point.X && y == this.Point.Y) || // A
                        (y == this.Point.Y &&
                        (x == this.Point.X || x == this.Point.X + 1 || // B / C / D
                        x == this.Point.X + 2 || x == this.Point.X + 3)))
                        return true;
                    return false;
                default:
                    return false;
            }
        }
        /// <summary>
        /// Collision check with Point2D
        /// </summary>
        /// <param name="point">Point2D To check with</param>
        /// <returns>If there is a collision</returns>
        public bool Collided(Point2D point)
        {
            return Collided(point.X, point.Y);
        }


    }
}
