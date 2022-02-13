using Assets.Scripts.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Map
{
    public interface IMapManager
    {
        string MainMapName { get; }
        ISpawnableArea DefaultSpawnArea { get; }
        ISpawnableArea CreateSpawnArea(IMapPosition topLeft, IMapPosition bottomRight, SpawnAreaType type);
        void RegisterCrewSpawnrequest(ICrew crew);
        void RegisterSpawnArea(ISpawnableArea areaToRegister);
    }
}
