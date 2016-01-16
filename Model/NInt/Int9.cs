namespace Jack.Model
{
    public struct Int9
    {
        NInt _value;

        private Int9(ulong l)
        {
            _value = new NInt(l, 9);
        }

        public static Int9 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int9 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int9 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int9 FromULong(ulong l)
        {
            return new Int9(l);
        }

        public static implicit operator ulong(Int9 n) => n._value;
        public static implicit operator long(Int9 n) => n._value;
        public static implicit operator uint(Int9 n) => n._value;
        public static implicit operator int(Int9 n) => n._value;
    }
}
