using Assets.Scripts.Providers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class BasicSkinProviderTest
{
    private string SkinsFolderPath = "Assets/Resources/Sprites/Characters/CharacterSkins";

    private string FakeSkinName = "MockedTestSkin";
    [SetUp]
    public void CreateFakeSkin()
    {
        CreateFakeSkinFolder();
    }

    [TearDown]
    public void DeleteFakeSkin()
    {
        RemoveFakeSkinFolder();
    }


    [Test]
    public void SkinsRegistered()
    {
        Assert.True(Factory.Instance.SkinProvider.GetSkinNames().Contains(FakeSkinName));
    }

    [Test]
    public void CanGetSkin()
    {
        Assert.IsNotNull(Factory.Instance.SkinProvider.GetSkin(FakeSkinName));
    }

    [Test]
    public void ReturnsNullOnNonExistentSkin()
    {
        Assert.IsNull(Factory.Instance.SkinProvider.GetSkin("NOnExistentSkin"));
    }

    private void CreateFakeSkinFolder()
    {
        if(!Directory.Exists($"{ SkinsFolderPath}/{ FakeSkinName}"))
            Directory.CreateDirectory($"{SkinsFolderPath}/{FakeSkinName}");
    }
    private void RemoveFakeSkinFolder()
    {
        if (Directory.Exists($"{ SkinsFolderPath}/{ FakeSkinName}"))
            Directory.Delete($"{SkinsFolderPath}/{FakeSkinName}",true);
    }
}

