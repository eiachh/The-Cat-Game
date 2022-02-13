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

        public SpawnAreaType SpawnAreaType => spawnAreaType;

        private List<IMapPosition> spawnablePosition = new List<IMapPosition>();
        private SpawnAreaType spawnAreaType;

        public SpawnableArea(IMapPosition topLeft, IMapPosition botRight, SpawnAreaType type)
        {
            TopLeft = topLeft;
            BotRight = botRight;
            spawnAreaType = type;

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
