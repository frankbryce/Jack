namespace Jack.Model
{
    public struct Int10
    {
        NInt _value;

        private Int10(ulong l)
        {
            _value = new NInt(l, 10);
        }

        public static Int10 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int10 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int10 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int10 FromULong(ulong l)
        {
            return new Int10(l);
        }

        public static implicit operator ulong(Int10 n) => n._value;
        public static implicit operator long(Int10 n) => n._value;
        public static implicit operator uint(Int10 n) => n._value;
        public static implicit operator int(Int10 n) => n._value;
    }
}
