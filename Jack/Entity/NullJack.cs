using System.Linq;
using Jack.Utility;

namespace Jack.Entity
{
    public class NullJack : BaseJack
    {
        protected override Hash State
        {
            get
            {
                Hash hash = 1;
                if (_subEntities.Any())
                {
                    hash = hash.AndWith(_subEntities.Select(x => x.Output.Object).ToArray());
                }
                return hash;
            }
        }

        public NullJack(int bufferSize, params IntelligentEntity<int, bool>[] subEntities) : base(bufferSize, subEntities)
        {
        }

        public NullJack(params IntelligentEntity<int, bool>[] subEntities) : this(0, subEntities)
        {
        }
    }
}