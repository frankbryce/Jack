namespace Jack.Model
{
    public struct Int21
    {
        NInt _value;

        private Int21(ulong l)
        {
            _value = new NInt(l, 21);
        }

        public static Int21 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int21 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int21 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int21 FromULong(ulong l)
        {
            return new Int21(l);
        }

        public static implicit operator ulong(Int21 n) => n._value;
        public static implicit operator long(Int21 n) => n._value;
        public static implicit operator uint(Int21 n) => n._value;
        public static implicit operator int(Int21 n) => n._value;
    }
}
