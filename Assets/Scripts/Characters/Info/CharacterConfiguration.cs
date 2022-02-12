using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Characters.Info
{
    public class CharacterConfiguration
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Speed { get; set; }
        public CharacterSkills Skills { get; set; } = new CharacterSkills();

        public static CharacterConfiguration CreateRandomConfiguration()
        {
            CharacterConfiguration randomConfig = new CharacterConfiguration();
            randomConfig.Name = RandomNameGenerator.Generate();

            randomConfig.Skills.Harvest = GetRandomSkillLevel();
            randomConfig.Skills.Planting = GetRandomSkillLevel();
            randomConfig.Skills.Building = GetRandomSkillLevel();

            return randomConfig;
        }

        private static int GetRandomSkillLevel()
        {
            return UnityEngine.Random.Range(0, 10);
        }
    }
}
