using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TriggerTextTest
    {
        private GameObject textObject; // this represents the text object we want to enable and disable
        private GameObject player;

        [SetUp]
        public void Init()
        {
            textObject = new GameObject();
            textObject.AddComponent<SpriteRenderer>(); // add a sprite to the object
            textObject.AddComponent<BoxCollider2D>(); // add a collider to the object
            textObject.GetComponent<BoxCollider2D>().size = new Vector2(5, 5);
            textObject.GetComponent<BoxCollider2D>().isTrigger = true; // allow collider to act as a trigger
            textObject.AddComponent<VisibleText>(); // add the script we're testing to the object

            player = new GameObject(); 
            player.AddComponent<BoxCollider2D>(); // add a collider to the player
            player.GetComponent<BoxCollider2D>().size = new Vector2(5, 5);
            player.transform.position = new Vector3(4, 4);
        }

        [TearDown]
        public void TearDown()
        {
            // destroy objects
            UnityEngine.Object.Destroy(textObject);
            UnityEngine.Object.Destroy(player);
        }

        // this test verifies that when the scene is first loaded, the text is not rendered
        [UnityTest]
        public IEnumerator TextNotVisibleStartingScene()
        {
            SpriteRenderer sr = textObject.GetComponent<SpriteRenderer>();

            // check that sprite renderer is disabled (will not render anything, not visible)
            Assert.IsFalse(sr.enabled); 

            yield return null;
        }

        // this tests that when something collides with the text, it is rendered (visible)
        [UnityTest]
        public IEnumerator TextVisibleAfterCollision()
        {
            SpriteRenderer sr = textObject.GetComponent<SpriteRenderer>();

            // move both objects together to force the colliders to collide
            player.transform.position = Vector3.zero; // move player to position 0
            textObject.transform.position = Vector3.zero; // move object to position 0
            textObject.GetComponent<VisibleText>().loadText();

            yield return new WaitForSeconds(0.1f);

            Assert.IsTrue(sr.enabled);

            yield return null;
        }

        // this tests that when something stops colliding with the text, it remains rendered
        [UnityTest]
        public IEnumerator TextStaysVisible()
        {
            SpriteRenderer sr = textObject.GetComponent<SpriteRenderer>();

            // move both objects together to force the colliders to collide
            player.transform.position = Vector3.zero;
            textObject.transform.position = Vector3.zero;
            textObject.GetComponent<VisibleText>().loadText();

            yield return new WaitForSeconds(0.1f);

            Assert.IsTrue(sr.enabled); // text is visible

            // move player away from the text, no longer colliding with the object
            player.transform.position = new Vector3(50, 100, 0);

            yield return new WaitForSeconds(0.1f);

            Assert.IsTrue(sr.enabled); // text is still visible

            yield return null;
        }
    }
}
