namespace Jack.Model
{
    public struct Int32
    {
        NInt _value;

        private Int32(ulong l)
        {
            _value = new NInt(l, 32);
        }

        public static Int32 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int32 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int32 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int32 FromULong(ulong l)
        {
            return new Int32(l);
        }

        public static implicit operator ulong(Int32 n) => n._value;
        public static implicit operator long(Int32 n) => n._value;
        public static implicit operator uint(Int32 n) => n._value;
        public static implicit operator int(Int32 n) => n._value;
    }
}
