using System;

namespace Jack.Utility
{

    public struct Hash : ICloneable
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
        public static Hash Identity => new Hash(0, IsIdentity: true);

        public static Hash With<T>(params T[] objs)
        {
            return Identity.AndWith(objs);
        }

        public Hash AndWith(params Hash[] objs)
        {
            var hash = (Hash)Clone();
            foreach (var obj in objs)
            {
                if (obj == Identity) continue;
                hash = HashFunc(obj, hash);
            }
            return hash;
        }

        public Hash AndWith<T>(params T[] objs)
        {
            var hash = (Hash) Clone();
            foreach (var obj in objs)
            {
                hash = HashFunc(new Hash(obj.GetHashCode()), hash);
            }
            return hash;
        }

        private static Hash HashFunc(Hash h1, Hash h2)
        {
            if (h1 == Identity) return h2;
            if (h2 == Identity) return h1;

            if (h1 == h2) h1 = -h2;
            return (h1 - h2) * 14107;
        }

        public override int GetHashCode()
        {
            return _value;
        }

        public object Clone()
        {
            return new Hash(_value, _isIdentity);
        }
    }
}
