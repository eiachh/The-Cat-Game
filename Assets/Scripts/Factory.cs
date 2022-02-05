using Assets.Scripts.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class Factory
    {
        public static IFactory Instance { get; private set; }
        static Factory()
        {
            Instance = new DefaultFactory();
        }
    }
}
