using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TeamWork.Field;


namespace TeamWork
{
    class Program
    {
        //private static Thread _musicThread;
        static void Main(string[] args)
        {
            Engine.InitConsole();
            // _musicThread = new Thread(Engine.LoadMusic);
            // _musicThread.Start();
            Engine eng = new Engine();
            eng.Start();
        }
    }
}
