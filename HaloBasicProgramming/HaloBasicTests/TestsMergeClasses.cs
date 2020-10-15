using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HaloBasicTests
{
    [TestClass]
    public class TestsMergeClasses
    {
        [TestMethod]
        public void TestMergeClasses_Case0()
        {
            var result = HaloBasicProgramming.TaskMergeClasses.merge(
                new int[] { 1, 2, 3 },
                new int[] { 4, 5 });

            Assert.IsTrue(CompareArrays(result, new int[] { 1, 2, 3, 4, 5 }), "");
        }

        [TestMethod]
        public void TestMergeClasses_Case1()
        {
            var result = HaloBasicProgramming.TaskMergeClasses.merge(
                new int[] { 1, 2, 4 },
                new int[] { 3, 5, 6 });

            Assert.IsTrue(CompareArrays(result, new int[] { 1, 2, 3, 4, 5, 6 }), "");
        }

        [TestMethod]
        public void TestMergeClasses_Case2()
        {
            var result = HaloBasicProgramming.TaskMergeClasses.merge(
                new int[] { 1, 3 },
                new int[] { 1, 2, 3, 4 });

            Assert.IsTrue(CompareArrays(result, new int[] { 1, 1, 2, 3, 3, 4 }), "");
        }

        private bool CompareArrays(int[] actual, int[] expected)
        {
            if (actual.Length != expected.Length)
                return false;

            for(int i=0; i < actual.Length; i++)
            {
                if (actual[i] != expected[i])
                    return false;
            }

            return true;
        }
    }
}