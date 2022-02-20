using Assets.Scripts.Providers;
using Assets.Scripts.Visuals;
using NUnit.Framework;
using System.Linq;
using UnityEngine;


public class BasicSkinUtilityTest
{
    private ISkin skinToTest;

    /// <summary>
    /// Loads a skin to test.
    /// </summary>
    [SetUp]
    public void LoadSkinToTest()
    {
        Factory.Instance.SkinProvider?.LoadUnmanagedSkins();
        var randomSkinName = Factory.Instance.SkinProvider.GetSkinNames().FirstOrDefault();
        skinToTest = Factory.Instance.SkinProvider.GetSkin(randomSkinName);
    }

    /// <summary>
    /// Sprite renderer is applied on apply skin.
    /// </summary>
    [Test]
    public void SkinIsApplied()
    {
        GameObject testObject = new GameObject();

        skinToTest.ApplySkin(testObject);
        var spriteRenderer = testObject.GetComponent<SpriteRenderer>();

        Assert.IsNotNull(spriteRenderer);
        Assert.IsNotNull(spriteRenderer.sprite);
    }

    /// <summary>
    /// Animator is applied on applyskin.
    /// </summary>
    [Test]
    public void AnimatorIsApplied()
    {
        GameObject testObject = new GameObject();

        skinToTest.ApplySkin(testObject);
        var animator = testObject.GetComponent<Animator>();

        Assert.IsNotNull(animator);
        Assert.IsNotNull(animator.runtimeAnimatorController);
    }

    /// <summary>
    /// Control group for test to verify in spirte and animator controller is null by default.
    /// </summary>
    [Test]
    public void TestControl()
    {
        GameObject testObject = new GameObject();
        var animator = testObject.AddComponent<Animator>();
        var spriteRenderer = testObject.AddComponent<SpriteRenderer>();

        Assert.IsNotNull(spriteRenderer);
        Assert.IsNull(spriteRenderer.sprite);

        Assert.IsNotNull(animator);
        Assert.IsNull(animator.runtimeAnimatorController);
    }

    /// <summary>
    /// Sets the render layer of a game object to the selecter item from the <see cref="RenderLayerCollection"/>.
    /// </summary>
    /// <param name="selectedRenderLayer">The possible render layer values.</param>
    [Test]
    public void RenderLayerSetOnExistingSpriteRenderer([Values(RenderLayerCollection.Default,
                                       RenderLayerCollection.Effect,
                                       RenderLayerCollection.Ground,
                                       RenderLayerCollection.Important,
                                       RenderLayerCollection.Menu,
                                       RenderLayerCollection.Misc,
                                       RenderLayerCollection.Player)]
                                       RenderLayerCollection selectedRenderLayer)
    {
        GameObject testObject = new GameObject();
        
        skinToTest.ApplySkin(testObject);
        skinToTest.SetRenderLayer(testObject, selectedRenderLayer);

        var spriteRender = testObject.GetComponent<SpriteRenderer>();

        Assert.AreEqual(selectedRenderLayer.ToString(), spriteRender.sortingLayerName);
    }

    /// <summary>
    /// Does not throw exception when attempting to set render layer on an object without sprite renderer.
    /// </summary>
    [Test]
    public void RenderLayerSetOnNullSpriteRenderer()
    {
        GameObject testObject = new GameObject();
        var nullSpriteRenderer = testObject.GetComponent<SpriteRenderer>();

        Assert.IsNull(nullSpriteRenderer);
        Assert.DoesNotThrow(() => skinToTest.SetRenderLayer(testObject, RenderLayerCollection.Default));
    }
}