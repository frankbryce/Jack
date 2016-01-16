namespace Jack.Model
{
    public struct Int4
    {
        NInt _value;

        private Int4(ulong l)
        {
            _value = new NInt(l, 4);
        }

        public static Int4 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int4 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int4 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int4 FromULong(ulong l)
        {
            return new Int4(l);
        }

        public static implicit operator ulong(Int4 n) => n._value;
        public static implicit operator long(Int4 n) => n._value;
        public static implicit operator uint(Int4 n) => n._value;
        public static implicit operator int(Int4 n) => n._value;
    }
}
