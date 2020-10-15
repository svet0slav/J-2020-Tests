using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HaloBasicProgramming;
using System.Collections.Generic;

namespace HaloBasicTests
{
    [TestClass]
    public class TestsEncoding
    {
        [TestMethod]
        public void TestEncoding_Case0()
        {
            var r = TaskEncoding.isIsomorphic("abb", "cdd");

            Assert.AreEqual(r, true, "Sample Input 0 - abb cdd Sample Output 0 true");
        }

        [TestMethod]
        public void TestGoedel_Case1()
        {
            var r = TaskEncoding.isIsomorphic("foo", "bar");

            Assert.AreEqual(r, false, "foo bar false");
        }
    }
}
