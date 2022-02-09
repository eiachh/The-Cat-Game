using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public interface IMapPosition
    {
        float X { get; }
        float Y { get; }

        Vector3 FromMapPositionToActual();
        void SetMapPosition(Vector3 actualPosition);
    }
}
