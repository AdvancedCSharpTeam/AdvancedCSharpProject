using System;
using System.ComponentModel;
using System.Data.SqlClient;
using TeamWork.Field;

namespace TeamWork.Objects
{
    public class BossObject : Entity
    {
        public enum ObjectType
        {
            Rocket,
            Bullet,
            Laser,
            Mine,
            SoundWave
        }

        private ObjectType objectType;
        private int lifeOnScreen;

        #region Constructors
        public BossObject()
        {
            base.Speed = 1;
            
        }

        public BossObject(Point2D point)
            : base(point)
        {
            base.Speed = 1;
            base.Point = point;
            objectType = 0;
        }

        public BossObject(Point2D point, int type)
            : base(point)
        {
            base.Speed = 1;
            base.Point = point;
            objectType = (ObjectType)type;
            switch (objectType)
            {
                case ObjectType.Rocket:
                    lifeOnScreen = 45;
                    break;
                case ObjectType.Bullet:
                    lifeOnScreen = 60;
                    break;
                case ObjectType.Laser:
                    lifeOnScreen = 20;
                    break;
                case ObjectType.Mine:
                    lifeOnScreen = 25;
                    break;
                case ObjectType.SoundWave:
                    lifeOnScreen = 15;
                    break;
            }
        }
        #endregion

        #region Get Methods
        public int GetLifeOnScreen()
        {
            return lifeOnScreen;
        }

        public ObjectType GetObjectType()
        {
            return objectType;
        }
        public override string ToString()
        {
            return string.Format("|");
        } 
        #endregion
        
        public void MoveObject()
        {
            int direction = Engine.rnd.Next(1, 4);
            switch (objectType)
            {

                case ObjectType.Rocket:
                    #region Rocket Movement
                    if (direction == 1)
                    {
                        this.Point.X--;
                        this.Point.Y--;
                        lifeOnScreen--;
                    }
                    if (direction == 2)
                    {
                        this.Point.X--;
                        lifeOnScreen--;
                    }
                    if (direction == 3)
                    {
                        this.Point.X--;
                        this.Point.Y++;
                        lifeOnScreen--;
                    }
                    break; 
                #endregion
               
                case ObjectType.Bullet:
                    #region Bullet Movement
                    this.Point.X -= 2;
                    lifeOnScreen -= 2;
                    break; 
                #endregion

                case ObjectType.Laser:
                    #region Laser Movement
                    if (lifeOnScreen > 8)
                    {
                        if (lifeOnScreen % 2 == 0)
                        {
                            this.Point.Y--;
                        }
                        else
                        {
                            this.Point.Y++;
                        } 
                    }
                    this.lifeOnScreen--;
                    break;

                #endregion

                case ObjectType.Mine:
                    #region Mine Movement
                    if (lifeOnScreen > 20)
                    {
                        if (direction == 1)
                        {
                            this.Point.X -= 6;
                            this.Point.Y -= 2;
                            lifeOnScreen--;
                        }
                        if (direction == 2)
                        {
                            this.Point.X -= 6;
                            lifeOnScreen--;
                        }
                        if (direction == 3)
                        {
                            this.Point.X -= 6;
                            this.Point.Y += 2;
                            lifeOnScreen--;
                        }
                    }
                    else if (lifeOnScreen > 10)
                    {
                        if (direction == 1)
                        {
                            this.Point.X -= 3;
                            this.Point.Y -= 1;
                            lifeOnScreen--;
                        }
                        if (direction == 2)
                        {
                            this.Point.X -= 3;
                            lifeOnScreen--;
                        }
                        if (direction == 3)
                        {
                            this.Point.X -= 3;
                            this.Point.Y += 1;
                            lifeOnScreen--;
                        }
                    }
                    else if (lifeOnScreen >= 6)
                    {

                        if (lifeOnScreen%2 == 0)
                        {
                            if (direction == 1)
                            {
                                this.Point.X--;
                                this.Point.Y--;
                                lifeOnScreen--;
                            }
                            if (direction == 2)
                            {
                                this.Point.X--;
                                lifeOnScreen--;
                            }
                            if (direction == 3)
                            {
                                this.Point.X--;
                                this.Point.Y++;
                                lifeOnScreen--;
                            }
                        }
                    }
                    lifeOnScreen--;
                    break;

                #endregion

                case ObjectType.SoundWave:
                    #region Soundwave Movement
                    this.Point.X--;
                    lifeOnScreen--;
                    break; 
                    #endregion
            }
        }

        /// <summary>
        /// Print GameObject based on its type
        /// </summary>
        private int Frames = 1;

