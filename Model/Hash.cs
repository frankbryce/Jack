using System;

namespace Jack.Utility
{

    public struct Hash : IEquatable<Hash>, ICloneable
    {
        private bool _isIdentity;
        private int _value;

        private Hash(int value, bool IsIdentity = false)
        {
            _isIdentity = IsIdentity;
            _value = value;
        }

        public static Hash FromInt(int value)
        {
            return new Hash(value);
        }

        public static implicit operator int(Hash hash) => hash.GetHashCode();
        public static implicit operator Hash(int value) => FromInt(value);
        public static bool operator !=(Hash h1, Hash h2) => !h1.Equals(h2);
        public static bool operator ==(Hash h1, Hash h2) => h1.Equals(h2);
        public bool Equals(Hash h)
        {
            return h._value == _value && h._isIdentity == _isIdentity;
        }
        public override bool Equals(object h)
        {
            if (h.GetType() != typeof(Hash)) { return false; }
            return Equals((Hash) h);
        }
        public static Hash Identity => new Hash(0, IsIdentity: true);

        public static Hash With<T>(params T[] objs)
        {
            return Identity.AndWith(objs);
        }

        public Hash AndWith<T>(params T[] objs)
        {
            var hash = Clone();
            foreach (var obj in objs)
            {
                if (typeof(T) == typeof(Hash) && Identity.Equals(obj)) continue;
                hash = hash.HashFunc(obj.GetHashCode());
            }
            return hash;
        }

        private Hash HashFunc(Hash h1)
        {
            if (h1 == Identity) return this;
            if (this == Identity) return h1;

            var i = Jumble(Jumble(h1));
            return (i - this);
        }
        private int Jumble(int h1)
        {
            return randomHash[0][(h1 & 0xF0000000) >> 28] << 28
                 | randomHash[1][(h1 & 0x0F000000) >> 24] << 24
                 | randomHash[2][(h1 & 0x00F00000) >> 20] << 20
                 | randomHash[3][(h1 & 0x000F0000) >> 16] << 16
                 | randomHash[4][(h1 & 0x0000F000) >> 12] << 12
                 | randomHash[5][(h1 & 0x00000F00) >> 8] << 8
                 | randomHash[6][(h1 & 0x000000F0) >> 4] << 4
                 | randomHash[7][(h1 & 0x0000000F) >> 0] << 0;
        }

        public override int GetHashCode()
        {
            return _value;
        }

        public Hash Clone()
        {
            return new Hash(_value, _isIdentity);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        private static byte[][] randomHash => new byte[][] {
            new byte[] { 11, 8, 10, 15, 13, 0, 3, 14, 9, 6, 4, 2, 7, 1, 5, 12 },
            new byte[] { 3, 5, 11, 15, 7, 8, 0, 13, 9, 10, 4, 14, 1, 12, 6, 2 },
            new byte[] { 4, 2, 0, 13, 9, 7, 14, 12, 15, 3, 5, 10, 11, 8, 1, 6 },
            new byte[] { 0, 12, 1, 3, 10, 2, 6, 8, 9, 14, 5, 11, 7, 13, 15, 4 },
            new byte[] { 6, 10, 2, 14, 15, 9, 4, 12, 1, 5, 13, 7, 0, 3, 8, 11 },
            new byte[] { 8, 6, 10, 11, 5, 13, 14, 12, 7, 3, 1, 9, 4, 15, 2, 0 },
            new byte[] { 10, 14, 13, 11, 9, 15, 5, 8, 3, 1, 0, 12, 2, 4, 6, 7 },
            new byte[] { 4, 9, 14, 15, 0, 5, 11, 2, 1, 7, 8, 13, 6, 10, 12, 3 }
        };
    }
}
