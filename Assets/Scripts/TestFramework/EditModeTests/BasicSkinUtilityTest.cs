using Assets.Scripts.Visuals;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Providers;

namespace Assets.Scripts.TestFramework.EditModeTests
{
    public class BasicSkinUtilityTest
    {
        private string skinNameToTest = "SpottySus";
        private ISkin skinToTest;


        [SetUp]
        public void LoadSkinToTest()
        {
            skinToTest = Factory.Instance.SkinProvider.GetSkin(skinNameToTest);
        }

        [Test]
        public void HasPortrait()
        {
            var portrait = skinToTest.GetPortrait();
            Assert.IsTrue(portrait.name.StartsWith("Portrait"));
        }
    }
}
