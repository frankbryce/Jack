namespace Jack.Model
{
    public struct Int27
    {
        NInt _value;

        private Int27(ulong l)
        {
            _value = new NInt(l, 27);
        }

        public static Int27 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int27 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int27 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int27 FromULong(ulong l)
        {
            return new Int27(l);
        }

        public static implicit operator ulong(Int27 n) => n._value;
        public static implicit operator long(Int27 n) => n._value;
        public static implicit operator uint(Int27 n) => n._value;
        public static implicit operator int(Int27 n) => n._value;
    }
}
