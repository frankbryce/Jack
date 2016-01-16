namespace Jack.Model
{
    public struct Int2
    {
        NInt _value;

        private Int2(ulong l)
        {
            _value = new NInt(l, 2);
        }

        public static Int2 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int2 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int2 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int2 FromULong(ulong l)
        {
            return new Int2(l);
        }

        public static implicit operator ulong(Int2 n) => n._value;
        public static implicit operator long(Int2 n) => n._value;
        public static implicit operator uint(Int2 n) => n._value;
        public static implicit operator int(Int2 n) => n._value;
    }
}
