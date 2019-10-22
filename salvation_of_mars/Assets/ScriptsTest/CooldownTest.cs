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
            // this checks that after waiting for the cooldown, the player can use gravity ability
            beforeReverse = Player.GetComponent<Transform>().localScale.y;
            Player.GetComponent<PlayerMovement>().ReverseGrav();
            yield return new WaitForSeconds(2);
            Player.GetComponent<PlayerMovement>().ReverseGrav();
            afterReverse = Player.GetComponent<Transform>().localScale.y;                          
            Assert.IsTrue(beforeReverse == -(afterReverse));               
            yield return null;
        }

        [UnityTest]
        public IEnumerator GravityCooldownTestFail()
        {
            // this checks that the player cannot use gravity before waiting for cooldown to occur
            beforeReverse = Player.GetComponent<Transform>().localScale.y;
            Player.GetComponent<PlayerMovement>().ReverseGrav();
            yield return new WaitForSeconds(0);
            Player.GetComponent<PlayerMovement>().ReverseGrav();
            afterReverse = Player.GetComponent<Transform>().localScale.y;                          
            Assert.IsTrue(beforeReverse == afterReverse);               
            yield return null;
        }

        [UnityTest]
        public IEnumerator BoostCooldownTest()
        {
            // checks that player can use boost after waiting for cooldown
            scaleBefore = Player.GetComponent<Rigidbody2D>().velocity.y;
            Player.GetComponent<PlayerMovement>().SpeedBoost();
            yield return new WaitForSeconds(2);
            Player.GetComponent<PlayerMovement>().SpeedBoost();
            scaleAfter = Player.GetComponent<Rigidbody2D>().velocity.y;
            Assert.IsTrue(scaleBefore != scaleAfter);                
            yield return null;
        }

        [UnityTest]
        public IEnumerator BoostCooldownTestFail()
        {
            // checks that the player cannot use boost before cooldown time is up
            scaleBefore = Player.GetComponent<Rigidbody2D>().velocity.y;
            Player.GetComponent<PlayerMovement>().SpeedBoost();
            yield return null;
            Player.GetComponent<PlayerMovement>().SpeedBoost();
            scaleAfter = Player.GetComponent<Rigidbody2D>().velocity.y;
            Assert.IsTrue(scaleBefore == scaleAfter);                
            yield return null;
        }
    }
}
