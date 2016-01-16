namespace Jack.Model
{
    public struct Int17
    {
        NInt _value;

        private Int17(ulong l)
        {
            _value = new NInt(l, 17);
        }

        public static Int17 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int17 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int17 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int17 FromULong(ulong l)
        {
            return new Int17(l);
        }

        public static implicit operator ulong(Int17 n) => n._value;
        public static implicit operator long(Int17 n) => n._value;
        public static implicit operator uint(Int17 n) => n._value;
        public static implicit operator int(Int17 n) => n._value;
    }
}
