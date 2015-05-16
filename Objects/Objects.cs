using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TeamWork.Field;

namespace TeamWork
{
    public class GameObject : Entity, IGameObject, IEntity
    {
        private string generatedObject;
        public GameObject()
        {

        }
        public GameObject(Point2D point)
            : base(point)
        {

        }
        public string GeneratedObject { get; set; }
        public void GameObjectFall()
        {
            for (int i = 0; i < 25; i++)
            {
                Drawing.ClearX(0);
                Drawing.ClearFromTo(0, 10, 0, 10);
                base.Point.Y++;
                Drawing.DrawHLineAt(base.Point, 1, this.generatedObject);
                Thread.Sleep(1);
            }
        }
        public void SetGeneratedObject(string generatedObject)
        {
            this.GeneratedObject = generatedObject;
        }
    }
}
