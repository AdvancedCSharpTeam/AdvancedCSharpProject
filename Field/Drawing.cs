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
                                              `() 
                 (                                        
                 )\ )         ) (            (            
                (()/(   (  ( /( )\           )\   ) (     
                /(_)) ))\ )\()|(_|    `  ) ((_| /( )\ )  
                (_))  /((_|_))/   )\   /(/(  _ )(_)|()/(  
                | |  (_)) | |_   ((_) ((_)_\| ((_)_ )(_)) 
                | |__/ -_)|  _|  (_-< | '_ \) / _` | || | 
                |____\___| \__|  /__/ | .__/|_\__,_|\_, | 
                                      |_|           |__/  ";
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

        #region Drawing Methods
        /// <summary>
        /// Draw an object at a Point2D
        /// </summary>
        /// <param name="point"></param>
        /// <param name="obj"></param>
        public static void DrawAt(Point2D point, object obj)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(obj.ToString());
        }

        /// <summary>
        /// Draw an object at given X and Y Coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="obj"></param>
        public static void DrawAt(int x, int y, object obj)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(obj.ToString());
        }

        /// <summary>
        /// Draw an object at given X and Y Coordinates with a color
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="obj"></param>
        /// <param name="clr"></param>
        public static void DrawAt(int x, int y, object obj, ConsoleColor clr)
        {
            Console.ForegroundColor = clr;
            DrawAt(x, y, obj);
            Console.ResetColor();
        }

        /// <summary>
        /// Draw an object at given Point2D with color
        /// </summary>
        /// <param name="point"></param>
        /// <param name="obj"></param>
        /// <param name="clr"></param>
        public static void DrawAt(Point2D point, object obj, ConsoleColor clr)
        {
            Console.ForegroundColor = clr;
            DrawAt(point, obj);
            Console.ResetColor();
        }

        /// <summary>
        /// Draw a vertical line with given lenght starting at Point2D
        /// </summary>
        /// <param name="point"></param>
        /// <param name="lenght"></param>
        /// <param name="obj"></param>
        /// <param name="clr"></param>
        public static void DrawVLineAt(Point2D point, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                DrawAt(point, obj, clr);
                point.Y++;
            }
        }

        /// <summary>
        /// Draw a vertical line with given lenght starting at X and Y
        /// </summary>
        /// <param name="point"></param>
        /// <param name="lenght"></param>
        /// <param name="obj"></param>
        /// <param name="clr"></param>
        public static void DrawVLineAt(int x, int y, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            DrawVLineAt(new Point2D(x, y), lenght, obj, clr);
        }

        /// <summary>
        /// Draw a horizontal line with given lenght starting at Point2D
        /// </summary>
        /// <param name="point"></param>
        /// <param name="lenght"></param>
        /// <param name="obj"></param>
        /// <param name="clr"></param>
        public static void DrawHLineAt(Point2D point, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                DrawAt(point, obj, clr);
                point.X++;
            }
        }

        /// <summary>
        /// Draw a horizontal line with given lenght starting at X and Y
        /// </summary>
        /// <param name="point"></param>
        /// <param name="lenght"></param>
        /// <param name="obj"></param>
        /// <param name="clr"></param>
        public static void DrawHLineAt(int x, int y, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            DrawHLineAt(new Point2D(x, y), lenght, obj, clr);
        }

        /// <summary>
        /// Draw a Rectangle starting at position Point2D with given size
        /// </summary>
        /// <param name="point"></param>
        /// <param name="size"></param>
        /// <param name="obj"></param>
        /// <param name="clr"></param>
        public static void DrawRectangleAt(Point2D point, int size, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            for (int i = 0, side1 = 0; i < size; i++)
            {
                DrawAt(point.X + side1++, point.Y, obj, clr);
            }

            for (int i = 0, side2 = 0; i < size; i++)
            {
                DrawAt(point.X + size - 1, point.Y + side2++, obj, clr);
            }

            for (int i = 0, side3 = 0; i < size; i++)
            {
                DrawAt(point.X + side3++, point.Y + size, obj, clr);
            }

            for (int i = 0, side4 = 0; i < size; i++)
            {
                DrawAt(point.X, point.Y + side4++, obj, clr);
            }
        }

        /// <summary>
        /// Draw a Rectangle starting at position X Y with given size
        /// </summary>
        /// <param name="point"></param>
        /// <param name="size"></param>
        /// <param name="obj"></param>
        /// <param name="clr"></param>
        public static void DrawRectangleAt(int x, int y, int size, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            DrawRectangleAt(new Point2D(x, y), size, obj, clr);
        }
        
        #endregion

        #region Clearing Methods

        /// <summary>
        /// Clear a character at given position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void ClearAtPosition(int x, int y)
        {
            Console.SetCursorPosition(x,y);
            Console.Write(' ');
        }

        /// <summary>
        /// Clear a character at given position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void ClearAtPosition(Point2D point)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(' ');
        }

        /// <summary>
        /// Clears an area from given coordinates to given coordinates
        /// </summary>
        /// <param name="fromX"></param>
        /// <param name="fromY"></param>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
        public static void ClearFromTo(int fromX, int fromY,int toX,int toY)
        {
            Console.SetCursorPosition(fromX, fromY);
            string x = new string(' ', toX - fromX);
            for (int i = fromY; i < toY; i++)
            {
                Console.WriteLine(x);
            }
        }

        /// <summary>
        /// Clears an area from given coordinates to given coordinates
        /// </summary>
        /// <param name="fromX"></param>
        /// <param name="fromY"></param>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
        public static void ClearFromTo(Point2D startingPoint, Point2D endingPoint)
        {
            ClearFromTo(startingPoint.X,startingPoint.Y,endingPoint.X,endingPoint.Y);
        }

        /// <summary>
        /// Clears a whole row at given position
        /// </summary>
        /// <param name="y"></param>
        public static void ClearY(int y)
        {
            int gameWidth = 80; // should be assigned from a constant somewhere
            for (int i = 0; i < gameWidth; i++)
            {
                DrawAt(i,y,' ');
            }
        }

        /// <summary>
        /// Clears a whole columnt at given position
        /// </summary>
        /// <param name="x"></param>
        public static void ClearX(int x)
        {
            int gameHeight = 30; // should be assigned from a constant somewhere
            for (int i = 0; i < gameHeight; i++)
            {
                DrawAt(x, i, ' ');
            }
        }

        #endregion

        #region Logos
        /// <summary>
        /// Draw Welcome Screen
        /// </summary>
        public static void WelcomeScreen()
        {
            DrawAt(0, 0, Logo, ConsoleColor.Cyan);
        }

        /// <summary>
        /// Draw GameOver Screen
        /// </summary>
        public static void GameOver()
        {
            DrawAt(0, 0, gameOver, ConsoleColor.Cyan);
        }

        /// <summary>
        /// Draw Credits
        /// </summary>
        public static void Credits()
        {
            DrawAt(0, 0, credits, ConsoleColor.Cyan);
<<<<<<< HEAD
        }
        public static string generateObject()
        {
            string generatedObject = string.Empty;
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                generatedObject += rnd.Next(0, 2);
            }
            return generatedObject;
        }
=======
        } 
        #endregion

>>>>>>> acd9a750828bef7da253f863ad46525c36f5692e
    }
}
