using System.Linq;
using Jack.Utility;

namespace Jack.Entity
{
    public class NullJack : BaseJack
    {
        protected override Hash GetState()
        {
            Hash hash = 1;
            if (_subEntities.Any())
            {
                hash = hash.AndWith(_subEntities.Select(x => x.State).ToArray());
            }
            return hash;
        }

        public NullJack(int bufferSize, params BaseJack[] subEntities) : base(bufferSize, subEntities)
        {
        }

        public NullJack(params BaseJack[] subEntities) : this(0, subEntities)
        {
        }
    }
}