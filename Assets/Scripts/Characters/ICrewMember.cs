using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Visuals;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    public interface ICrewMember
    {
        IMovementAnimatorAdapter MovementAdapter { get; }
        ISkin Skin { get; set; }

         CharacterConfiguration CharacterConfiguration { get; }

        void MoveLeft();
        void MoveRight();
        void MoveUp();
        void MoveDown();
    }
}
