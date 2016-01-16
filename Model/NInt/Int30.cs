namespace Jack.Model
{
    public struct Int30
    {
        NInt _value;

        private Int30(ulong l)
        {
            _value = new NInt(l, 30);
        }

        public static Int30 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int30 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int30 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int30 FromULong(ulong l)
        {
            return new Int30(l);
        }

        public static implicit operator ulong(Int30 n) => n._value;
        public static implicit operator long(Int30 n) => n._value;
        public static implicit operator uint(Int30 n) => n._value;
        public static implicit operator int(Int30 n) => n._value;
    }
}
