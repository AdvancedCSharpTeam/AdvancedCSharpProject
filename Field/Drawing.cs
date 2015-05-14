using System;

namespace TeamWork.Field
{
    public static class Drawing
    {
        public static void DrawAt(int x, int y, object obj)
        {
            Console.SetCursorPosition(x,y);
            Console.Write(obj.ToString());
        }

        public static void DrawAt(int x, int y, object obj, ConsoleColor clr )
        {
            Console.ForegroundColor = clr;
            DrawAt(x,y,obj);
            Console.ResetColor();
        }

        public static void DrawVLineAt(int x, int y, int lenght, object obj,ConsoleColor clr = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                DrawAt(x,y,obj,clr);
                y++;
            }
        }

        public static void DrawHLineAt(int x, int y, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                DrawAt(x, y, obj, clr);
                x++;
            }
        }

        public static void DrawRectangleAt(int x, int y, int size, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            for (int i = 0, side1 = 0; i < size; i++)
            {
                DrawAt(x + side1++, y, obj, clr);
            }

            for (int i = 0, side2 = 0; i < size; i++)
            {
                DrawAt(x + size-1, y + side2++, obj, clr);
            }

            for (int i = 0,side3 = 0; i < size; i++)
            {
                DrawAt(x + side3++, y + size, obj, clr);
            }

            for (int i = 0,side4 = 0; i < size; i++)
            {
                DrawAt(x , y + side4++, obj, clr);
            }
        }

    }
}
