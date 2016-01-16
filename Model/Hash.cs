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
            long myValue = ((_isIdentity ? 0x1 : 0x0) << 31) + _value;
            long theirValue = ((h._isIdentity ? 0x1 : 0x0) << 31) + h._value;
            return myValue == theirValue;
        }
        public override bool Equals(object h)
        {
            if (h.GetType() != typeof(Hash)) { return false; }
            return Equals((Hash)h);
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
                hash = HashFunc(new Hash(obj.GetHashCode()), hash);
            }
            return hash;
        }

        private static Hash HashFunc(Hash h1, Hash h2)
        {
            if (h1 == Identity) return h2;
            if (h2 == Identity) return h1;

            if (h1 == h2) h1 = -h2;
            return (h1 - h2);
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
    }
}
