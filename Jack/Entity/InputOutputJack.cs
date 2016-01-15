using System.Linq;
using Jack.Utility;

namespace Jack.Entity
{
    public class InputOutputJack : BaseJack
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

        public InputOutputJack(params IntelligentEntity<int, bool>[] subEntities) : base(subEntities)
        {
        }
    }
}