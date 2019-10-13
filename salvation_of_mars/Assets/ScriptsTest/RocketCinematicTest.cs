using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RocketCinematicTest
    {
        private GameObject rocket;

        [SetUp]
        public void Init()
        {
            rocket = new GameObject();
            rocket.AddComponent<RocketScript>();
        }

        [TearDown]
        public void TearDown()
        {
            UnityEngine.Object.Destroy(rocket);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator RocketCinematicTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
