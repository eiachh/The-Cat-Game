using Assets.Scripts.Providers;
using Assets.Scripts.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    class CrewMember : ICrewMember
    {
        public ISkin Skin { get; set; }
        public CharacterConfiguration CharacterConfiguration => characterConfiguration;

        private IMovementHandler movementHandler;
        private CharacterConfiguration characterConfiguration;
        private GameObject selfGameObject;

        public CrewMember(GameObject selfGameObject, IMovementHandler movementHandler, ISkin skin, CharacterConfiguration configuration)
        {
            this.movementHandler = movementHandler;
            this.characterConfiguration = configuration;
            this.Skin = skin;
            this.selfGameObject = selfGameObject;
        }

        public void MoveHorizontal(int toMapX)
        {
            movementHandler.MoveHorizontal(toMapX);
        }

        public void MoveVertical(int toMapY)
        {
            movementHandler.MoveVertical(toMapY);
        }

        public void Dispose()
        {
            UnityEngine.Object.DestroyImmediate(selfGameObject);
        }
    }
}
