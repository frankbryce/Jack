namespace Jack.Model
{
    public struct Int11
    {
        NInt _value;

        private Int11(ulong l)
        {
            _value = new NInt(l, 11);
        }

        public static Int11 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int11 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int11 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int11 FromULong(ulong l)
        {
            return new Int11(l);
        }

        public static implicit operator ulong(Int11 n) => n._value;
        public static implicit operator long(Int11 n) => n._value;
        public static implicit operator uint(Int11 n) => n._value;
        public static implicit operator int(Int11 n) => n._value;
    }
}
