using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class RocketCinematicTest
    {
        private GameObject rocket;
        private GameObject flame;
        private GameObject Player;
        private GameObject Clone;
        private GameObject target;

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
            Player.AddComponent<Animator>();
            Player.GetComponent<PlayerMovement>().animator = Player.GetComponent<Animator>();

            // setup clone object
            Clone = new GameObject();
            Clone.AddComponent<PlayerMovement>();
            Clone.AddComponent<Rigidbody2D>();
            Clone.AddComponent<CharacterController2D>();
            GameObject ceilingCheckC = new GameObject();
            GameObject floorCheckC = new GameObject();
            ceilingCheckC.transform.parent = Clone.transform;
            floorCheckC.transform.parent = Clone.transform;
            Clone.GetComponent<CharacterController2D>().GroundCheck = floorCheckC.transform;
            Clone.GetComponent<CharacterController2D>().CeilingCheck = ceilingCheckC.transform;
            Clone.GetComponent<PlayerMovement>().controller = Clone.GetComponent<CharacterController2D>();
            Clone.AddComponent<Animator>();
            Clone.GetComponent<PlayerMovement>().animator = Clone.GetComponent<Animator>();

            // setup rocket object
            rocket = new GameObject();
            flame = new GameObject();
            flame.transform.parent = rocket.transform;
            rocket.AddComponent<RocketScript>();
            rocket.GetComponent<RocketScript>().player = Player;
            rocket.GetComponent<RocketScript>().clone = Clone;
            rocket.GetComponent<RocketScript>().flame = flame;

            target = new GameObject();
            target.transform.position = new Vector2(target.transform.position.x, target.transform.position.y + 10);
            rocket.GetComponent<RocketScript>().targetPos = target;
        }

        [TearDown]
        public void TearDown()
        {
            UnityEngine.Object.Destroy(rocket);
            UnityEngine.Object.Destroy(flame);
            UnityEngine.Object.Destroy(Player);
            UnityEngine.Object.Destroy(Clone);
        }

        // this test is checking that when the player enters the rocket
        // the player and clone objects are disabled
        [UnityTest]
        public IEnumerator PlayerAndCloneDisabledOnEnter()
        {
            rocket.GetComponent<RocketScript>().setFlying(); // simulate player colliding with rocket

            Assert.IsFalse(Player.activeSelf); // player is disabled
            Assert.IsFalse(Clone.activeSelf); // clone is disabled

            yield return null;
        }

        // this test verifies that once the rocket has been triggered, it flies upwards
        [UnityTest]
        public IEnumerator RocketFliesUp()
        {
            rocket.GetComponent<RocketScript>().setFlying(); // simulate player colliding with rocket

            Vector3 start = rocket.transform.position; // get starting position of rocket
            yield return new WaitForSeconds(2); // wait for 2 seconds
            Vector3 newPos = rocket.transform.position; // get new position of rocket

            Assert.Greater(newPos.y, start.y); // rocket has flown upwards
            Assert.AreEqual(newPos.x, start.x); // rocket has not moved left or right

            yield return null;
        }


        // this test checks that after the rocket flies upwards, it loads the credits scene
        [UnityTest]
        public IEnumerator LoadCreditSceneAfterFlying()
        {
            rocket.GetComponent<RocketScript>().setFlying(); // simulate player colliding with rocket

            yield return new WaitForSeconds(5); // wait 5 seconds for the rocket to fly up

            Scene scene = SceneManager.GetActiveScene(); // get name of current loaded scene

            Assert.AreEqual(scene.name, "credits"); // current scene is credits scene

            yield return null;
        }

        // verifies that the rocket's flame is disabled when the rocket isn't flying
        [UnityTest]
        public IEnumerator FlameDisabledBeforeFlying()
        {
            Assert.IsFalse(flame.activeSelf);

            yield return null;
        }


        // verifies that the rocket's flame is enabled when the rocket starts flying
        [UnityTest]
        public IEnumerator FlameEnabledWhileFlying()
        {
            rocket.GetComponent<RocketScript>().setFlying(); // simulate player colliding with rocket
            yield return new WaitForSeconds(0.5f); // wait half a second to load updates
            Assert.IsTrue(flame.activeSelf); // flame is active/visible

            yield return null;
        }

    }

}