using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class TheoreticalMapPosition : IMapPosition
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        public TheoreticalMapPosition(float x, float y)
        {
            X = x;
            Y = y;
        }
        public Vector3 FromMapPositionToActual()
        {
            return new Vector3(X, Y, 0);
        }

        public void SetMapPosition(Vector3 actualPosition)
        {
            X = actualPosition.x;
            Y = actualPosition.y;
        }
    }
}
