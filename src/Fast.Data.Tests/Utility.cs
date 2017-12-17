using System.Text;
using Fast.Data;

namespace Fast.Buffers.Tests
{
    public static class Utility
    {
        public static byte[] GetTestArray(int size)
        {
            var result = new byte[size];
            for (int i = 0; i < result.Length; ++i)
                result[i] = (byte)i;
            return result;
        }

        public static bool CheckTestArray(BufferActions actions, byte[] testArray)
        {
            for (int i = 0; i < testArray.Length; ++i)
            {
                var b = actions.ReadByte();
                if ((byte)i != b) return false;
            }
            return true;
        }

        public static bool CheckTestArray(byte[] actual)
        {
            for (int i = 0; i < actual.Length; ++i)
            {
                var b = actual[i];
                if ((byte)i != b) return false;
            }
            return true;
        }

        public static byte[] GetString(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }
    }
}
