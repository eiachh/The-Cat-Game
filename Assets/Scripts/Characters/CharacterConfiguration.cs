using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Characters
{
    public class CharacterConfiguration
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Speed { get; set; }
        public CharacterSkills Skills { get; set; }
    }
}
