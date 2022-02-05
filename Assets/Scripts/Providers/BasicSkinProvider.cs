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
    public class BasicSkinProvider : ISkinProvider
    {
        public string CharacterSkinsFolderPath = "Assets/Sprites/Characters/CharacterSkins";
        public string CharactersFolderPath = "Assets/Sprites/Characters";

        private string notFoundSpriteName = "NotFound";
        private Sprite notFoundSprite;

        private string defaultSkinTextPrefix = "DefaultSprite";
        private Dictionary<string, AnimatorController> skinDictionary = new Dictionary<string, AnimatorController>();
        public ISkin GetSkin(string registeredName)
        {
            LoadSkins();

            throw new NotImplementedException();
        }

        private void LoadSkins()
        {
            var notFoundSprite = Resources.Load(CharactersFolderPath +"/"+notFoundSpriteName) as Sprite;

            DirectoryInfo dirInfo = new DirectoryInfo(CharacterSkinsFolderPath);
            foreach (var dir in dirInfo.GetDirectories())
            {
                GetDefaultSkin(dir, dir.Name);
                Factory.Instance.CreateSkin(null, null);

            }
        }

        private Sprite GetDefaultSkin(DirectoryInfo dirInfo, string currName)
        {
            foreach (var fileInfo in dirInfo.GetFiles())
            {
                if (fileInfo.Name.StartsWith(defaultSkinTextPrefix))
                {
                    return Resources.Load(CharactersFolderPath + "/" + currName + "/" + fileInfo.Name) as Sprite;
                }
            }
            return notFoundSprite;
        }
    }
}
