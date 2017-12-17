using System;

namespace Fast.Data
{
    public class FastBuffer
    {
        private byte[] _buffer;
        private int _position;

        public FastBuffer(int capacity)
        {
            Reset(capacity);
        }

        public FastBuffer(byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            _buffer = buffer;
        }

        public void Reset(int capacity)
        {
            if (capacity <= 0) throw new ArgumentException("capacity must be greater than 0", "capacity");
            _buffer = new byte[capacity];
            _position = 0;
        }

        public void Reset()
        {
            Reset(_buffer.Length);
        }

        public unsafe T Do<T>(Func<BufferActions, T> doFunc)
        {
            fixed (byte* p = _buffer)
            {
                int position = _position;
                var actions = new BufferActions(p, &position);
                var result = doFunc(actions);
                _position = position;

                // sanity check for read or write overflow
                if (position > _buffer.Length)
                {
                    var msg = string.Format("Buffer actions went out of bounds. Possible read or write overflow. Max size: {0}. Position: {1}.",
                        _buffer.Length, position);
                    throw new InvalidOperationException(msg);
                }

                return result;
            }
        }

        public void Do(Action<BufferActions> doAction)
        {
            if (doAction == null) throw new ArgumentNullException("doAction");
            Do(x => { doAction(x); return 0; });
        }

        public byte[] Get()
        {
            return _buffer;
        }

        public int GetPosition()
        {
            return _position;
        }

        public int GetCapacity()
        {
            return _buffer.Length;
        }
    }
}
