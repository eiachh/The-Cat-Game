using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Visuals
{
    /// <summary>
    /// Collection of AnimatorAdapterTypes.
    /// </summary>
    public enum AnimatorAdapterType
    {
        CrewMovementAnimator,
    }
    /// <summary>
    /// An adapter to translate from code commands into <see cref="Animator"/> set strings.
    /// </summary>
    public interface IMovementAnimatorAdapter
    {
        /// <summary>
        /// Play Left movement animation.
        /// </summary>
        void MoveLeft();

        /// <summary>
        /// Play Right movement animation.
        /// </summary>
        void MoveRight();

        /// <summary>
        /// Play Up movement animation.
        /// </summary>
        void MoveUp();

        /// <summary>
        /// Play Down movement animation.
        /// </summary>
        void MoveDown();
    }
}
