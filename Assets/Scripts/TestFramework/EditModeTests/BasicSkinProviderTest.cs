using Assets.Scripts.Providers;
using NUnit.Framework;
using System.IO;

/// <summary>
/// Tests for the <see cref="BasicSkinProvider"/> class.
/// </summary>
public class BasicSkinProviderTest
{
    private string SkinsFolderPath = "Assets/Resources/Sprites/Characters/CharacterSkins";
    private string FakeSkinName = "MockedTestSkin";

    [SetUp]
    public void CreateFakeSkinSetup()
    {
        CreateFakeSkinFolder();
        Factory.Instance.SkinProvider.LoadUnmanagedSkins();
    }

    [TearDown]
    public void DeleteFakeSkin()
    {
        RemoveFakeSkinFolder();
    }


    /// <summary>
    /// Checks if the fake skin created is actually registered in the skin provider.
    /// </summary>
    [Test]
    public void SkinsRegistered()
    {
        Assert.True(Factory.Instance.SkinProvider.GetSkinNames().Contains(FakeSkinName));
    }

    /// <summary>
    /// Checks if the get skin returns the selected existing skin.
    /// </summary>
    [Test]
    public void CanGetSkin()
    {
        Assert.IsNotNull(Factory.Instance.SkinProvider.GetSkin(FakeSkinName));
    }

    /// <summary>
    /// Checks if the skin provider returns null on a non existent skin.
    /// </summary>
    [Test]
    public void ReturnsNullOnNonExistentSkin()
    {
        Assert.IsNull(Factory.Instance.SkinProvider.GetSkin("NOnExistentSkin"));
    }
    
    /// <summary>
    /// Checks if the LoadUnmanagedSkins function actually loads the newly inserted skin.
    /// </summary>
    [Test]
    public void LoadUnmanagedFindsNewSkin([Values("RandomSkinToFind","AnotherSkinToFind", "IDKHonestly")]string skinNames)
    {
        var skinProvider = Factory.Instance.SkinProvider;

        CreateFakeSkinFolder(skinNames);
        skinProvider.LoadUnmanagedSkins();
        Assert.IsNotNull(skinProvider.GetSkin(skinNames));
        RemoveFakeSkinFolder(skinNames);
    }
    /// <summary>
    /// Tests if the LoadUnmanaged function is not loading the already existing skins again.
    /// </summary>
    [Test]
    public void LoadUnmanagedIsNotDuplicating()
    {
        var skinProvider = Factory.Instance.SkinProvider;

        var skinAmount = skinProvider.GetSkinNames().Count;
        skinProvider.LoadUnmanagedSkins();
        var skinAmountAfter = skinProvider.GetSkinNames().Count;

        Assert.AreEqual(skinAmount, skinAmountAfter);
    }
    
    /// <summary>
    /// Creates the fake skin mock folder which registers the skin.
    /// </summary>
    private void CreateFakeSkinFolder()
    {
        if(!Directory.Exists($"{ SkinsFolderPath}/{ FakeSkinName}"))
            Directory.CreateDirectory($"{SkinsFolderPath}/{FakeSkinName}");
    }

    /// <summary>
    /// Removes the fake skin mock folder.
    /// </summary>
    private void RemoveFakeSkinFolder()
    {
        if (Directory.Exists($"{ SkinsFolderPath}/{ FakeSkinName}"))
            Directory.Delete($"{SkinsFolderPath}/{FakeSkinName}",true);
    }

    /// <summary>
    /// Creates the fake skin mock folder which registers the skin.
    /// </summary>
    private void CreateFakeSkinFolder(string name)
    {
        if (!Directory.Exists($"{ SkinsFolderPath}/{ name}"))
            Directory.CreateDirectory($"{SkinsFolderPath}/{name}");
    }

    /// <summary>
    /// Creates the fake skin mock folder which registers the skin.
    /// </summary>
    private void RemoveFakeSkinFolder(string name)
    {
        if (Directory.Exists($"{ SkinsFolderPath}/{ name}"))
            Directory.Delete($"{SkinsFolderPath}/{name}", true);
    }
}

