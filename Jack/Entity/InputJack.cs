using System.Linq;
using Jack.Utility;

namespace Jack.Entity
{
    public class InputJack : BaseJack
    {
        protected override Hash State
        {
            get
            {
                var hash = Hash.With(Input.Object);
                if (_subEntities.Any())
                {
                    hash = hash.AndWith(_subEntities.Select(x => x.Output.Object).ToArray());
                }
                return hash;
            }
        }

        public InputJack(int bufferSize, params IntelligentEntity<int, bool>[] subEntities) : base(bufferSize, subEntities)
        {
        }

        public InputJack(params IntelligentEntity<int, bool>[] subEntities) : this(0, subEntities)
        {
        }
    }
}