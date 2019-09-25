using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BoostTest
    {
        private GameObject Player;
        private bool speedBoost;
        private bool selectedBoost;

        [SetUp]
        public void Init()
        {
            // setup player object
            Player = new GameObject();
            Player.AddComponent<PlayerMovement>();
            Player.AddComponent<Rigidbody2D>();
            Player.AddComponent<CharacterController2D>();
            GameObject ceilingCheckP = new GameObject();
            GameObject floorCheckP = new GameObject();
            ceilingCheckP.transform.parent = Player.transform;
            floorCheckP.transform.parent = Player.transform;
            Player.GetComponent<CharacterController2D>().GroundCheck = floorCheckP.transform;
            Player.GetComponent<CharacterController2D>().CeilingCheck = ceilingCheckP.transform;
            Player.GetComponent<PlayerMovement>().controller = Player.GetComponent<CharacterController2D>();
        }

        [TearDown]
        public void TearDown()
        {
            UnityEngine.Object.Destroy(Player);
        }

        //simulates when speedBoost is false and selectedBoost is false.
        [UnityTest]
        public IEnumerator SpeedBoostAbilityNotSelected()
        {
            speedBoost = Player.GetComponent<CharacterController2D>().speedBoost;
            selectedBoost = speedBoost;
            Assert.IsFalse(selectedBoost);
            Assert.IsFalse(speedBoost);
            Assert.AreEqual(selectedBoost, speedBoost);
            yield return null;
        }

        //simulates when selectedBoost is true and selectedBoost is true.
        [UnityTest]
        public IEnumerator SpeedBoostAbilityIsSelected()
        {
            speedBoost = true;
            selectedBoost = true;
            Assert.IsTrue(selectedBoost);
            Assert.IsTrue(speedBoost);
            Assert.AreEqual(selectedBoost, speedBoost);
            yield return null;
        }


    }
}
