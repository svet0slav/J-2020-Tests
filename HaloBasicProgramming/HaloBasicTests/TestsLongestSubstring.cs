using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HaloBasicTests
{
    [TestClass]
    public class TestsLongestSubstring
    {
        [TestMethod]
        public void TestLongestSubstring_Case0()
        {
            var r = HaloBasicProgramming.TaskLongestSubstring.lengthOfLongestSubstring("abcabcbb");

            Assert.AreEqual(r, "abc", "Sample Input 0 abcabcbb Sample Output 0 abc");
        }
    }
}
