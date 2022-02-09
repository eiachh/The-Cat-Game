using Assets.Scripts.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Animations;
using UnityEngine;
using Assets.Scripts.Characters;
using Assets.Scripts.Map;
using UnityEngine.UIElements;

namespace Assets.Scripts.Providers
{
    public interface IFactory
    {
        /// <summary>
        /// Gets a logger object.
        /// </summary>
        ILogger Logger { get; }

        /// <summary>
        /// Gets the skin provider.
        /// </summary>
        ISkinProvider SkinProvider { get; }

        /// <summary>
        /// Create an ISkin.
        /// </summary>
        /// <param name="defaultSprite">The default sprite of the skin.</param>
        /// <param name="animatorController">The animator controller of the skin.</param>
        /// <returns>An ISkin.</returns>
        ISkin CreateSkin(Sprite defaultSprite, AnimatorController animatorController);

        ICrewMember CreateCrewMember(CharacterConfiguration configuration, string skinName);

        /// <summary>
        /// Creates a random crew member.
        /// </summary>
        /// <returns></returns>
        ICrewMember CreateRandomCrewMember();
        /// <summary>
        /// Returns a movement animator adapter for the given adapter type.
        /// </summary>
        /// <param name="animator"></param>
        /// <returns></returns>
        IMovementAnimatorAdapter CreateMovementAnimatorAdapter(Animator animator, AnimatorAdapterType animatorAdapterType);

        /// <summary>
        /// Creates a movement handler for an object that has a <see cref="Rigidbody2D"/> and a <see cref="IMovementAnimatorAdapter"/>
        /// </summary>
        /// <param name="gameObject">The game object to move.</param>
        /// <param name="movementAnimatorAdapter">The animator adapter for movement animation.</param>
        /// <returns>The movement handler.</returns>
        IMovementHandler CreateMovementHandler(GameObject gameObject, IMovementAnimatorAdapter movementAnimatorAdapter);

        /// <summary>
        /// Creates an <see cref="IMapPosition"/> with the proper representation.
        /// </summary>
        /// <param name="x">The x coord of the map position.</param>
        /// <param name="y">The y coord of the map position.</param>
        /// <returns>A map position.</returns>
        IMapPosition CreateMapPosition(float x, float y);

        /// <summary>
        /// Creates an <see cref="IMapPosition"/> with the proper representation.
        /// </summary>
        /// <param name="transform">The corresponding transform.</param>
        /// <returns>A map position.</returns>
        IMapPosition CreateMapPosition(Transform transform);
    }
}
