namespace Jack.Model
{
    public struct Int25
    {
        NInt _value;

        private Int25(ulong l)
        {
            _value = new NInt(l, 25);
        }

        public static Int25 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int25 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int25 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int25 FromULong(ulong l)
        {
            return new Int25(l);
        }

        public static implicit operator ulong(Int25 n) => n._value;
        public static implicit operator long(Int25 n) => n._value;
        public static implicit operator uint(Int25 n) => n._value;
        public static implicit operator int(Int25 n) => n._value;
    }
}
