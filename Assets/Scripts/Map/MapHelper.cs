using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public static class MapHelper
    {
        public static IEnumerable<IMapPosition> GetAllPositionsInCube(IMapPosition topLeft, IMapPosition botRight)
        {
            if(topLeft == null || botRight == null)
            {
                yield break;
            }

            for (int y = (int)topLeft.Y; y >= botRight.Y; y--)
            {
                for (int x = (int)topLeft.X; x <= botRight.X; x++)
                {
                    yield return Factory.Instance.CreateMapPosition(x, y);
                }
            }
        }
    }
}
