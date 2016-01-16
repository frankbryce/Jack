namespace Jack.Model
{
    public struct Int29
    {
        NInt _value;

        private Int29(ulong l)
        {
            _value = new NInt(l, 29);
        }

        public static Int29 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int29 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int29 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int29 FromULong(ulong l)
        {
            return new Int29(l);
        }

        public static implicit operator ulong(Int29 n) => n._value;
        public static implicit operator long(Int29 n) => n._value;
        public static implicit operator uint(Int29 n) => n._value;
        public static implicit operator int(Int29 n) => n._value;
    }
}
