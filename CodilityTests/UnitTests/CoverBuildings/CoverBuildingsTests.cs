using System;
using CodilityTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CoverBuildingsTests
    {
        [TestMethod]
        public void CoverBuildingsTests_Test1()
        {
            int[] data1 = new int[] { 3, 1, 4 };
            var test = new CoverBuildingsClass();
            var result = test.Solution1(data1);
            Assert.AreEqual(10, result, "Example 1 [3,1,4] failed with solution 1");

            result = test.Solution2(data1);
            Assert.AreEqual(10, result, "Example 1 [3,1,4] failed with solution 2");
        }

        [TestMethod]
        public void CoverBuildingsTests_Test2()
        {
            int[] data1 = new int[] { 5, 3, 2, 4 };
            var test = new CoverBuildingsClass();
            var result = test.Solution1(data1);
            Assert.AreEqual(17, result, "Example 2 [5, 3, 2, 4] failed with solution 1");

            result = test.Solution2(data1);
            Assert.AreEqual(17, result, "Example 2 [5, 3, 2, 4] failed with solution 2");
        }

        [TestMethod]
        public void CoverBuildingsTests_Test3()
        {
            int[] data1 = new int[] { 5, 3, 5, 2, 1 };
            var test = new CoverBuildingsClass();
            var result = test.Solution1(data1);
            Assert.AreEqual(19, result, "Example 3 [5, 3, 5, 2, 1] failed with solution 1");

            result = test.Solution2(data1);
            Assert.AreEqual(19, result, "Example 3 [5, 3, 5, 2, 1] failed with solution 2");
        }

        [TestMethod]
        public void CoverBuildingsTests_Test4()
        {
            int[] data1 = new int[] { 7, 7, 3, 7, 7 };
            var test = new CoverBuildingsClass();
            var result = test.Solution1(data1);
            Assert.AreEqual(35, result, "Example 4 [7, 7, 3, 7, 7] failed with solution 1");

            result = test.Solution2(data1);
            Assert.AreEqual(35, result, "Example 4 [7, 7, 3, 7, 7] failed with solution 2");
        }

        [TestMethod]
        public void CoverBuildingsTests_Test5()
        {
            int[] data1 = new int[] { 1, 1, 7, 6, 6, 6 };
            var test = new CoverBuildingsClass();
            var result = test.Solution1(data1);
            Assert.AreEqual(30, result, "Example 5 [1, 1, 7, 6, 6, 6] failed with solution 1");

            result = test.Solution2(data1);
            Assert.AreEqual(30, result, "Example 5 [1, 1, 7, 6, 6, 6] failed with solution 2");
        }

        [TestMethod]
        public void CoverBuildingsTests_Test10K()
        {
            int[] data1 = new int[10000];
            var rnd = new Random();
            for(int i = 0; i< 10000; i++)
            {
                data1[i] = rnd.Next(10000);
            }

            //var start = DateTime.Now;
            //var test = new CoverBuildingsClass();
            //var result = test.Solution1(data1);
            //var lasts = DateTime.Now.Subtract(start).TotalMilliseconds;
            //Assert.IsTrue( lasts < 1000, "Example 10,000 - more than 1 seconds. Failed with solution 1.");

            var start2 = DateTime.Now;
            var test2 = new CoverBuildingsClass();
            var result2 = test2.Solution2(data1);
            var lasts2 = DateTime.Now.Subtract(start2).TotalMilliseconds;
            Assert.IsTrue(lasts2 < 1000, "Example 10,000 - more than 1 seconds. Failed with solution 2.");
        }

        [TestMethod]
        public void CoverBuildingsTests_Test100K()
        {
            int[] data1 = new int[100000];
            var rnd = new Random();
            for (int i = 0; i < 100000; i++)
            {
                data1[i] = rnd.Next(100000);
            }

            var start = DateTime.Now;
            var test = new CoverBuildingsClass();
            var result = test.Solution2(data1);
            var lasts = DateTime.Now.Subtract(start).TotalMilliseconds;
            Assert.IsTrue(lasts < 6000, "Example 100,000 - more than 6 seconds. Failed with solution 2.");
        }
    }
}
