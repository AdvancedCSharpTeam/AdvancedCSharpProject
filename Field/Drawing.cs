using System;
using System.Threading;

namespace TeamWork.Field
{
    public static class Printing
    {
        public static IPlayer Player = new Player();
        public static IGameObject GameObject = new GameObject();

        public static Point2D PlayerPoint = new Point2D(40, 29);
        public static Point2D GameFieldRightSide = new Point2D(60, 0);
        public static Point2D MenuField = new Point2D(75, 4);


        #region Constants
        private const string highScore = @"
                     _  _ _      _      ___                 
                    | || (_)__ _| |_   / __| __ ___ _ _ ___ 
                    | __ | / _` | ' \  \__ \/ _/ _ \ '_/ -_)
                    |_||_|_\__, |_||_| |___/\__\___/_| \___|
                           |___/                            ";
        private const string gameName = @"
.                                                               +
      .           +                 ,             *                             
   .                             .     .                         .        
     ,              *                     .                '
                                .                                       '
          ____  ____  ____  ____    ____  ____   __    ___  ____ 
         (    \(  __)(  __)(  _ \  / ___)(  _ \ / _\  / __)(  __)
          ) D ( ) _)  ) _)  ) __/  \___ \ ) __//    \( (__  ) _)    *
         (____/(____)(____)(__)    (____/(__)  \_/\_/ \___)(____)                                                               
   .                              +                          .                   
                  *         .                                            .      
      .                             .                   *                       
          .  .                                .                    .          
____^/\___^--_O__/\_____-^^-^--_______/\/\---/\___________---___________
     -    ---  /\^             ^     ^       ^          ^       /\       
         --       __ _-                                           --  -      
   --  __                           ___--  ^  ^                                

";
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
        private const string letsPlay = @"
                  )
                 )\ )         ) (            (            
                (()/(   (  ( /( )\           )\   ) (     
                /(_)) ))\ )\()|(_|    `  ) ((_| /( )\ )  
                (_))  /((_|_))/   )\   /(/(  _ )(_)|()/(  
                | |  (_)) | |_   ((_) ((_)_\| ((_)_ )(_)) 
                | |__/ -_)|  _|  (_-< | '_ \) / _` | || | 
                |____\___| \__|  /__/ | .__/|_\__,_|\_, | 
                                      |_|           |__/";
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
                              Shano";
        private const string userName = @"
              ______       _                                         
             |  ____|     | |                                        
             | |__   _ __ | |_ ___ _ __   _ __   __ _ _ __ ___   ___ 
             |  __| | '_ \| __/ _ \ '__| | '_ \ / _` | '_ ` _ \ / _ \
             | |____| | | | ||  __/ |    | | | | (_| | | | | | |  __/
             |______|_| |_|\__\___|_|    |_| |_|\__,_|_| |_| |_|\___|";
        #endregion

        #region Printing Methods

        /// <summary>
        /// Draw an object at given X and Y Coordinates
        /// </summary>
        /// <param name="x">Column number</param>
        /// <param name="y">Row number</param>
        /// <param name="obj">Object to print</param>
        public static void DrawAt(int x, int y, object obj)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(obj.ToString());
        }


        /// <summary>
        /// Draw an object at a Point2D
        /// </summary>
        /// <param name="point">Point2D to print at</param>
        /// <param name="obj">Object to print</param>
        public static void DrawAt(Point2D point, object obj)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(obj.ToString());
        }
        /// <summary>
        /// Draw an object at given X and Y Coordinates with a color
        /// </summary>
        /// <param name="x">Column number</param>
        /// <param name="y">Row number</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawAt(int x, int y, object obj, ConsoleColor clr)
        {
            Console.ForegroundColor = clr;
            DrawAt(x, y, obj);
            Console.ResetColor();
        }

        /// <summary>
        /// Draw an object at given Point2D with color
        /// </summary>
        /// <param name="point">Point2D to print at</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawAt(Point2D point, object obj, ConsoleColor clr)
        {
            Console.ForegroundColor = clr;
            DrawAt(point, obj);
            Console.ResetColor();
        }

        /// <summary>
        /// Draw a vertical line with given lenght starting at X and Y
        /// </summary>
        /// <param name="x">Column number</param>
        /// <param name="y">Row number</param>
        /// <param name="lenght">Lenght of the line</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawVLineAt(int x, int y, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            DrawVLineAt(new Point2D(x, y), lenght, obj, clr);
        }

        /// <summary>
        /// Draw a vertical line with given lenght starting at Point2D
        /// </summary>
        /// <param name="point">Point2D to print at</param>
        /// <param name="lenght">Length of the line</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawVLineAt(Point2D point, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                DrawAt(point, obj, clr);
                point.Y++;
            }
        }


        /// <summary>
        /// Draw a horizontal line with given lenght starting at X and Y
        /// </summary>
        /// <param name="x">Column number</param>
        /// <param name="y">Row number</param>
        /// <param name="lenght">Lenght of the line</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawHLineAt(int x, int y, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                //DrawAt(point, obj, clr);
                //point.X++;
                DrawAt(x,y, obj, clr);
                x++;
            }
        }

        /// <summary>
        /// Draw a horizontal line with given lenght starting at Point2D
        /// </summary>
        /// <param name="point">Point2D to print at</param>
        /// <param name="lenght">Lenght of the line</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawHLineAt(Point2D point, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            DrawHLineAt(point.X,point.Y, lenght, obj, clr);
        }

        /// <summary>
        /// Draw a Rectangle starting at given X Y position with set size
        /// </summary>
        /// <param name="x">Column number</param>
        /// <param name="y">Row number</param>
        /// <param name="size">Size of the rectangle</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawRectangleAt(int x, int y, int size, object obj, ConsoleColor clr = ConsoleColor.White)
        {

            for (int i = 0, side1 = 0; i < size; i++)
            {
                DrawAt(x + side1++, y, obj, clr);
            }

            for (int i = 0, side2 = 0; i < size; i++)
            {
                DrawAt(x + size - 1, y + side2++, obj, clr);
            }

            for (int i = 0, side3 = 0; i < size; i++)
            {
                DrawAt(x + side3++, y + size, obj, clr);
            }

            for (int i = 0, side4 = 0; i < size; i++)
            {
                DrawAt(x, y + side4++, obj, clr);
            }
        }

        /// <summary>
        /// Draw a Rectangle starting at position Point2D with given size
        /// </summary>
        /// <param name="point">Point2D to start at</param>
        /// <param name="size">Size of the rectangle</param>
        /// <param name="obj">Object to print</param>
        /// <param name="clr">Color to print with</param>
        public static void DrawRectangleAt(Point2D point, int size, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            DrawRectangleAt(point.X,point.Y, size, obj, clr);
        }

        #endregion

        #region Clearing Methods

        /// <summary>
        /// Clear a character at given position
        /// </summary>
        /// <param name="x" >Column number</param>
        /// <param name="y" >Row number</param>
        public static void ClearAtPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        /// <summary>
        /// Clear a character at given position
        /// </summary>
        /// <param name="point">Point2D to clear at</param>
        public static void ClearAtPosition(Point2D point)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(' ');
        }

        /// <summary>
        /// Clears an area from given coordinates to given coordinates
        /// </summary>
        /// <param name="fromX"> Starting Column number</param>
        /// <param name="fromY"> Starting Row number</param>
        /// <param name="toX">Ending Column number</param>
        /// <param name="toY">Ending Row number</param>
        public static void ClearFromTo(int fromX, int fromY, int toX, int toY)
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
       /// <param name="startingPoint">Starting Point2D</param>
       /// <param name="endingPoint">Ending Point2D</param>
        public static void ClearFromTo(Point2D startingPoint, Point2D endingPoint)
        {
            ClearFromTo(startingPoint.X, startingPoint.Y, endingPoint.X, endingPoint.Y);
        }

        /// <summary>
        /// Clears a whole row at given position
        /// </summary>
        /// <param name="y">Row number</param>
        public static void ClearY(int y)
        {
            int gameWidth = 80; // should be assigned from a constant somewhere
            for (int i = 0; i < gameWidth; i++)
            {
                DrawAt(i, y, ' ');
            }
        }

        /// <summary>
        /// Clears a whole column at given position
        /// </summary>
        /// <param name="x">Column number</param>
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
        /// Draw LetsPlay Screen
        /// </summary>
        public static void LetsPlay()
        {
            DrawAt(0, 5, letsPlay, ConsoleColor.Yellow);
        }
        /// <summary>
        /// Draw UserName Screen
        /// </summary>
        public static void UserName()
        {
            DrawAt(0, 5, userName, ConsoleColor.Yellow);
        }
        /// <summary>
        /// Draw UserName Screen
        /// </summary>
        public static void HighScore()
        {
            DrawAt(0, 5, highScore, ConsoleColor.Cyan);
        }
        /// <summary>
        /// Draw GameName Screen
        /// </summary>
        public static void GameName()
        {
            DrawAt(4, 2, gameName, ConsoleColor.Cyan);
        }
        /// <summary>
        /// Draw GameOver Screen
        /// </summary>
        public static void GameOver()
        {
            DrawAt(0, 5, gameOver, ConsoleColor.Green);
        }

        /// <summary>
        /// Draw Credits
        /// </summary>
        public static void Credits()
        {
            DrawAt(0, 0, credits, ConsoleColor.Green);
        }
       
        #endregion
    }
}

