using System.Linq;
using Jack.Utility;

namespace Jack.Entity
{
    public class InputOutputJack : BaseJack
    {
        protected override Hash GetState()
        {
            var hash = Hash.With(base.GetState())
                .AndWith(Input.Object)
                .AndWith(Output.Object);
            return hash;
        }

        public InputOutputJack(int bufferSize, params BaseJack[] subEntities) : base(bufferSize, subEntities)
        {
        }

        public InputOutputJack(params BaseJack[] subEntities) : this(0, subEntities)
        {
        }
    }
}