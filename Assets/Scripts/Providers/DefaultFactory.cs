using Assets.Scripts.Characters;
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

        public ICrewMember CreateCrewMember(CharacterConfiguration configuration, string skinName)
        {
            GameObject crewMemberGameObject = new GameObject(configuration.Name);

            var selectedSkin = skinProvider.GetSkin(skinName);
            selectedSkin.ApplySkin(crewMemberGameObject);
            selectedSkin.SetRenderLayer(crewMemberGameObject, RenderLayerCollection.Player);

            var crewMemberAnimator = crewMemberGameObject.GetComponent<Animator>();
            if(crewMemberAnimator == null)
            {
                crewMemberAnimator = crewMemberGameObject.AddComponent<Animator>();
            }

            var animatorAdapter = CreateMovementAnimatorAdapter(crewMemberAnimator, AnimatorAdapterType.CrewMovementAnimator);

            CrewMember newMember = new CrewMember(animatorAdapter, selectedSkin,configuration);

            return newMember;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="animatorAdapterType"></param>
        /// <returns></returns>
        public IMovementAnimatorAdapter CreateMovementAnimatorAdapter(Animator animator, AnimatorAdapterType animatorAdapterType) =>
            animatorAdapterType switch
            {
                AnimatorAdapterType.CrewMovementAnimator => new CrewMovementAnimatorAdapter(animator),
                _ => null,
            };
    }
}
