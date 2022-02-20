using Assets.Scripts.Visuals;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Providers;
using UnityEngine;

public class BasicSkinUtilityTest
{
    private string skinNameToLoad = "SpottySus";
    private ISkin skinToTest;

    /// <summary>
    /// Loads a skin to test.
    /// </summary>
    [SetUp]
    public void LoadSkinToTest()
    {
        Factory.Instance.SkinProvider?.LoadUnmanagedSkins();
        skinToTest = Factory.Instance.SkinProvider.GetSkin(skinNameToLoad);
    }

    /// <summary>
    /// Checks if the loaded skin has a portrait.
    /// </summary>
    [Test]
    public void HasPortrait()
    {
        var portrait = skinToTest.GetPortrait();
        Assert.IsTrue(portrait.name.StartsWith("Portrait"));
    }
}
