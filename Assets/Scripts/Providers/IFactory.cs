using Assets.Scripts.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Animations;
using UnityEngine;
using Assets.Scripts.Characters;

namespace Assets.Scripts.Providers
{
    public interface IFactory
    {
        /// <summary>
        /// Gets a logger object.
        /// </summary>
        public ILogger Logger { get; }

        /// <summary>
        /// Gets the skin provider.
        /// </summary>
        public ISkinProvider SkinProvider { get; }

        /// <summary>
        /// Create an ISkin.
        /// </summary>
        /// <param name="defaultSprite">The default sprite of the skin.</param>
        /// <param name="animatorController">The animator controller of the skin.</param>
        /// <returns>An ISkin.</returns>
        ISkin CreateSkin(Sprite defaultSprite, AnimatorController animatorController);

        ICrewMember CreateCrewMember(CharacterConfiguration configuration, string skinName);

        /// <summary>
        /// Returns a movement animator adapter for the given adapter type.
        /// </summary>
        /// <param name="animator"></param>
        /// <returns></returns>
        IMovementAnimatorAdapter CreateMovementAnimatorAdapter(Animator animator, AnimatorAdapterType animatorAdapterType);
    }
}
