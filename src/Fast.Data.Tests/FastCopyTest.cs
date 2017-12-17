using Fast.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fast.Buffers.Tests
{
    [TestClass]
    public class FastCopyTest
    {
        [TestMethod]
        public void test_fast_copy()
        {
            const int count = 23;
            var expected = Utility.GetTestArray(count);
            var actual = new byte[count];

            Assert.IsFalse(Utility.CheckTestArray(actual));

            FastCopy.CopyBytes(actual, expected);

            Assert.IsTrue(Utility.CheckTestArray(actual));
        }
    }
}
