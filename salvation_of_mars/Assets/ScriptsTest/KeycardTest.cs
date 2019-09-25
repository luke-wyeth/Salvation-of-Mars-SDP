using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class KeycardTest
    {
        private GameObject Player;
        private GameObject Keycard;
        private bool connected;

        [SetUp]
        public void Init()
        {
            //// setup player object
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
            Player.GetComponent<PlayerInfo>();

            // setup keycard object
            Keycard = new GameObject();
            Keycard.AddComponent<Rigidbody2D>();
            Keycard.GetComponent<SpringJoint2D>();
            Keycard.AddComponent<BoxCollider2D>();
            Keycard.AddComponent<Player>();
            Keycard.AddComponent<PlayerInfo>();
        }

        //clean up after test is done
        [TearDown]
        public void TearDown()
        {
            UnityEngine.Object.Destroy(Player);
            UnityEngine.Object.Destroy(Keycard);
        }

        [UnityTest]
        public IEnumerator PlayerAndKeyCardNotConnected()   
        {
            yield return null;
        }

        [UnityTest]
        public IEnumerator PlayerAndKeyCardConnected()
        {
            yield return null;
        }

    }
}