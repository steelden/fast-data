using Fast.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fast.Buffers.Tests
{
    [TestClass]
    public class FastCompareTest
    {
        [TestMethod]
        public void test_fast_compare()
        {
            const int count = 23;
            var expected = Utility.GetTestArray(count);
            var actualOk = Utility.GetTestArray(count);
            var actualNotOk = new byte[count];

            Assert.AreNotEqual(FastCompare.CompareBytes(expected, actualNotOk), 0);

            Assert.AreEqual(FastCompare.CompareBytes(expected, actualOk), 0);

            actualOk[count - 1] = 0;
            Assert.AreNotEqual(FastCompare.CompareBytes(expected, actualOk), 0);
        }

        [TestMethod]
        public void test_fast_compare_ordering_same_length()
        {
            var b1 = Utility.GetString("test1");
            var b2 = Utility.GetString("test2");

            Assert.AreEqual(FastCompare.CompareBytes(b1, b1), 0);

            Assert.AreEqual(FastCompare.CompareBytes(b1, b2), -1);

            Assert.AreEqual(FastCompare.CompareBytes(b2, b1), 1);
        }

        [TestMethod]
        public void test_fast_compare_ordering_different_length()
        {
            var b1 = Utility.GetString("test1test");
            var b2 = Utility.GetString("test2");

            Assert.AreEqual(FastCompare.CompareBytes(b1, b1), 0);

            Assert.AreEqual(FastCompare.CompareBytes(b1, b2), -1);

            Assert.AreEqual(FastCompare.CompareBytes(b2, b1), 1);
        }
    }
}
