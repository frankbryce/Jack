namespace Jack.Model
{
    public struct Int14
    {
        NInt _value;

        private Int14(ulong l)
        {
            _value = new NInt(l, 14);
        }

        public static Int14 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int14 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int14 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int14 FromULong(ulong l)
        {
            return new Int14(l);
        }

        public static implicit operator ulong(Int14 n) => n._value;
        public static implicit operator long(Int14 n) => n._value;
        public static implicit operator uint(Int14 n) => n._value;
        public static implicit operator int(Int14 n) => n._value;
    }
}
