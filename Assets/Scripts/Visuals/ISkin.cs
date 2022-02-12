using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.Visuals;

namespace Assets.Scripts.Visuals
{
    /// <summary>
    /// Skin interface for skinnable game objects.
    /// </summary>
    public interface ISkin : IDisposable
    {
        /// <summary>
        /// Applies the skin on the given target.
        /// </summary>
        /// <param name="targer">The target object.</param>
        void ApplySkin(GameObject targer);

        /// <summary>
        /// Puts the target to the desired render layer.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <param name="desiredLayer">The desired layer.</param>
        void SetRenderLayer(GameObject target, RenderLayerCollection desiredLayer);

        /// <summary>
        /// Gets the portrait of the character.
        /// </summary>
        /// <returns>The portrait as a sprite.</returns>
        Sprite GetPortrait();
    }
}
