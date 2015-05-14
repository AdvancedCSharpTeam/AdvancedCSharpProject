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
            Console.WindowWidth = 80;
            Console.BufferWidth = 80;
            Console.WindowHeight = 30;
            Console.BufferHeight = 30;

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

            Drawing.GameOver();
            Console.ReadKey();
            Console.Clear();

            Drawing.Credits();
            Console.ReadKey();
            Console.Clear();

            Drawing.DrawRectangleAt(new Point2D(3,4),5,'*');
            Console.ReadKey();
        }
    }
}
