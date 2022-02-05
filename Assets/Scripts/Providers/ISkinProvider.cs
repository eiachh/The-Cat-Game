using Assets.Scripts.Providers;
using Assets.Scripts.Visuals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Providers
{
    public interface ISkinProvider
    {
        ISkin GetSkin(string registeredName);
    }
}
