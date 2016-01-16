using System.Linq;
using Jack.Utility;

namespace Jack.Entity
{
    public class CompositeJack : BaseJack
    {
        protected override Hash GetState()
        {
            var hash = Hash.Identity;
            if (_subEntities.Any())
            {
                hash = hash.AndWith(_subEntities.Select(x => x.State).ToArray());
            }
            return hash;
        }

        public CompositeJack(int bufferSize, params BaseJack[] subEntities) : base(bufferSize, subEntities)
        {
        }

        public CompositeJack(params BaseJack[] subEntities) : this(0, subEntities)
        {
        }
    }
}