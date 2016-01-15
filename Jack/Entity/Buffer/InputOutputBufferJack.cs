using System.Linq;
using Jack.Utility;

namespace Jack.Entity
{
    public class InputOutputBufferJack : BaseBufferJack
    {
        protected override Hash State
        {
            get
            {
                var hash = Hash.With(Input.Object)
                    .And(Output.Object);
                if (_subEntities.Any())
                {
                    hash = hash.And(_subEntities.Select(x => x.Output.Object).ToArray());
                }
                return hash;
            }
        }

        public InputOutputBufferJack(int layer, params IntelligentEntity<int, bool>[] subEntities) : base(layer, subEntities)
        {
        }
    }
}