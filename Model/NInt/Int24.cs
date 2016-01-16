namespace Jack.Model
{
    public struct Int24
    {
        NInt _value;

        private Int24(ulong l)
        {
            _value = new NInt(l, 24);
        }

        public static Int24 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int24 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int24 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int24 FromULong(ulong l)
        {
            return new Int24(l);
        }

        public static implicit operator ulong(Int24 n) => n._value;
        public static implicit operator long(Int24 n) => n._value;
        public static implicit operator uint(Int24 n) => n._value;
        public static implicit operator int(Int24 n) => n._value;
    }
}
