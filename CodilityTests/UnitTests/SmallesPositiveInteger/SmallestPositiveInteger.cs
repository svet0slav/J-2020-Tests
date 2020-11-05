using CodilityTests.SmallestPositiveInteger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class SmallestPositiveInteger
    {
        [TestMethod]
        public void CoverBuildingsTests_Test1()
        {
            int[] data1 = new int[] { 1, 3, 6, 4, 1, 2 };
            var test = new SmallestPositiveIntegerClass();
            var result = test.Solution1(data1);
            Assert.AreEqual(5, result, "Example 1 [1, 3, 6, 4, 1, 2] failed with solution 1");

            //result = test.Solution2(data1);
            //Assert.AreEqual(5, result, "Example 1 [1, 3, 6, 4, 1, 2] failed with solution 2");
        }

        [TestMethod]
        public void CoverBuildingsTests_Test2()
        {
            int[] data1 = new int[] { 1, 2, 3 };
            var test = new SmallestPositiveIntegerClass();
            var result = test.Solution1(data1);
            Assert.AreEqual(4, result, "Example 1 [1, 2, 3] failed with solution 1");

            //result = test.Solution2(data1);
            //Assert.AreEqual(4, result, "Example 1 [1, 2, 3] failed with solution 2");
        }

        [TestMethod]
        public void CoverBuildingsTests_Test3()
        {
            int[] data1 = new int[] { -1, -3 };
            var test = new SmallestPositiveIntegerClass();
            var result = test.Solution1(data1);
            Assert.AreEqual(1, result, "Example 1 [−1, −3] failed with solution 1");

            //result = test.Solution2(data1);
            //Assert.AreEqual(5, result, "Example 1 [-1, -3] failed with solution 2");
        }

        [TestMethod]
        public void CoverBuildingsTests_Test4()
        {
            int[] data1 = new int[100000];
            var rnd = new Random();
            for (int i = 0; i < 100000; i++)
            {
                data1[i] = rnd.Next(100000);
            }

            var start = DateTime.Now;
            var test = new SmallestPositiveIntegerClass();
            var result = test.Solution1(data1);
            var lasts = DateTime.Now.Subtract(start).TotalMilliseconds;
            Assert.IsTrue(lasts < 1000, "Example 100,000 - more than 1 seconds. Failed with solution 1.");
        }

        [TestMethod]
        public void CoverBuildingsTests_Test5()
        {
            int[] data1 = new int[1000000];
            var rnd = new Random();
            for (int i = 0; i < 1000000; i++)
            {
                data1[i] = rnd.Next(100000);
            }

            var start = DateTime.Now;
            var test = new SmallestPositiveIntegerClass();
            var result = test.Solution1(data1);
            var lasts = DateTime.Now.Subtract(start).TotalMilliseconds;
            Assert.IsTrue(lasts < 6000, "Example 1,000,000 - more than 6 seconds. Failed with solution 1.");
        }
    }
}
