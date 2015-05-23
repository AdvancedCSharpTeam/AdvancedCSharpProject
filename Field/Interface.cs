using System;
using System.Text;

namespace TeamWork.Field
{
    class Interface
    {
        public static void Table()
        {
            //  Top birder
            for (int i = 0; i < 80; i++)
            {
                int nameBord = 14 + Printing.Player.Name.Length;
                bool topBgPos = ((i <= 3) || (i >= nameBord && i < 38) || i > 41);
                if (topBgPos)
                {
                    Printing.DrawAt(new Point2D(i, 0), '\u2591', ConsoleColor.DarkRed);
                }
            }
            // Bottom border
            for (int i = 0; i < 80; i++)
            {
                int liveBord = 13;
                int scoreBord = 30;
                if ((i <= 3) || (i > liveBord && i < scoreBord - 1) || i > scoreBord + 10)
                {
                    Printing.DrawAt(new Point2D(i, 30), '\u2591', ConsoleColor.DarkRed);           
                }
            }
        }

        /// <summary>
        /// Draw UI 
        /// </summary>
        public static void UIDescription()
        {
            string level = string.Format("{0}", Printing.Player.Level).PadLeft(2, '0');
            string live = string.Format("Lives: ");     

            string score = string.Format("Score: {0} ", Printing.Player.Score).PadLeft(3, '0');
            string playerName = string.Format("Player: {0}", Printing.Player.Name);

            Printing.DrawAt(new Point2D(5, 0), playerName, ConsoleColor.DarkYellow);
            Printing.DrawAt(new Point2D(39, 0), level, ConsoleColor.DarkYellow);
            Printing.DrawAt(new Point2D(5, 30), live, ConsoleColor.DarkYellow);
            Printing.DrawHLineAt(11, 30, Printing.Player.Lives, '\u2665',ConsoleColor.Red); 
            Printing.ClearAtPosition(11 + Printing.Player.Lives ,30);
            Printing.DrawAt(new Point2D(30, 30), score, ConsoleColor.DarkYellow);
        }
    }
}
