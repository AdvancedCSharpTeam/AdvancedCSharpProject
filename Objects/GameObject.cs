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
            Normal,
            Small,
            Silver,
            Gold,
            Lenghty
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
        public bool toBeDeleted = false;
        private bool Moveable = true;
        public override string ToString()
        {
            return string.Format("Object type:{0}, X:{1}, Y:{2},Moveable:{3}",objectType,Point.X,Point.Y,Moveable);
        }

        /// <summary>
        /// Print GameObject based on its type
        /// </summary>
        private int Frames = 1;
        private Point2D diagonalInc = new Point2D(1,1);
        private Point2D diagonalDec = new Point2D(-1, 1);
        private Point2D upRight;
        private Point2D upLeft;
        private Point2D downLeft;
        private Point2D downRight;
        public bool GotHit = false;
        public void PrintObject()
        {
            switch (objectType)
            {
                case ObjectType.Bullet:
                    Printing.DrawAt(this.Point, '-', ConsoleColor.DarkCyan);
                    break;
                case ObjectType.Normal:
                    if (!this.GotHit)
                    {
                        Printing.DrawAt(this.Point, "/\\", ConsoleColor.Red);
                        Printing.DrawAt(this.Point.X, Point.Y + 1, "\\/", ConsoleColor.Red);
                    }
                    else
                    {
                        upLeft = this.Point - diagonalInc * Frames;
                        upRight = this.Point - diagonalDec * Frames;
                        downRight = this.Point + diagonalInc * Frames;
                        downLeft = this.Point + diagonalDec * Frames;
                        char[] c = { '/', '\\', '\\', '/' };
                        PrintAndClearExplosion(false, c, ConsoleColor.Red);
                    }
                    
                    break;
                case ObjectType.Small:
                   if (!this.GotHit)
                    {
                        Printing.DrawAt(this.Point, "<>");
                    }
                    else
                    {
                        upRight = new Point2D(this.Point.X + Frames+1,this.Point.Y);
                        upLeft = new Point2D(this.Point.X - Frames, this.Point.Y);
                        downRight = new Point2D(this.Point.X, this.Point.Y + Frames);
                        downLeft = new Point2D(this.Point.X, this.Point.Y - Frames);
                        char[] c = {'<', '>', '/', '\\'};
                        PrintAndClearExplosion(false,c,ConsoleColor.Gray);
                    }
                    break;
                case ObjectType.Silver:
                    if (!this.GotHit)
                    {
                        Printing.DrawAt(this.Point.X, this.Point.Y - 1, "\\ /", ConsoleColor.Gray);
                        Printing.DrawAt(this.Point, " X ", ConsoleColor.Gray);
                        Printing.DrawAt(this.Point.X, this.Point.Y + 1, "/ \\", ConsoleColor.Gray);
                    }
                    else
                    {
                        upLeft = this.Point - diagonalInc * Frames;
                        upRight = this.Point - diagonalDec * Frames;
                        downRight = this.Point + diagonalInc * Frames;
                        downLeft = this.Point + diagonalDec * Frames;
                        Printing.DrawAt(this.Point,'x',ConsoleColor.Gray);
                        char[] c = { '\\', '/', '/', '\\' };
                        PrintAndClearExplosion(false,c,ConsoleColor.Gray);
                    }
                    break;
                case ObjectType.Gold:
                    if (!this.GotHit)
                    {
                        Printing.DrawAt(this.Point.X, this.Point.Y - 1, " \u25B2", ConsoleColor.Yellow);
                        Printing.DrawAt(this.Point, "\u25C4\u25A0\u25BA", ConsoleColor.Yellow);
                        Printing.DrawAt(this.Point.X, this.Point.Y + 1, " \u25BC", ConsoleColor.Yellow);
                    }
                    else
                    {
                        upLeft = this.Point - diagonalInc * Frames;
                        upRight = this.Point - diagonalDec * Frames;
                        downRight = this.Point + diagonalInc * Frames;
                        downLeft = this.Point + diagonalDec * Frames;
                        char[] c = {'\u25B2', '\u25BA', '\u25C4', '\u25BC'};
                        PrintAndClearExplosion(false, c, ConsoleColor.Yellow);
                    }
                    break; 
                case ObjectType.Lenghty:
                    if (!this.GotHit)
                    {
                        Printing.DrawAt(this.Point, "{\u25A0\u25A0\u25BA");
                    }
                    else
                    {
                        upLeft = this.Point - diagonalInc * Frames;
                        upRight = this.Point - diagonalDec * Frames;
                        downRight = this.Point + diagonalInc * Frames;
                        downLeft = this.Point + diagonalDec * Frames;
                        char[] c = { '{', '\u25BA', '\u25A0', '\u25A0' };
                        PrintAndClearExplosion(false, c);
                    }
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
                   #region Normal object clearing and breaking effect
		            if (!this.GotHit)
                    {
                        Printing.DrawAt(this.Point, "  ");
                        Printing.DrawAt(this.Point.X, Point.Y + 1, "  ");
                    }
                    else
                    {
                        upRight = this.Point - diagonalDec * Frames;
                        upLeft = this.Point + diagonalDec * Frames;
                        downLeft = this.Point - diagonalInc * Frames;
                        downRight = this.Point + diagonalInc * Frames;
                        Moveable = false;
                        PrintAndClearExplosion(true);                        
                        if (Frames == 5)
                        {
                            this.toBeDeleted = true;
                        }
                        Frames++;
                    }  
	                #endregion
                    break;
                case ObjectType.Small:
                    #region Small object clearing and breaking effect
		            if (!this.GotHit)
                    {
                        Printing.DrawAt(this.Point, "   ");
                    }
                    else
                    {
                        upRight = new Point2D(this.Point.X + Frames + 1, this.Point.Y);
                        upLeft = new Point2D(this.Point.X - Frames, this.Point.Y);
                        downRight = new Point2D(this.Point.X, this.Point.Y + Frames);
                        downLeft = new Point2D(this.Point.X, this.Point.Y - Frames);
                        Moveable = false;
                        PrintAndClearExplosion(true);
                        if (Frames == 5)
                        {
                            toBeDeleted = true;
                        }
                        Frames++;
                    }  
	                #endregion
                    break;
                case ObjectType.Silver:
                    #region Silver object clearing and breaking effect
                    if (!this.GotHit)
                    {
                        Printing.DrawAt(this.Point.X, this.Point.Y - 1, "   ");
                        Printing.DrawAt(this.Point, "   ");
                        Printing.DrawAt(this.Point.X, this.Point.Y + 1, "   ");
                    }
                    else
                    {
                        upRight = this.Point - diagonalDec * Frames;
                        upLeft = this.Point + diagonalDec * Frames;
                        downRight = this.Point - diagonalInc * Frames;
                        downLeft = this.Point + diagonalInc * Frames;
                        Printing.ClearAtPosition(this.Point);
                        Moveable = false;
                        PrintAndClearExplosion(true);
                        if (Frames == 5)
                        {
                            this.toBeDeleted = true;
                        }
                        Frames++;
                    } 
	                #endregion
                    break;
                case ObjectType.Gold:
                    #region Gold object clearing and breaking effect math
		            if (!this.GotHit)
                    {
                        Printing.DrawAt(this.Point.X, this.Point.Y - 1, "  ");
                        Printing.DrawAt(this.Point, "   ");
                        Printing.DrawAt(this.Point.X, this.Point.Y + 1, "  ");
                    }
                    else
                    {
                        upRight = this.Point - diagonalDec * Frames;
                        upLeft = this.Point + diagonalDec * Frames;
                        downRight = this.Point - diagonalInc * Frames;
                        downLeft = this.Point + diagonalInc * Frames;
                        PrintAndClearExplosion(true);
                        if (Frames == 5)
                        {
                            this.toBeDeleted = true;
                        }
                        Frames++;
                    } 
	                #endregion
                    break;
                case ObjectType.Lenghty:
                    #region Lenghty object clear and breaking effect math
		            if (!this.GotHit)
                    {
                        Printing.DrawAt(this.Point, "    ");
                    }
                    else
                    {
                        upRight = this.Point - diagonalDec * Frames;
                        upLeft = this.Point + diagonalDec * Frames;
                        downLeft = this.Point - diagonalInc * Frames;
                        downRight = this.Point + diagonalInc * Frames;
                        Moveable = false;
                        PrintAndClearExplosion(true);
                        if (Frames == 5)
                        {
                            this.toBeDeleted = true;
                        }
                        Frames++;
                    }   
	                #endregion
                    break;

            }
        }

        public void MoveObject()
        {
            if (Moveable)
            {
                this.Point.X -= Speed;
            }
        }

        private void PrintAndClearExplosion(bool clear, char[] c = null,ConsoleColor clr = ConsoleColor.White)
        {
            
            if (c == null && !clear)
            {
                c = new[] { '*', '*', '*', '*' };
            }
            else if (clear)
            {
                c = new[] { ' ', ' ', ' ', ' ' };
            }
            if ((upLeft.X > 1 && upLeft.X < 79) && (upLeft.Y > 1 && upLeft.Y < 30))
            {
                Printing.DrawAt(upLeft, c[0], clr);
            }
            if ((upRight.X > 1 && upRight.X < 79) && (upRight.Y > 1 && upRight.Y < 30))
            {
                Printing.DrawAt(upRight, c[1], clr);
            }
            if ((downLeft.X > 1 && downLeft.X < 79) && (downLeft.Y > 1 && downLeft.Y < 30))
            {
                Printing.DrawAt(downLeft, c[2], clr);
            }
            if ((downRight.X > 1 && downRight.X < 79) && (downRight.Y > 1 && downRight.Y < 30))
            {
                Printing.DrawAt(downRight, c[3], clr);
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
            if (GotHit)
            {
                return false;
            }
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
                    {
                        return true;
                    }
                    else 
                    { 
                        return false;
                    }
                    ;
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
