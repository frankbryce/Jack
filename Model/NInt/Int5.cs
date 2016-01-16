namespace Jack.Model
{
    public struct Int5
    {
        NInt _value;

        private Int5(ulong l)
        {
            _value = new NInt(l, 5);
        }

        public static Int5 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int5 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int5 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int5 FromULong(ulong l)
        {
            return new Int5(l);
        }

        public static implicit operator ulong(Int5 n) => n._value;
        public static implicit operator long(Int5 n) => n._value;
        public static implicit operator uint(Int5 n) => n._value;
        public static implicit operator int(Int5 n) => n._value;
    }
}
