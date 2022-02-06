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
    /// <summary>
    /// Default factory for the game.
    /// </summary>
    public class DefaultFactory : IFactory
    {
        private ISkinProvider skinProvider;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ILogger Logger => Debug.unityLogger;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ISkinProvider SkinProvider => skinProvider;

        public DefaultFactory()
        {
            skinProvider = new BasicSkinProvider();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="defaultSprite"><inheritdoc/></param>
        /// <param name="animatorController"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public ISkin CreateSkin(Sprite defaultSprite, AnimatorController animatorController)
        {
            return new BasicSkinUtility(defaultSprite, animatorController);
        }
    }
}
