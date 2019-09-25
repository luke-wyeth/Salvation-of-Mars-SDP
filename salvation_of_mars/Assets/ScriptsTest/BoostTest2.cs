using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BoostTest2
    {
        // A Test behaves as an ordinary method
        //speedBoost and selectedboost are initially false.
        public bool speedBoost = false;  
        public bool selectedBoost = false;

        //If user selects boost as their ability then then the ability should be usable
        public void BoostAbilitySelected()
        {
            selectedBoost = true;

            if (selectedBoost == true)
            {
                speedBoost = true;
            }
        }
        //If user does not select boost as their ability then the ability should not be usable
        public void BoostAbilityNotSelected()
        {
            selectedBoost = false;

            if (selectedBoost == false)
            {
                speedBoost = false;
            }
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        //Test for selecting boost and checking if both speedBoost and selectedBoost are true
        [UnityTest]
        public IEnumerator BoostSelected()
        {
            BoostAbilitySelected();
            Assert.IsTrue(speedBoost);
            Assert.IsTrue(selectedBoost);
            Assert.AreEqual(speedBoost, selectedBoost);
            yield return null;
        }

        [UnityTest]
        //Test for not selecting boost and checking if both speedBoost and selectedBoost are false
        public IEnumerator BoostNotSelected()
        {
            BoostAbilityNotSelected();
            Assert.IsFalse(speedBoost);
            Assert.IsFalse(selectedBoost);
            Assert.AreEqual(speedBoost, selectedBoost);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
