namespace Jack.Model
{
    public struct Int18
    {
        NInt _value;

        private Int18(ulong l)
        {
            _value = new NInt(l, 18);
        }

        public static Int18 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int18 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int18 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int18 FromULong(ulong l)
        {
            return new Int18(l);
        }

        public static implicit operator ulong(Int18 n) => n._value;
        public static implicit operator long(Int18 n) => n._value;
        public static implicit operator uint(Int18 n) => n._value;
        public static implicit operator int(Int18 n) => n._value;
    }
}
