using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assets.Scripts.Characters;
using Assets.Scripts;
using Assets.Scripts.Providers;

public class StaticFactoryTest
{
    static int a = 1;
    static int b = 1;

    [SetUp]
    public void Setup()
    {
        Debug.Log("B increased");
    }

    //[OneTimeSetUp]
    //public void OneSetup()
    //{
    //    a++;
    //    Debug.Log("A increased");
    //}
    [Test]
    public void HasAlwaysInstance()
    {
        Assert.IsNotNull(Factory.Instance);
        Assert.AreEqual(2, a);
    }

    [Test]
    public void InstanceIsDefaultFactory()
    {
        Assert.IsInstanceOf<DefaultFactory>(Factory.Instance);
        Assert.AreEqual(2, a);
    }
}
