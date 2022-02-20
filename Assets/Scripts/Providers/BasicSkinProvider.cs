using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor.Animations;
using Assets.Scripts.Visuals;

namespace Assets.Scripts.Providers
{
    /// <summary>
    /// Implements the <see cref="ISkinProvider"/> to provide skins from the set folders.
    /// </summary>
    public class BasicSkinProvider : ISkinProvider
    {
        public static string ResourceFolderPathPrefix = "Assets/Resources/";
        public static string CharacterSkinsFolderPath = "Assets/Resources/Sprites/Characters/CharacterSkins";
        public static string CharactersFolderPath = "Assets/Resources/Sprites/Characters";

        private static string notFoundSpriteName = "NotFound";
        private static string defaultSkinTextPrefix = "DefaultSprite";
        private static string portraitTextPrefix = "Portrait";

        private static Sprite notFoundSprite;

        private bool IsSkinsLoaded;

        private List<string> SkinNames = new List<string>();
        private Dictionary<string, ISkin> skinDictionary = new Dictionary<string, ISkin>();
        

        public IList<string> GetSkinNames()
        {
            LoadSkins();
            return SkinNames.ToList();
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="registeredName"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public ISkin GetSkin(string registeredName)
        {
            LoadSkins();

            ISkin retSkin = null;
            skinDictionary.TryGetValue(registeredName, out retSkin);

            return retSkin;
        }

        public void LoadUnmanagedSkins()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(CharacterSkinsFolderPath);
            foreach (var dir in dirInfo.GetDirectories())
            {
                LoadSkin(dir);
            }
        }

        public void Dispose()
        {
            IsSkinsLoaded = false;

            SkinNames.Clear();
            foreach (var skin in skinDictionary.Values)
            {
                skin.Dispose();
            }
            skinDictionary.Clear();

            UnityEngine.Object.DestroyImmediate(notFoundSprite);
        }

        /// <summary>
        /// Loads all the skins from <see cref="CharacterSkinsFolderPath"/>.
        /// </summary>
        private void LoadSkins()
        {
            if (IsSkinsLoaded)
            {
                return;
            }

            IsSkinsLoaded = true;
            LoadNotFoundSprite();

            DirectoryInfo dirInfo = new DirectoryInfo(CharacterSkinsFolderPath);
            foreach (var dir in dirInfo.GetDirectories())
            {
                LoadSkin(dir);
            }
        }

        /// <summary>
        /// Loads the skin from the current folder.
        /// </summary>
        /// <param name="dir"></param>
        private void LoadSkin(DirectoryInfo dir)
        {
            if (IsManagedSkin(dir.Name))
                return;

            var defaultSkin = GetDefaultSkin(dir);
            var portrait = GetPortrait(dir);
            var animatorController = GetAnimatorController(dir);

            if (animatorController == null)
            {
                Factory.Instance.Logger.Log(LogType.Warning, $"The animator for character: {dir.Name} was null.");
            }

            var skin = Factory.Instance.CreateSkin(defaultSkin, portrait, animatorController);
            skinDictionary.Add(dir.Name, skin);
            SkinNames.Add(dir.Name);
        }

        private bool IsManagedSkin(string name)
        {
            return SkinNames.Any(elem => elem == name);
        }

        /// <summary>
        /// Returs the portrait sprite from the given folder.
        /// </summary>
        /// <param name="dir">Folder with the portrait.</param>
        /// <returns>The portrait as a <see cref="Sprite"/></returns>
        private Sprite GetPortrait(DirectoryInfo dir)
        {
            foreach (var fileInfo in dir.GetFiles())
            {
                if (fileInfo.Name.StartsWith(portraitTextPrefix))
                {
                    var loadPath = GetResourceLoadFormat(CharacterSkinsFolderPath + "/" + dir.Name + "/" + Path.GetFileNameWithoutExtension(fileInfo.Name));
                    var retValue = Resources.Load<Sprite>(loadPath);
                    if (retValue == null)
                        Factory.Instance.Logger.Log(LogType.Warning, $"Failed to load resource: {loadPath}");

                    return retValue;
                }
            }
            return notFoundSprite;
        }

        private static void LoadNotFoundSprite()
        {
            var notFoundSpritePath = GetResourceLoadFormat(CharactersFolderPath + "/" + notFoundSpriteName);
            notFoundSprite = Resources.Load<Sprite>(notFoundSpritePath);
        }

        /// <summary>
        /// Gets the animator controller from the current character's folder.
        /// </summary>
        /// <param name="dir">The folder of the currently processed character.</param>
        /// <returns>The animator controller.</returns>
        private static AnimatorController GetAnimatorController(DirectoryInfo dir)
        {
            foreach (var fileInfo in dir.GetFiles())
            {
                if (fileInfo.Extension == ".controller")
                {
                    var animatorControllerPath = GetResourceLoadFormat(CharacterSkinsFolderPath + "/" + dir.Name + "/" + Path.GetFileNameWithoutExtension(fileInfo.Name));
                    var animatorController = Resources.Load<AnimatorController>(animatorControllerPath);
                    if(animatorController == null)
                    {
                        Factory.Instance.Logger.Log(LogType.Warning, $"Failed to load resource: {animatorControllerPath}");
                    }

                    return animatorController;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the default skin from the current character's folder.
        /// </summary>
        /// <param name="dir">The folder of the currently processed character.</param>
        /// <returns>A sprite as the default skin.</returns>
        private static Sprite GetDefaultSkin(DirectoryInfo dir)
        {
            foreach (var fileInfo in dir.GetFiles())
            {
                if (fileInfo.Name.StartsWith(defaultSkinTextPrefix))
                {
                    var loadPath = GetResourceLoadFormat(CharacterSkinsFolderPath + "/" + dir.Name + "/" + Path.GetFileNameWithoutExtension(fileInfo.Name));
                    var retValue = Resources.Load<Sprite>(loadPath);
                    if (retValue == null)
                        Factory.Instance.Logger.Log(LogType.Warning, $"Failed to load resource: {loadPath}");

                    return retValue;
                }
            }
            return notFoundSprite;
        }

        /// <summary>
        /// Removes the Resource folder prefix from path.
        /// </summary>
        /// <param name="target">The target string.</param>
        /// <returns>A string without Assets/Resources/</returns>
        private static string GetResourceLoadFormat(string target)
        {
            if(target.StartsWith(ResourceFolderPathPrefix))
                return target.Substring(ResourceFolderPathPrefix.Length);

            return target;
        }
    }
}