        private bool mineHit, mineHit2, mineHit3, mineHit4;
        private Point2D diagonalInc = new Point2D(1,1);
        private Point2D diagonalDec = new Point2D(-1,1);
        public void PrintObject()
        {
            switch (objectType)
            {
                case ObjectType.Rocket:
                    #region Rocket Print
                    Printing.DrawAt(this.Point, "<>");
                    break; 
                    #endregion

                case ObjectType.Bullet:
                    #region Bullet Print
                    Printing.DrawAt(this.Point, '-', ConsoleColor.DarkCyan);
                    Printing.DrawAt(this.Point.X,this.Point.Y + 1, '-', ConsoleColor.DarkCyan);
                    Printing.DrawAt(this.Point.X,this.Point.Y - 1,'-', ConsoleColor.DarkCyan);
                    break; 
                    #endregion

                case ObjectType.Laser:
                    #region Laser Print
                    if (this.lifeOnScreen > 8)
                    {
                        Engine.boss.movealbe = false;
                        Printing.DrawAtBG(this.Point.X + 5, this.Point.Y - 1, @"<----.     __ / __   \", ConsoleColor.DarkGray);
                        Printing.DrawAtBG(this.Point.X + 5, this.Point.Y, @"<----|====O)))==) \) /", ConsoleColor.Gray);
                        Printing.DrawAtBG(this.Point.X + 5, this.Point.Y + 1, "<----'    `--' `.__,'", ConsoleColor.DarkGray);
                        Console.ResetColor();
                    }
                    else
                    {
                        Printing.DrawAtBG(this.Point.X - 50, this.Point.Y - 1, "-------------------------------------------------------<----.", ConsoleColor.DarkGray);
                        Printing.DrawAtBG(this.Point.X - 50, this.Point.Y, "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~<----|", ConsoleColor.Gray);
                        Printing.DrawAtBG(this.Point.X - 50, this.Point.Y + 1, "-------------------------------------------------------<----'", ConsoleColor.DarkGray);
                        Console.ResetColor();
                        for (int i = 0; i < 53; i++)
                        {
                            if (Printing.Player.ShipCollided(Point.X - 50 + i, Point.Y))
                            {
                                break;
                            }
                        }
                        if (lifeOnScreen < 1)
                        {
                            Engine.boss.movealbe = true;
                        }
                    }
                    break; 
                    #endregion

                case ObjectType.Mine:
                    #region Mine Print

                    if (this.lifeOnScreen > 10)
                    {
                        Printing.DrawAt(this.Point.X, this.Point.Y - 1, " \u25B2", ConsoleColor.Yellow);
                        Printing.DrawAt(this.Point, "\u25C4\u25A0\u25BA", ConsoleColor.Yellow);
                        Printing.DrawAt(this.Point.X, this.Point.Y + 1, " \u25BC", ConsoleColor.Yellow);
                    }
                    else
                    {
                        Point2D upRight = this.Point - diagonalDec * Frames;
                        if (mineHit) upRight.X += 1000;

                        Point2D upLeft = this.Point + diagonalDec * Frames;
                        if (mineHit2) upLeft.X += 1000;

                        Point2D downLeft = this.Point - diagonalInc * Frames;
                        if (mineHit3) downLeft.X += 1000;

                        Point2D downRight = this.Point + diagonalInc * Frames;
                        if (mineHit4) downRight.X += 1000;

                        if ((upLeft.X > 1 && upLeft.X < 79) && (upLeft.Y > 1 && upLeft.Y < 30))
                        {
                            Printing.DrawAt(upLeft, '*');
                        }
                        if ((upRight.X > 1 && upRight.X < 79) && (upRight.Y > 1 && upRight.Y < 30))
                        {
                            Printing.DrawAt(upRight, '*');
                        }
                        if ((downLeft.X > 1 && downLeft.X < 79) && (downLeft.Y > 1 && downLeft.Y < 30))
                        {
                            Printing.DrawAt(downLeft, '*');
                        }
                        if ((downRight.X > 1 && downRight.X < 79) && (downRight.Y > 1 && downRight.Y < 30))
                        {
                            Printing.DrawAt(downRight, '*');
                        }
                    }
                    break; 
                    #endregion

                case ObjectType.SoundWave:
                    #region SoundWave Print
                    
                    for (int i = 0 - Frames; i < Frames; i++)
                    {
                        if ((this.Point.Y - i > 4 && this.Point.Y + i < Engine.WindowHeight - 4))
                        {
                            Printing.DrawAt(this.Point.X, this.Point.Y - i, "/", ConsoleColor.Gray);
                            Printing.DrawAt(this.Point.X, this.Point.Y + i, "\\", ConsoleColor.Gray);
                        }
                    }
                    Frames++;
                    break; 
                    #endregion
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
                    #region Bullet Clear
                    Printing.DrawAt(this.Point.X, this.Point.Y, ' ');
                    Printing.DrawAt(this.Point.X, this.Point.Y + 1, ' ');
                    Printing.DrawAt(this.Point.X, this.Point.Y - 1, ' ');
                    if (Printing.Player.ShipCollided(this.Point) ||
                        Printing.Player.ShipCollided(Point.X, Point.Y + 1)||
                        Printing.Player.ShipCollided(Point.X, Point.Y - 1))
                    {
                        this.Point.X += 1000;
                    }
                    break; 
                    #endregion

                case ObjectType.Rocket:
                    #region Rocket Clear
                    Printing.DrawAt(this.Point, "  ");
                    if (Printing.Player.ShipCollided(this.Point))
                    {
                        this.Point.X += 1000;
                    }
                    break; 
                    #endregion

                case ObjectType.Laser:
                    #region Laser Clear
                    if (this.lifeOnScreen > 5)
                    {
                        Printing.DrawAt(this.Point.X, this.Point.Y - 2, "                      ");
                        Printing.DrawAt(this.Point.X, this.Point.Y - 1, "                      ");
                        Printing.DrawAt(this.Point.X, this.Point.Y, "             ");
                        Printing.DrawAt(this.Point.X, this.Point.Y + 1, "              ");
                    }
                    else
                    {
                        Printing.DrawAt(this.Point.X - 50, this.Point.Y - 1, "                                                         ");
                        Printing.DrawAt(this.Point.X - 50, this.Point.Y, "                                                         ");
                        Printing.DrawAt(this.Point.X - 50, this.Point.Y + 1, "                                                         ");
                    }
                    break; 
                    #endregion

                case ObjectType.Mine:
                    #region Mine Clear
                    if (this.lifeOnScreen > 10)
                    {
                        Printing.DrawAt(this.Point.X, this.Point.Y - 1, "  ");
                        Printing.DrawAt(this.Point, "   ");
                        Printing.DrawAt(this.Point.X, this.Point.Y + 1, "  ");
                    }
                    else
                    {
                        Point2D upRight = this.Point - diagonalDec * Frames;
                        if (mineHit) upRight.X += 1000;
                        if (Printing.Player.ShipCollided(upRight)) mineHit = true;

                        Point2D upLeft = this.Point + diagonalDec * Frames;
                        if (mineHit2) upLeft.X += 1000;
                        if (Printing.Player.ShipCollided(upLeft)) mineHit2 = true;

                        Point2D downLeft = this.Point - diagonalInc * Frames;
                        if (mineHit3) downLeft.X += 1000;
                        if (Printing.Player.ShipCollided(downLeft)) mineHit3 = true;

                        Point2D downRight = this.Point + diagonalInc * Frames;
                        if (mineHit4) downRight.X += 1000;
                        if (Printing.Player.ShipCollided(downRight)) mineHit4 = true;

                        if ((upLeft.X > 1 && upLeft.X < 79) && (upLeft.Y > 1 && upLeft.Y < 30))
                        {
                            Printing.DrawAt(upLeft, ' ');
                        }
                        if ((upRight.X > 1 && upRight.X < 79) && (upRight.Y > 1 && upRight.Y < 30))
                        {
                            Printing.DrawAt(upRight, ' ');
                        }
                        if ((downLeft.X > 1 && downLeft.X < 79) && (downLeft.Y > 1 && downLeft.Y < 30))
                        {
                            Printing.DrawAt(downLeft, ' ');
                        }
                        if ((downRight.X > 1 && downRight.X < 79) && (downRight.Y > 1 && downRight.Y < 30))
                        {
                            Printing.DrawAt(downRight, ' ');
                        }
                        Frames++;
                    }
                    break;
                    #endregion

                case ObjectType.SoundWave:
                    #region SoundWave Clear
                    for (int i = 0; i < Frames; i++)
                    {
                        if ((this.Point.Y - i > 4 && this.Point.Y + i < Engine.WindowHeight - 4))
                        {
                            Printing.DrawAt(this.Point.X, this.Point.Y - i, "  ", ConsoleColor.Gray);
                            Printing.DrawAt(this.Point.X, this.Point.Y + i, "  ", ConsoleColor.Gray);
                        }
                        
                    }
                    break; 
                    #endregion
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
                case ObjectType.Bullet:
                    /*
                     * (.)AB
                     * (.)CD
                     */
                    if ((x == this.Point.X && (y == this.Point.Y ||  y == this.Point.Y + 1)) || // A / C
                        (x == this.Point.X + 1 &&
                        (y == this.Point.Y || y == this.Point.Y + 1)) || // B / D
                        (x == this.Point.X - 1 &&
                        (y == this.Point.Y || y == this.Point.Y + 1)))// ..
                        return true;
                    return false;
                case ObjectType.Rocket:
                    /*
                     * (.)AB              
                     */
                    if ((x == this.Point.X && y == this.Point.Y) || // A
                        (x == this.Point.X+1 && y == this.Point.Y) || // B
                        (x == this.Point.X - 1 && y == this.Point.Y)) // .
                        return true;
                    return false;
                case ObjectType.SoundWave:
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
                case ObjectType.Mine: 
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
                case ObjectType.Laser:
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
