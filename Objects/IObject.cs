﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWork
{
    public interface IGameObject : IEntity
    {
        Point2D Point { get; set; }

        int Speed { get; set; }

        void GameObjectFall();

        void SetGeneratedObject(string generatedObject);
    }
}
