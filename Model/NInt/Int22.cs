namespace Jack.Model
{
    public struct Int22
    {
        NInt _value;

        private Int22(ulong l)
        {
            _value = new NInt(l, 22);
        }

        public static Int22 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int22 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int22 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int22 FromULong(ulong l)
        {
            return new Int22(l);
        }

        public static implicit operator ulong(Int22 n) => n._value;
        public static implicit operator long(Int22 n) => n._value;
        public static implicit operator uint(Int22 n) => n._value;
        public static implicit operator int(Int22 n) => n._value;
    }
}
