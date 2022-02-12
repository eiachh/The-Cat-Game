using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Characters.Info
{
    public static class RandomNameGenerator
    {
        private static List<string> Names = new List<string>() { "Bob", "That Cat", "Robert", "anGerry", "IDK"};
        public static string Generate()
        {
            var index = UnityEngine.Random.Range(0, Names.Count);
            return Names.ElementAt(index);
        }
    }
}
