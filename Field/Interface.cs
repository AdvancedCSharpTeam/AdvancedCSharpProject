using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork.Field
{
    class Interface
    {
        public static void Table()
        {
            //  Top
            for (int i = 0; i < 80; i++)
            {
                if (i < 37 || i > 42)
                {
                    Printing.DrawAt(new Point2D(i, 0), '\u2591', ConsoleColor.DarkRed);

                }
                Printing.DrawAt(new Point2D(i, 1), '\u255D', ConsoleColor.DarkRed);
            }
            // Bottom
            for (int i = 0; i < 80; i++)
            {
                Printing.DrawAt(new Point2D(i, 29), '\u2550', ConsoleColor.DarkGray);
                Printing.DrawAt(new Point2D(i, 30), '\u2566', ConsoleColor.DarkRed);
            }
            Printing.DrawAt(new Point2D(20, 29), '\u2566', ConsoleColor.DarkGray);   //live
            Printing.DrawAt(new Point2D(20, 30), '\u2551', ConsoleColor.DarkGray);   //live
            Printing.DrawAt(new Point2D(40, 29), '\u2566', ConsoleColor.DarkGray);   //ammo
            Printing.DrawAt(new Point2D(40, 30), '\u2551', ConsoleColor.DarkGray);   //ammo
            Printing.DrawAt(new Point2D(58, 29), '\u2566', ConsoleColor.DarkGray);   //score
            Printing.DrawAt(new Point2D(58, 30), '\u2551', ConsoleColor.DarkGray);   //score

        }


        public static void UIDescription()
        {
            string level = "LvL";
            string live = string.Format(" Lives: {0}", Printing.Player.Lives);
            string score = string.Format(" Score: {0}", Printing.Player.Score);
            string ammo = " Ammo: ";
            string playerName = string.Format("Player: {0}", Printing.Player.Name);

            Printing.DrawAt(new Point2D(3, 0), playerName, ConsoleColor.DarkYellow);
            Printing.DrawAt(new Point2D(39, 0), level, ConsoleColor.DarkYellow);

            Printing.DrawAt(new Point2D(3, 30), live, ConsoleColor.DarkYellow);
            Printing.DrawAt(new Point2D(25, 30), ammo, ConsoleColor.DarkYellow);
            Printing.DrawAt(new Point2D(60, 30), score, ConsoleColor.DarkYellow);
        }
    }
}
