using System;

namespace Jack.Model
{
    internal struct NInt
    {
        private int _nBits;
        private ulong _value;

        public NInt(ulong l, int nBits = 32)
        {
            if (l >= ((ulong)(1) << nBits))
            {
                throw new ArgumentOutOfRangeException("l", string.Format("value exceeds the number of bits alloted for this NBit {0}", nBits));
            }

            _nBits = nBits;
            _value = l;
        }

        public static implicit operator ulong(NInt n) => n._value;
        public static implicit operator long(NInt n) => (long)n._value;
        public static implicit operator uint(NInt n) => (uint)n._value;
        public static implicit operator int(NInt n) => (int)n._value;
    }
}
