namespace Jack.Model
{
    public struct Int31
    {
        NInt _value;

        private Int31(ulong l)
        {
            _value = new NInt(l, 31);
        }

        public static Int31 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int31 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int31 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int31 FromULong(ulong l)
        {
            return new Int31(l);
        }

        public static implicit operator ulong(Int31 n) => n._value;
        public static implicit operator long(Int31 n) => n._value;
        public static implicit operator uint(Int31 n) => n._value;
        public static implicit operator int(Int31 n) => n._value;
    }
}
