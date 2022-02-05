using Assets.Scripts.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts.Providers
{
    public class DefaultFactory : IFactory
    {
        public ISkin CreateSkin(Sprite defaultSprite, AnimatorController animatorController)
        {
            return new CharacterSkinUtility(defaultSprite, animatorController);
        }
    }
}
