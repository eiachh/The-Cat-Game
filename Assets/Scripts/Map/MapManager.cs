using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Map
{

    public class MapManager : MonoBehaviour, IMapManager
    {
        private string mainMapName = "SampleScene";

        private ICrew crewWithSpawnRequest = null;
        private ISpawnableArea defaultSpawnArea = null;
        private List<ISpawnableArea> registeredSpawnableAreas = new List<ISpawnableArea>();

        public string MainMapName => mainMapName;
        public ISpawnableArea DefaultSpawnArea => defaultSpawnArea;

        public ISpawnableArea CreateSpawnArea(IMapPosition topLeft, IMapPosition bottomRight, SpawnAreaType type)
        {
            SpawnableArea createdArea = new SpawnableArea(topLeft, bottomRight, type);
            RegisterSpawnArea(createdArea);
            return createdArea;
        }

        public void RegisterCrewSpawnrequest(ICrew crew)
        {
            if (crew == null)
                return;

            crewWithSpawnRequest = crew;

            if (DefaultSpawnArea != null)
                SpawnCrew();
        }

        public void RegisterSpawnArea(ISpawnableArea areaToRegister)
        {
            if (areaToRegister == null || registeredSpawnableAreas.Contains(areaToRegister))
                return;

            if (areaToRegister.SpawnAreaType == SpawnAreaType.Default)
                HandleDefaultSpawnAreaRegistration(areaToRegister);
        }

        private void HandleDefaultSpawnAreaRegistration(ISpawnableArea spawnArea)
        {
            defaultSpawnArea = spawnArea;

            if (crewWithSpawnRequest != null)
                SpawnCrew();
        }

        private void SpawnCrew()
        {
            foreach (var crewMember in crewWithSpawnRequest.Members())
            {
                var mapPosition = defaultSpawnArea.GetRandomSpawnableLocation();
                crewMember.SelfGameObject.transform.position = mapPosition.FromMapPositionToActual();

                crewMember.SetActive(true);
            }

            UnregisterSpawnedCrew();
        }

        /// <summary>
        /// Unregister the crew that got spawned.
        /// </summary>
        private void UnregisterSpawnedCrew()
        {
            crewWithSpawnRequest = null;
        }
    }

}
