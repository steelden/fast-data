using System;

namespace Fast.Data
{
    public static class FastCopy
    {
        public unsafe static void CopyBytes(byte[] destination, byte[] source, int destinationIndex = 0, int length = -1)
        {
            var maxLength = Math.Min(source.Length, destination.Length - destinationIndex);
            if (length > maxLength) throw new ArgumentException("length is greater than maximum possible length", "length");
            if (length == -1) length = maxLength;
            if (length < 0) throw new ArgumentException("length is negative", "length");

            fixed (byte* sp = source)
            fixed (byte* dp = destination)
            {
                CopyBytes(dp + destinationIndex, sp, length);
            }
        }

        internal unsafe static void CopyBytes(byte* destination, byte* source, int length)
        {
            var sptr = source;
            var dptr = destination;

            int x8count = length >> 3; // length / 8
            int x1count = length & 7; // length % 8

            for (int i = 0; i < x8count; ++i)
            {
                *(ulong*)dptr = *(ulong*)sptr;
                sptr += 8;
                dptr += 8;
            }

            for (int i = 0; i < x1count; ++i)
            {
                *dptr++ = *sptr++;
            }
        }
    }
}
