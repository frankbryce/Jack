namespace Jack.Model
{
    public struct Int28
    {
        NInt _value;

        private Int28(ulong l)
        {
            _value = new NInt(l, 28);
        }

        public static Int28 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int28 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int28 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int28 FromULong(ulong l)
        {
            return new Int28(l);
        }

        public static implicit operator ulong(Int28 n) => n._value;
        public static implicit operator long(Int28 n) => n._value;
        public static implicit operator uint(Int28 n) => n._value;
        public static implicit operator int(Int28 n) => n._value;
    }
}
