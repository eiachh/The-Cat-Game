using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Visuals;
using UnityEngine;
using Assets.Scripts.Characters.Info;

namespace Assets.Scripts.Characters
{
    public interface ICrewMember : IDisposable
    {
        ISkin Skin { get; set; }

         CharacterConfiguration CharacterConfiguration { get; }

        void MoveHorizontal(int toMapX);
        void MoveVertical(int toMapY);
    }
}
