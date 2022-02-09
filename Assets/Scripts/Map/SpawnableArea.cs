using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Map
{
    public class SpawnableArea : ISpawnableArea
    {
        public IMapPosition TopLeft { get; set; }
        public IMapPosition BotRight { get; set; }

        private List<IMapPosition> spawnablePosition = new List<IMapPosition>();
        public SpawnableArea(IMapPosition topLeft, IMapPosition botRight)
        {
            TopLeft = topLeft;
            BotRight = botRight;

            spawnablePosition.AddRange(MapHelper.GetAllPositionsInCube(topLeft, botRight));
        }
        public IMapPosition GetRandomSpawnableLocation()
        {
            foreach (var pos in spawnablePosition.ToList())
            {
                if (!IsActuallySpawnable(pos))
                    spawnablePosition.Remove(pos);
            }

            var randIndex = UnityEngine.Random.Range(0, spawnablePosition.Count);
            return spawnablePosition[randIndex];
        }

        public void SetBotRight(IMapPosition botRightPosition)
        {
            BotRight = botRightPosition;
        }

        public void SetTopLeft(IMapPosition topleftPosition)
        {
            TopLeft = topleftPosition;
        }

        private bool IsActuallySpawnable(IMapPosition target)
        {
            ///MOCK///MOCK///MOCK///MOCK
            //////MOCK///MOCK///MOCK///MOCK
            //////MOCK///MOCK///MOCK///MOCK
            return true;
        }
    }
}
