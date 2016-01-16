namespace Jack.Model
{
    public struct Int26
    {
        NInt _value;

        private Int26(ulong l)
        {
            _value = new NInt(l, 26);
        }

        public static Int26 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int26 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int26 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int26 FromULong(ulong l)
        {
            return new Int26(l);
        }

        public static implicit operator ulong(Int26 n) => n._value;
        public static implicit operator long(Int26 n) => n._value;
        public static implicit operator uint(Int26 n) => n._value;
        public static implicit operator int(Int26 n) => n._value;
    }
}
