namespace Jack.Model
{
    public struct Int13
    {
        NInt _value;

        private Int13(ulong l)
        {
            _value = new NInt(l, 13);
        }

        public static Int13 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int13 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int13 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int13 FromULong(ulong l)
        {
            return new Int13(l);
        }

        public static implicit operator ulong(Int13 n) => n._value;
        public static implicit operator long(Int13 n) => n._value;
        public static implicit operator uint(Int13 n) => n._value;
        public static implicit operator int(Int13 n) => n._value;
    }
}
