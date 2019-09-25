using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    
    public class skillSelectTest
    {
        private SkillSelect aa;
        public static bool gravitySelected = false;
        public static bool boostSelected = false;
        public static bool cloneSelected = false;
        public static bool skillSelected = false;

        // A Test behaves as an ordinary method
        [Test]
        public void skillSelectTestSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator skillSelectTestWithBoost()
        {
            aa.Boost();
            Assert.IsFalse(gravitySelected);
            Assert.IsTrue(boostSelected);
            Assert.IsFalse(cloneSelected);
            Assert.IsTrue(skillSelected);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            ;
            yield return null;
        }

        [UnityTest]
        public IEnumerator skillSelectTestWithReverseGravity()
        {
            aa.ReverseGravity ();
            Assert.IsFalse(boostSelected);
            Assert.IsTrue(gravitySelected);
            Assert.IsFalse(cloneSelected);
            Assert.IsTrue(skillSelected);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            ;
            yield return null;
        }

        [UnityTest]
        public IEnumerator skillSelectTestWithClone()
        {
            aa.ReverseGravity();
            Assert.IsFalse(boostSelected);
            Assert.IsTrue(cloneSelected);
            Assert.IsFalse(gravitySelected);
            Assert.IsTrue(skillSelected);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            ;
            yield return null;
        }
    }
}
