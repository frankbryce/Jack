namespace Jack.Model
{
    public struct Int12
    {
        NInt _value;

        private Int12(ulong l)
        {
            _value = new NInt(l, 12);
        }

        public static Int12 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int12 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int12 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int12 FromULong(ulong l)
        {
            return new Int12(l);
        }

        public static implicit operator ulong(Int12 n) => n._value;
        public static implicit operator long(Int12 n) => n._value;
        public static implicit operator uint(Int12 n) => n._value;
        public static implicit operator int(Int12 n) => n._value;
    }
}
