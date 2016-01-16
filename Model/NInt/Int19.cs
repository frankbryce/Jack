namespace Jack.Model
{
    public struct Int19
    {
        NInt _value;

        private Int19(ulong l)
        {
            _value = new NInt(l, 19);
        }

        public static Int19 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int19 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int19 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int19 FromULong(ulong l)
        {
            return new Int19(l);
        }

        public static implicit operator ulong(Int19 n) => n._value;
        public static implicit operator long(Int19 n) => n._value;
        public static implicit operator uint(Int19 n) => n._value;
        public static implicit operator int(Int19 n) => n._value;
    }
}
