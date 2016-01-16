namespace Jack.Model
{
    public struct Int6
    {
        NInt _value;

        private Int6(ulong l)
        {
            _value = new NInt(l, 6);
        }

        public static Int6 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int6 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int6 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int6 FromULong(ulong l)
        {
            return new Int6(l);
        }

        public static implicit operator ulong(Int6 n) => n._value;
        public static implicit operator long(Int6 n) => n._value;
        public static implicit operator uint(Int6 n) => n._value;
        public static implicit operator int(Int6 n) => n._value;
    }
}
