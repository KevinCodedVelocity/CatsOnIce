using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ChickenControllerTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ChickenController_Reset_ExpectChickenAtStartingPosition()
        {
            GameObject chickenObject = new GameObject();
            var chickenController = chickenObject.AddComponent<ChickenContoller>();

            Assert.NotNull(chickenController);

            chickenController.transform.position += new Vector3(1, 1, 1);

            Assert.AreNotEqual(
                chickenController.transform.position, 
                chickenController.StartingPosition,
                "Chicken has not been moved and should not be at starting position");

            // Reset and confirm the chicken goes back to its starting position
            chickenController.Reset();

            Assert.AreEqual(
                chickenController.transform.position,
                chickenController.StartingPosition,
                "Chicken has been reset and should be back at starting position");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ChickenControllerTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
