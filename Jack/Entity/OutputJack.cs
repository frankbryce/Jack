using System.Linq;
using Jack.Utility;

namespace Jack.Entity
{
    public class OutputJack : BaseJack
    {
        protected override Hash GetState()
        {
            return Hash.With(base.GetState())
                .AndWith(Output.Object);
        }

        public OutputJack(int bufferSize, params BaseJack[] subEntities) : base(bufferSize, subEntities)
        {
        }

        public OutputJack(params BaseJack[] subEntities) : this(0, subEntities)
        {
        }
    }
}