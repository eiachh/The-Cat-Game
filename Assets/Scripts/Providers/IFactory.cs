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
    }
}
