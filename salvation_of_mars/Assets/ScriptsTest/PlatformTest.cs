using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

// @author Breahem Bedi(16946858)

namespace Tests
{
    public class PlatformTest
    {
        private GameObject Player;
        private GameObject MovingPlatform;
        private GameObject Platform;


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

            // setup Platform object
            MovingPlatform = new GameObject();
            MovingPlatform.AddComponent<MovingPlatform>();
            GameObject Start = new GameObject();
            GameObject End = new GameObject();
            Platform = new GameObject();
            Platform.AddComponent<Platform>();
            Platform.AddComponent<BoxCollider2D>();
            Platform.AddComponent<Rigidbody2D>();
            MovingPlatform.GetComponent<MovingPlatform>().platform = Platform;
            MovingPlatform.GetComponent<MovingPlatform>().start = Start.transform;
            MovingPlatform.GetComponent<MovingPlatform>().end = End.transform;

            End.transform.position = new Vector3(10, 10, 10); // sets a end point for the platform.
        }
        [TearDown]
        public void TearDown()
        {
            UnityEngine.Object.Destroy(Player);  // Destroys the Player Object.
            UnityEngine.Object.Destroy(MovingPlatform);   // Destroys the MovingPlatform Object.
        }



        [UnityTest]
        public IEnumerator Platform_Moves_When_Enabled()
        {
            Vector3 start = Platform.transform.position; // Declares a start position.
            yield return new WaitForSeconds(2);  // waits for 2 seconds before skipping over a frame.
            Vector3 end = Platform.transform.position; // Declares a end position.

            // checks for wheather the platform has moved towards the end point 
            //by checking if they are not the same.
            Assert.AreNotEqual(start, end);
        }


        [UnityTest]
        public IEnumerator Platform_Doesnot_Moves_When_Disabled()
        {

            MovingPlatform.GetComponent<MovingPlatform>().isActive = false ;  // Disables the movingPlatform game object from moving.           
            Vector3 start = Platform.transform.position; // Declares a start point.
            yield return null;  // skips over a frame.
            Vector3 end = Platform.transform.position;  // Declares a end point
            
            Assert.AreEqual(start, end); // checks for if the platform moved by comparing the start and end point.
        }

    }
}
