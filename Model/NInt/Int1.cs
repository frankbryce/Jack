

namespace Jack.Model
{
    public struct Int1
    {
        NInt _value;

        private Int1(ulong l)
        {
            _value = new NInt(l, 1);
        }

        public static Int1 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int1 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int1 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int1 FromULong(ulong l)
        {
            return new Int1(l);
        }

        public static implicit operator ulong(Int1 n) => n._value;
        public static implicit operator long(Int1 n) => n._value;
        public static implicit operator uint(Int1 n) => n._value;
        public static implicit operator int(Int1 n) => n._value;
    }
}
