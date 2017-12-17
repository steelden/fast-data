using System;

namespace Fast.Data
{
    public static class FastCompare
    {
        //public unsafe static int CompareBytes(byte[] b1, byte[] b2)
        //{
        //    int b1length = b1.Length;
        //    int b2length = b2.Length;
        //    fixed (byte* b1p = b1)
        //    fixed (byte* b2p = b2)
        //    {
        //        var b1ptr = b1p;
        //        var b2ptr = b2p;
        //        while (b1length > 0 && b2length > 0)
        //        {
        //            ulong b1v, b2v;

        //            if (b1length >= 8 && b2length >= 8)
        //            {
        //                b1v = *(ulong*)b1ptr;
        //                b2v = *(ulong*)b2ptr;
        //                b1ptr += 8;
        //                b2ptr += 8;
        //                b1length -= 8;
        //                b2length -= 8;
        //            }
        //            else
        //            {
        //                b1v = *b1ptr++;
        //                b2v = *b2ptr++;
        //                b1length--;
        //                b2length--;
        //            }

        //            if (b1v < b2v) return -1;
        //            if (b1v > b2v) return 1;
        //        }

        //        if (b1length == 0 && b2length == 0) return 0;
        //        if (b1length == 0) return -1;
        //        if (b2length == 0) return 1;
        //    }
        //    return 0;
        //}

        public unsafe static int CompareBytes(byte[] b1, byte[] b2)
        {
            int b1length = b1.Length;
            int b2length = b2.Length;
            fixed (byte* b1p = b1)
            fixed (byte* b2p = b2)
            {
                var b1p8 = (ulong*)b1p;
                var b2p8 = (ulong*)b2p;

                var cmplen = Math.Min(b1length, b2length);
                var length = cmplen >> 3;

                for (int i = 0; i < length; ++i)
                {
                    var b1v = *b1p8++;
                    var b2v = *b2p8++;
                    if (b1v < b2v) return -1;
                    if (b1v > b2v) return 1;
                }

                length = cmplen & 7;
                var b1p1 = (byte*)b1p8;
                var b2p1 = (byte*)b2p8;

                for (int i = 0; i < length; i++)
                {
                    var b1v = *b1p1++;
                    var b2v = *b2p1++;
                    if (b1v < b2v) return -1;
                    if (b1v > b2v) return 1;
                }

                if (b1length == cmplen && b2length == cmplen) return 0;
                if (b1length == cmplen) return -1;
                if (b2length == cmplen) return 1;
            }
            return 0;
        }
    }
}
