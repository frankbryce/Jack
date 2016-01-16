using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Utility
{

    public struct Hash
    {
        private Hash(int value)
        {
            if (value == 0)
            {
                throw new ArgumentOutOfRangeException("Hash value cannot be 0");
            }
            Value = value;
        }

        public static implicit operator int(Hash hash) => hash.Value;
        public static implicit operator Hash(int value) => new Hash(value);

        public int Value { get; private set; }
        
        public static Hash With<T>(params T[] objs)
        {
            Hash hash = 1;
            return hash.AndWith(objs);
        }

        public Hash AndWith<T>(params T[] objs)
        {
            var hash = new Hash(Value);
            foreach (var obj in objs)
            {
                var val = obj.GetHashCode();
                if (val == hash) val = -hash;
                hash = (val - hash) * 14107;
            }
            return hash;
        }
    }
}
