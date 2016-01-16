namespace Jack.Model
{
    public struct Int16
    {
        NInt _value;

        private Int16(ulong l)
        {
            _value = new NInt(l, 16);
        }

        public static Int16 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int16 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int16 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int16 FromULong(ulong l)
        {
            return new Int16(l);
        }

        public static implicit operator ulong(Int16 n) => n._value;
        public static implicit operator long(Int16 n) => n._value;
        public static implicit operator uint(Int16 n) => n._value;
        public static implicit operator int(Int16 n) => n._value;
    }
}
