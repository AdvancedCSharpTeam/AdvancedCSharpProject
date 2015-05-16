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

            //P.S. Place whatever code you are going to test inside the Start() Method in the Engine Class!
            Engine eng = new Engine();
            eng.Start();
        }
    }
}
