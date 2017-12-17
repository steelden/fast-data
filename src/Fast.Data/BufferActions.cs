
namespace Fast.Data
{
    public unsafe class BufferActions
    {
        private readonly byte* _buffer;
        private readonly int* _position;

        public int Position { get { return *_position; } }

        public BufferActions(byte* buffer, int* position)
        {
            _buffer = buffer;
            _position = position;
        }

        public void Seek(int position)
        {
            *_position = position;
        }

        public void Write(byte value)
        {
            _buffer[(*_position)++] = value;
        }

        public void Write(sbyte value)
        {
            *((sbyte*)(_buffer + *_position)) = value;
            *_position += sizeof(sbyte);
        }

        public void Write(char value)
        {
            *((char*)(_buffer + *_position)) = value;
            *_position += sizeof(char);
        }

        public void Write(short value)
        {
            *((short*)(_buffer + *_position)) = value;
            *_position += sizeof(short);
        }

        public void Write(ushort value)
        {
            *((ushort*)(_buffer + *_position)) = value;
            *_position += sizeof(ushort);
        }

        public void Write(int value)
        {
            *((int*)(_buffer + *_position)) = value;
            *_position += sizeof(int);
        }

        public void Write(uint value)
        {
            *((uint*)(_buffer + *_position)) = value;
            *_position += sizeof(uint);
        }

        public void Write(long value)
        {
            *((long*)(_buffer + *_position)) = value;
            *_position += sizeof(long);
        }

        public void Write(ulong value)
        {
            *((ulong*)(_buffer + *_position)) = value;
            *_position += sizeof(ulong);
        }

        public void Write(bool value)
        {
            *((bool*)(_buffer + *_position)) = value;
            *_position += sizeof(bool);
        }

        public void Write(float value)
        {
            *((float*)(_buffer + *_position)) = value;
            *_position += sizeof(float);
        }

        public void Write(double value)
        {
            *((double*)(_buffer + *_position)) = value;
            *_position += sizeof(double);
        }

        public void Write(decimal value)
        {
            *((decimal*)(_buffer + *_position)) = value;
            *_position += sizeof(decimal);
        }

        public void Write(byte[] value)
        {
            fixed (byte* pv = value)
            {
                FastCopy.CopyBytes(_buffer + *_position, pv, value.Length);
                *_position += value.Length;
            }
        }

        public byte ReadByte()
        {
            return _buffer[(*_position)++];
        }

        public sbyte ReadSByte()
        {
            var value = *((sbyte*)(_buffer + *_position));
            *_position += sizeof(sbyte);
            return value;
        }

        public short ReadShort()
        {
            var value = *((short*)(_buffer + *_position));
            *_position += sizeof(short);
            return value;
        }

        public ushort ReadUShort()
        {
            var value = *((ushort*)(_buffer + *_position));
            *_position += sizeof(ushort);
            return value;
        }

        public int ReadInt()
        {
            var value = *((int*)(_buffer + *_position));
            *_position += sizeof(int);
            return value;
        }

        public uint ReadUInt()
        {
            var value = *((uint*)(_buffer + *_position));
            *_position += sizeof(uint);
            return value;
        }

        public long ReadLong()
        {
            var value = *((long*)(_buffer + *_position));
            *_position += sizeof(long);
            return value;
        }

        public ulong ReadULong()
        {
            var value = *((ulong*)(_buffer + *_position));
            *_position += sizeof(ulong);
            return value;
        }

        public bool ReadBool()
        {
            var value = *((bool*)(_buffer + *_position));
            *_position += sizeof(bool);
            return value;
        }

        public float ReadFloat()
        {
            var value = *((float*)(_buffer + *_position));
            *_position += sizeof(float);
            return value;
        }

        public double ReadDouble()
        {
            var value = *((double*)(_buffer + *_position));
            *_position += sizeof(double);
            return value;
        }

        public decimal ReadDecimal()
        {
            var value = *((decimal*)(_buffer + *_position));
            *_position += sizeof(decimal);
            return value;
        }

        public byte[] ReadBytes(int length)
        {
            var value = new byte[length];
            fixed (byte* pv = value)
            {
                FastCopy.CopyBytes(pv, _buffer + *_position, length);
                *_position += length;
            }
            return value;
        }
    }
}
