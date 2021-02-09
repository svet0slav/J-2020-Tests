using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HaloBasicTests
{
    [TestClass]
    public class TestAwayOut
    {
        [TestMethod]
        public void TestAwayOut_TestSample1_Positive()
        {
            string data = "[()]{}{()()}";
            var actual = TaskAwayOut.isValid(data);

            Assert.AreEqual(true, actual, $"Invalid for \"{data}\"");
        }

        [TestMethod]
        public void TestAwayOut_TestSample2_Negative()
        {
            string data = "[(])";
            var actual = TaskAwayOut.isValid(data);

            Assert.AreEqual(true, actual, $"Invalid for \"{data}\"");
        }

        [TestMethod]
        public void TestAwayOut_TestSample3_Negative()
        {
            string data = "[({}][()])";
            var actual = TaskAwayOut.isValid(data);

            Assert.AreEqual(true, actual, $"Invalid for \"{data}\"");
        }
    }
}
