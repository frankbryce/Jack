using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Utility
{

    public class Hasher
    {
        public Hasher()
        {
            Value = 1;
        }

        public int Value { get; private set; }

        public Hasher Hash(params object[] objs)
        {
            foreach (var obj in objs)
            {
                Value = (int)((Value * obj.GetHashCode() + 3) % ((long)int.MaxValue + 1));
            }
            return this;
        }
    }
}
