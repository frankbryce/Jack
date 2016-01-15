using System.Linq;
using Jack.Utility;

namespace Jack.Entity
{
    public class InputBufferJack : BaseBufferJack
    {
        protected override Hash State
        {
            get
            {
                var hash = Hash.With(Input.Object);
                if (_subEntities.Any())
                {
                    hash = hash.And(_subEntities.Select(x => x.Output.Object).ToArray());
                }
                return hash;
            }
        }

        public InputBufferJack(int layer, params IntelligentEntity<int, bool>[] subEntities) : base(layer, subEntities)
        {
        }
    }
}