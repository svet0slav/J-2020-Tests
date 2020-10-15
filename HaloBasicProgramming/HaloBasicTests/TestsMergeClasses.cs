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



//        Sample Input 0



//Sample Output 0


//Sample Input 1

//1,2,4
//3,5,6
//Sample Output 1

//1,2,3,4,5,6
//Sample Input 2

//1,3
//1,2,3,4
//Sample Output 2

//1,1,2,3,3,4
    }
}
