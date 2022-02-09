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
        private IMovementHandler movementHandler;
        private CharacterConfiguration characterConfiguration;


        public ISkin Skin { get; set; }
        public CharacterConfiguration CharacterConfiguration => characterConfiguration;

        public CrewMember(IMovementHandler movementHandler, ISkin skin, CharacterConfiguration configuration)
        {
            this.movementHandler = movementHandler;
            this.characterConfiguration = configuration;
            this.Skin = skin;
        }

        public void MoveHorizontal(int toMapX)
        {
            movementHandler.MoveHorizontal(toMapX);
        }

        public void MoveVertical(int toMapY)
        {
            movementHandler.MoveVertical(toMapY);
        }
    }
}
