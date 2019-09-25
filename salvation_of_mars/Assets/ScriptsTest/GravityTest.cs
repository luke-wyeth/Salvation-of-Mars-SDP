using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GravityTest
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
        public IEnumerator GravityReversedPhysicsTest()
        {
            beforeReverse = Physics2D.gravity.y;                           //Get y axis of gravity vector (vertical) before rotation.
            Player.GetComponent<PlayerMovement>().ReverseGrav();           //Calls function to reverse gravity.
            afterReverse = Physics2D.gravity.y;                            //Get y axis of gravity vector (vertical) after rotation.
            Assert.IsTrue(beforeReverse == -(afterReverse));               //Tests if gravity is inverted or not. Assert should be true if vertical gravity inverts.
            yield return null;
        }

        [UnityTest]
        public IEnumerator LocalScaleRotateTest()
        {
            scaleBefore = Player.GetComponent<Transform>().localScale.y;   //Gets the local scale before the rotate.
            Player.GetComponent<PlayerMovement>().ReverseGrav();           //Calls function to reverse gravity.
            yield return null;
            scaleAfter = Player.GetComponent<Transform>().localScale.y;    //Gets the local scale before the rotate. 
            Assert.IsTrue(scaleBefore == -(scaleAfter));                   //Tests if player model will rotate when reverse gravity is called.
            yield return null;
        }
    }
}
