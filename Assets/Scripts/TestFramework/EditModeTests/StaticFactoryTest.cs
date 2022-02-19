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
    [Test]
    public void HasAlwaysInstance()
    {
        Assert.IsNotNull(Factory.Instance);
    }

    [Test]
    public void InstanceIsDefaultFactory()
    {
        Assert.IsInstanceOf<DefaultFactory>(Factory.Instance);
    }
}
