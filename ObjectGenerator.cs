using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamWork.Field;

namespace TeamWork
{
    public class ObjectGenerator : IObjectGenerator
    {
        private string generatedObject;

        public ObjectGenerator()
        {

            string generatedObject = string.Empty;
            Random rnd = new Random();
            int[] randomBits = new int[5];
            for (int j = 0; j < 5; j++) randomBits[j] = rnd.Next(0, 2);
            for (int j = 0; j < 5; j++) generatedObject += randomBits[j].ToString();
            CreateObject();
        }
        public string GeneratedObject { get; set; }
        public void CreateObject()
        {
            Random rnd = new Random();
            int x = rnd.Next(0, 25);
            int y = 0;
            Point2D point = new Point2D(x, y);
            IGameObject gameObject = new GameObject(point);
            gameObject.SetGeneratedObject(generatedObject);
            PrintObject(gameObject);
        }
        public void PrintObject(IGameObject gameObject)
        {
            gameObject.GameObjectFall();
        }
    }
}
