using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PortalTestScript
    {
        private GameObject Player;
        private GameObject Portal;
        private GameObject Portal2;
        private bool teleported;

        //Player and 2 different portals are set up with different positions
        [SetUp]
        public void Init()
        {
            Player = new GameObject();
            Player.AddComponent<BoxCollider2D>();
            Player.AddComponent<Teleport>();
            Player.transform.position = new Vector3(1, 1, 1);

            Portal = new GameObject();
            Portal.AddComponent<BoxCollider2D>();
            Portal.GetComponent<BoxCollider2D>().isTrigger = true;
            Portal.AddComponent<Teleport>();
            Portal.transform.position = new Vector3(5, 5, 5);

            Portal2 = new GameObject();
            Portal2.AddComponent<BoxCollider2D>();
            Portal2.GetComponent<BoxCollider2D>().isTrigger = true;
            Portal2.AddComponent<Teleport>();
            Portal2.transform.position = new Vector3(10, 10, 10);

            teleported = false;
        }

        [TearDown]
        public void TearDown()
        {
            UnityEngine.Object.Destroy(Player);
            UnityEngine.Object.Destroy(Portal);
        }

        //Test that there are two different objects are connected to one another.
        //Also that an object is not connected to itself
        [UnityTest]
        public IEnumerator TwoDifferentObjectsConnected()
        {
            Portal.GetComponent<Teleport>().connectedObject = Portal2;                      //set connectedobject of portal to be portal2  
            Portal2.GetComponent<Teleport>().connectedObject = Portal;                      //set connectedobject of portal2 to be portal

            Assert.AreEqual(Portal, Portal2.GetComponent<Teleport>().connectedObject);      //Object should be connected to a different object
            Assert.AreEqual(Portal2, Portal.GetComponent<Teleport>().connectedObject);      //and different object should be connected to object

            Assert.AreNotEqual(Portal, Portal.GetComponent<Teleport>().connectedObject);    //check if object is not the same as the connected object

            yield return null;
        }

        //Test for checking that the player's position is the same as the portal2's postion when teleported
        [UnityTest]
        public IEnumerator PlayerTeleportsToPortal2()
        {
            Player.transform.position = Vector3.zero;       //Position player and portal to 0                  
            Portal.transform.position = Vector3.zero;
            teleported = Player.GetComponent<Teleport>().teleported;

          //  Player.GetComponent<Teleport>().teleport(); // not currently working

            Assert.AreEqual(Player.transform.position, Portal2.transform.position);     //Player position and portal2 position should be the same
            Assert.IsTrue(teleported);                                                  //Verify if player teleported
            yield return null;
        }

        //Test for checking that the player's position is the same as the portal's postion when teleported back.
        [UnityTest]
        public IEnumerator PlayerTeleportsToPortal()
        {
            Player.transform.position = Vector3.zero;       //Position of player and portal 2 are the same.
            Portal2.transform.position = Vector3.zero;
            teleported = Player.GetComponent<Teleport>().teleported;

           // Player.GetComponent<Teleport>().teleport(); // not currently working

            Assert.AreEqual(Portal.transform.position, Player.transform.position);      //Player position and portal position should be the same
            Assert.IsTrue(teleported);                                                  //Verify if player teleported  
            yield return null;
        }
    }
}
