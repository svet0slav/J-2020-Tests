using CodilityTests.AP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.AP
{
    [TestClass]
    public class Task2JimmyTreesAestheticTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] A = { 3, 4, 5, 3, 7 };
            var actual = (new Task2JimmyTreesAesthetic()).solution(A);

            Assert.AreEqual(3, actual, "Error case { 3, 4, 5, 3, 7 } - not 3");
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] A = { 1, 2, 3, 4};
            var actual = (new Task2JimmyTreesAesthetic()).solution(A);

            Assert.AreEqual(-1, actual, "Error case { 1, 2, 3, 4 } - not -1");
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] A = { 1, 3, 1, 2 };
            var actual = (new Task2JimmyTreesAesthetic()).solution(A);

            Assert.AreEqual(0, actual, "Error case { 1, 3, 1, 2 } - not 0");
        }
    }
}
