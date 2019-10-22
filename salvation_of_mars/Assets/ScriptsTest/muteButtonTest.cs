using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class muteButtonTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void muteButtonfunction_Test()
        {
            var muteButton = new muteSittings();
            AudioListener.pause = true;
            muteButton.muteControl();
            Assert.IsFalse(AudioListener.pause);

       
            muteButton.muteControl();
            Assert.IsTrue(AudioListener.pause);


            // Use the Assert class to test conditions
        }

       

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.

    }
}
