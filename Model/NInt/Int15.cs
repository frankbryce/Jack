namespace Jack.Model
{
    public struct Int15
    {
        NInt _value;

        private Int15(ulong l)
        {
            _value = new NInt(l, 15);
        }

        public static Int15 FromInt(int i)
        {
            return FromLong(i);
        }

        public static Int15 FromUInt(uint i)
        {
            return FromULong(i);
        }

        public static Int15 FromLong(long l)
        {
            return FromULong((ulong)l);
        }

        public static Int15 FromULong(ulong l)
        {
            return new Int15(l);
        }

        public static implicit operator ulong(Int15 n) => n._value;
        public static implicit operator long(Int15 n) => n._value;
        public static implicit operator uint(Int15 n) => n._value;
        public static implicit operator int(Int15 n) => n._value;
    }
}
