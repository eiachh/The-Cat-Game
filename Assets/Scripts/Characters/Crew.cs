using Assets.Scripts.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Characters
{
    public class Crew : ICrew
    {
        private List<ICrewMember> crewMembers = new List<ICrewMember>();

        public Crew()
        {
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        public IEnumerable<ICrewMember> Members()
        {
            if (crewMembers == null)
                yield break;

            foreach (var member in crewMembers)
            {
                yield return member;
            }   
        }

        private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode loadedSceneMode)
        {
            var mainMapManager = Factory.Instance.MainMapManager;
            if (scene.name != mainMapManager.MainMapName)
                return;

            mainMapManager.RegisterCrewSpawnrequest(this);
        }

        public void AddMember(ICrewMember member)
        {
            crewMembers.Add(member);
        }

        public void RemoveMember(ICrewMember member)
        {
            crewMembers.Remove(member);
        }
    }
}
