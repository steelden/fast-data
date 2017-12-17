using Fast.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fast.Buffers.Tests
{
    [TestClass]
    public class FastBufferTest
    {
        [TestMethod]
        public void test_fast_buffer()
        {
            var expected = Utility.GetTestArray(16);
            var buffer = new FastBuffer(expected);

            Assert.AreEqual(expected.Length, buffer.GetCapacity());

            Assert.AreSame(expected, buffer.Get());

            Assert.IsTrue(buffer.Do(a => Utility.CheckTestArray(a, expected)));

            Assert.AreEqual(expected.Length, buffer.GetPosition());
        }

        [TestMethod]
        public void test_buffer_resize()
        {
            const int size1 = 15;
            const int size2 = 25;
            var buffer = new FastBuffer(size1);

            Assert.AreEqual(size1, buffer.GetCapacity());

            buffer.Reset(size2);

            Assert.AreEqual(size2, buffer.GetCapacity());

            buffer.Reset();

            Assert.AreEqual(size2, buffer.GetCapacity());
        }

        [TestMethod]
        public void test_buffer_position()
        {
            const int size = 15;
            const int data = 123;
            var buffer = new FastBuffer(size);

            Assert.AreEqual(0, buffer.GetPosition());

            buffer.Do(a => a.Write(data));

            Assert.AreEqual(sizeof(int), buffer.GetPosition());
        }
    }
}
