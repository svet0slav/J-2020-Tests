using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HaloBasicProgramming;
using System.Collections.Generic;

namespace HaloBasicTests
{
    [TestClass]
    public class TestsGoedel
    {
        [TestMethod]
        public void TestGoedel_Case0()
        {
            var r = TaskGoedel.godelEncode(new List<string>() { "0", "=" }, "0=0");

            Assert.AreEqual(r, "90", "Explanation 0 - g(\"0=0\") = 21 x 32 x 51 = 90");
        }

        [TestMethod]
        public void TestGoedel_Case1()
        {
            var r = TaskGoedel.godelEncode(new List<string>() { "2", "=", "1", "+" }, "1+1=2");

            Assert.AreEqual(r, "43659000", "Explanation 1 - g(\"1+1=2\") = 23 x 34 x 53 x 72 x 111 = 43659000");
        }
    }
}
