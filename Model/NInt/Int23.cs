namespace Jack.Model
{
    public struct Int23
    {
        NInt _value;

        private Int23(ulong l)
        {
            _value = new NInt(l, 23);
        }

        public static Int23 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int23 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int23 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int23 FromULong(ulong l)
        {
            return new Int23(l);
        }

        public static implicit operator ulong(Int23 n) => n._value;
        public static implicit operator long(Int23 n) => n._value;
        public static implicit operator uint(Int23 n) => n._value;
        public static implicit operator int(Int23 n) => n._value;
    }
}
