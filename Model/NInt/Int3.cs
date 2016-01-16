namespace Jack.Model
{
    public struct Int3
    {
        NInt _value;

        private Int3(ulong l)
        {
            _value = new NInt(l, 3);
        }

        public static Int3 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int3 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int3 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int3 FromULong(ulong l)
        {
            return new Int3(l);
        }

        public static implicit operator ulong(Int3 n) => n._value;
        public static implicit operator long(Int3 n) => n._value;
        public static implicit operator uint(Int3 n) => n._value;
        public static implicit operator int(Int3 n) => n._value;
    }
}
