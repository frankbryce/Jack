namespace Jack.Model
{
    public struct Int8
    {
        NInt _value;

        private Int8(ulong l)
        {
            _value = new NInt(l, 8);
        }

        public static Int8 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int8 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int8 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int8 FromULong(ulong l)
        {
            return new Int8(l);
        }

        public static implicit operator ulong(Int8 n) => n._value;
        public static implicit operator long(Int8 n) => n._value;
        public static implicit operator uint(Int8 n) => n._value;
        public static implicit operator int(Int8 n) => n._value;
    }
}
