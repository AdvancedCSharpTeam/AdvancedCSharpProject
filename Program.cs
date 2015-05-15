using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWork.Field;


namespace TeamWork
{
    class Program
    {
        static void Main(string[] args)
        {           
            Engine.InitConsole(); // Must initialize the console size before starting the engine
            //Engine eng = new Engine();
            //eng.Start();


            IEntity player = new Player();
            Console.WriteLine("({0}, {1})", player.Point.X, player.Point.Y);
            Console.WriteLine();

            Console.WriteLine("Fast");
            Point2D pointOne = new Point2D(5, 7);
            IEntity objectOne = new FastObject(pointOne);
            Console.WriteLine("({0}, {1})", objectOne.Point.X, objectOne.Point.Y);
            Console.WriteLine("{0}", objectOne.Speed);

            Console.WriteLine();

            Console.WriteLine("Slow");
            Point2D pointTwo = new Point2D(10, 6);
            IEntity objectTwo = new SlowObject(pointTwo);
            Console.WriteLine("({0}, {1})", objectTwo.Point.X, objectTwo.Point.Y);
            Console.WriteLine("{0}", objectTwo.Speed);

            Drawing.WelcomeScreen();
            Console.ReadKey();
            Console.Clear();

            Drawing.DrawHLineAt(0,0,30,'*');
            Drawing.DrawHLineAt(0, 5, 30, '*');
            Drawing.DrawHLineAt(0, 10, 30, '*');
            Drawing.DrawHLineAt(0, 15, 30, '*');
            Drawing.DrawHLineAt(0, 20, 30, '*');
            Drawing.DrawHLineAt(0, 25, 80, '*');
            Drawing.DrawVLineAt(5,5,25,'~',ConsoleColor.Yellow);
            Console.ReadKey();
            Drawing.ClearFromTo(1,0,20,20);
            Console.ReadKey();
            Drawing.ClearY(25);
            Drawing.ClearX(5);

            Drawing.Credits();
            Console.ReadKey();

            Drawing.DrawRectangleAt(new Point2D(3,4),5,'*');
            Console.ReadKey();

            Drawing.DrawVLineAt(1,1,5,'a');
            
        }
    }
}
