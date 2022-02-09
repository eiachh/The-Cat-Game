using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class TransformBasedMapPosition : IMapPosition
    {
        public float X => targetTransform.position.x;

        public float Y => targetTransform.position.y;

        private Transform targetTransform;

        public TransformBasedMapPosition(Transform transform)
        {
            targetTransform = transform;
        }

        public Vector3 FromMapPositionToActual()
        {
            return new Vector3(X, Y, 0);
        }

        public void SetMapPosition(Vector3 actualPosition)
        {
            targetTransform.position = actualPosition;
        }
    }
}
