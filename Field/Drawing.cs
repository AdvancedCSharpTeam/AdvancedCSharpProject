using System;

namespace TeamWork.Field
{
    public static class Drawing
    {
        #region Constants
        private const string Logo = @"
              _    _  ____  __    ___  _____  __  __  ____
             ( \/\/ )( ___)(  )  / __)(  _  )(  \/  )( ___)
              )    (  )__)  )(__( (__  )(_)(  )    (  )__)
             (__/\__)(____)(____)\___)(_____)(_/\/\_)(____)
                         Made by: Team ECHIDNA    
 
                                                                         
                           ._`-\ )\,`-.-.
                          \'\` \)\ \)\ \|.)
                        \`)  |\)  )\ .)\ )\|
                        \ \)\ |)\  `   \ .')/|
                       ``-.\ \    )\ `  . ., '(
                       \\ -. `)\``- ._ .)` |\(,_
                       `__  '\ `--  _\`. `    (/
                         `\,\       .\\        /
                            '` )  (`-.\\       `
                               /||\   `.  * _*|
                                        `-.( `\
                                            `. \
                                              `() ";
        private const string gameOver = @"
_______  _______  _______  _______    _______           _______  _______
(  ____ \(  ___  )(       )(  ____ \  (  ___  )|\     /|(  ____ \(  ____ )
| (    \/| (   ) || /   \ || (    \/  | (   ) || )   ( || (    \/| (    )|
| |      | (___) || || || || (__      | |   | || |   | || (__    | (____)|
| | ____ |  ___  || ||_|| ||  __)     | |   | |( (   ) )|  __)   |     __)
| | \_  )| (   ) || |   | || (        | |   | | \ \_/ / | (      | (\ (  
| (___) || )   ( || )   ( || (____/\  | (___) |  \   /  | (____/\| ) \ \__
(_______)|/     \||/     \|(_______/  (_______)   \_/   (_______/|/   \__/";

        private const string credits = @"
                         _____           ___ __    
                        / ___/______ ___/ (_) /____
                       / /__/ __/ -_) _  / / __(_-<
                       \___/_/  \__/\_,_/_/\__/___/
                             
                              TEAM ECHIDNA:
 
                              Inspix
                              Gogok
                              DHristoskov
                              NKNenkov
                              nOwayOut
                              Shano"; 
        #endregion

        public static void DrawAt(Point2D point, object obj)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(obj.ToString());
        }

        public static void DrawAt(int x,int y, object obj)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(obj.ToString());
        }

        public static void DrawAt(int x, int y, object obj, ConsoleColor clr)
        {
            Console.ForegroundColor = clr;
            DrawAt(x,y, obj);
            Console.ResetColor();
        }

        public static void DrawAt(Point2D point, object obj, ConsoleColor clr)
        {
            Console.ForegroundColor = clr;
            DrawAt(point, obj);
            Console.ResetColor();
        }

        public static void DrawVLineAt(Point2D point, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                DrawAt(point, obj, clr);
                point.Y++;
            }
        }

        public static void DrawHLineAt(Point2D point, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                DrawAt(point, obj, clr);
                point.X++;
            }
        }

        public static void DrawRectangleAt(Point2D point, int size, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            for (int i = 0, side1 = 0; i < size; i++)
            {
                DrawAt(point.X + side1++,point.Y, obj, clr);
            }

            for (int i = 0, side2 = 0; i < size; i++)
            {
                DrawAt(point.X + size-1, point.Y + side2++, obj, clr);
            }

            for (int i = 0,side3 = 0; i < size; i++)
            {
                DrawAt(point.X + side3++, point.Y + size, obj, clr);
            }

            for (int i = 0,side4 = 0; i < size; i++)
            {
                DrawAt(point.X , point.Y + side4++, obj, clr);
            }
        }

        public static void WelcomeScreen()
        {
            DrawAt(0,0,Logo,ConsoleColor.Cyan);
        }

        public static void GameOver()
        {
            DrawAt(0, 0, gameOver, ConsoleColor.Cyan);
        }

        public static void Credits()
        {
            DrawAt(0, 0, credits, ConsoleColor.Cyan);
        }

    }
}
