using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Map
{
    /// <summary>
    /// Defines a spawnable area as a cube.
    /// </summary>
    public interface ISpawnableArea
    {
        /// <summary>
        /// Set the top left of the spawnable area(cube).
        /// </summary>
        /// <param name="topleftPosition">The top left of the spawnable area.</param>
        void SetTopLeft(IMapPosition topleftPosition);

        /// <summary>
        /// Set the bottom right of the spawnable area(cube).
        /// </summary>
        /// <param name="botRightPosition">The bottom right of the spawnable area.</param>
        void SetBotRight(IMapPosition botRightPosition);

        /// <summary>
        /// Returns a random <see cref="IMapPosition"/> inside the spawnable area that is guaranteed not occupied.
        /// </summary>
        /// <returns>A map position.</returns>
        IMapPosition GetRandomSpawnableLocation();
    }
}
