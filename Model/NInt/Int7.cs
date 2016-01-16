namespace Jack.Model
{
    public struct Int7
    {
        NInt _value;

        private Int7(ulong l)
        {
            _value = new NInt(l, 7);
        }

        public static Int7 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int7 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int7 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int7 FromULong(ulong l)
        {
            return new Int7(l);
        }

        public static implicit operator ulong(Int7 n) => n._value;
        public static implicit operator long(Int7 n) => n._value;
        public static implicit operator uint(Int7 n) => n._value;
        public static implicit operator int(Int7 n) => n._value;
    }
}
