using Assets.Scripts.Visuals;
using System.Collections.Generic;

namespace Assets.Scripts.Providers
{
    /// <summary>
    /// Implements all the skin retrival functions.
    /// </summary>
    public interface ISkinProvider
    {
        /// <summary>
        /// Get a skin with the given name.
        /// </summary>
        /// <param name="registeredName">The name that the character is registered with.</param>
        /// <returns>The skin for the character.</returns>
        ISkin GetSkin(string registeredName);

        /// <summary>
        /// Returns an collection with all the existing skin names.
        /// </summary>
        /// <returns>Returns the names.</returns>
        IEnumerable<string> GetSkinNames();
    }
}