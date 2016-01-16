namespace Jack.Model
{
    public struct Int20
    {
        NInt _value;

        private Int20(ulong l)
        {
            _value = new NInt(l, 20);
        }

        public static Int20 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int20 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int20 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int20 FromULong(ulong l)
        {
            return new Int20(l);
        }

        public static implicit operator ulong(Int20 n) => n._value;
        public static implicit operator long(Int20 n) => n._value;
        public static implicit operator uint(Int20 n) => n._value;
        public static implicit operator int(Int20 n) => n._value;
    }
}
