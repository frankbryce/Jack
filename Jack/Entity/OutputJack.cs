using System.Linq;
using Jack.Utility;

namespace Jack.Entity
{
    public class OutputJack : BaseJack
    {
        protected override Hash GetState()
        {
            var hash = Hash.With(Output.Object);
            if (_subEntities.Any())
            {
                hash = hash.AndWith(_subEntities.Select(x => x.Output.Object).ToArray());
            }
            return hash;
        }

        public OutputJack(int bufferSize, params BaseJack[] subEntities) : base(bufferSize, subEntities)
        {
        }

        public OutputJack(params BaseJack[] subEntities) : this(0, subEntities)
        {
        }
    }
}