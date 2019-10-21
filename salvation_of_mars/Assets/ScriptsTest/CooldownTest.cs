using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CooldownTest
    {
        private GameObject Player;
        private float beforeReverse;
        private float afterReverse;
        private float scaleBefore;
        private float scaleAfter;

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
        public void TearDown()      //Remove object after every test. 
        {
            UnityEngine.Object.Destroy(Player);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.

        // test that, when first loaded, player is active and clone is inactive
        [UnityTest]
        public IEnumerator GravityCooldownTest()
        {
            beforeReverse = Physics2D.gravity.y;
            Player.GetComponent<PlayerMovement>().ReverseGrav();
            yield return new WaitForSeconds(1);
            Player.GetComponent<PlayerMovement>().ReverseGrav();
            afterReverse = Physics2D.gravity.y;                            //Get y axis of gravity vector (vertical) after rotation.
            Assert.IsTrue(beforeReverse != afterReverse);               //Tests if gravity is inverted or not. Assert should be true if vertical gravity inverts.
            yield return null;
        }

        [UnityTest]
        public IEnumerator GravityCooldownTestFail()
        {
            beforeReverse = Physics2D.gravity.y;
            Player.GetComponent<PlayerMovement>().ReverseGrav();
            yield return new WaitForSeconds(0);
            Player.GetComponent<PlayerMovement>().ReverseGrav();
            afterReverse = Physics2D.gravity.y;                            //Get y axis of gravity vector (vertical) after rotation.
            Assert.IsTrue(beforeReverse == afterReverse);               //Tests if gravity is inverted or not. Assert should be true if vertical gravity inverts.
            yield return null;
        }

        [UnityTest]
        public IEnumerator BoostCooldownTest()
        {
            scaleBefore = Player.GetComponent<Transform>().localScale.x;
            Player.GetComponent<PlayerMovement>().SpeedBoost();
            yield return new WaitForSeconds(1);
            Player.GetComponent<PlayerMovement>().SpeedBoost();
            scaleAfter = Player.GetComponent<Transform>().localScale.x;
            Assert.IsTrue(scaleBefore != scaleAfter);                //Tests if gravity is inverted or not. Assert should be true if vertical gravity inverts.
            yield return null;
        }

        [UnityTest]
        public IEnumerator BoostCooldownTestFail()
        {
            scaleBefore = Player.GetComponent<Transform>().localScale.x;
            Player.GetComponent<PlayerMovement>().SpeedBoost();
            yield return new WaitForSeconds(0);
            Player.GetComponent<PlayerMovement>().SpeedBoost();
            scaleAfter = Player.GetComponent<Transform>().localScale.x;
            Assert.IsTrue(scaleBefore == scaleAfter);                //Tests if gravity is inverted or not. Assert should be true if vertical gravity inverts.
            yield return null;
        }
    }
}
