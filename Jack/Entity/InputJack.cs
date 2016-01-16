using System.Linq;
using Jack.Utility;

namespace Jack.Entity
{
    public class InputJack : BaseJack
    {
        protected override Hash GetState()
        {
            return Hash.With(base.GetState())
                .AndWith(Input.Object);
        }

        public InputJack(int bufferSize, params BaseJack[] subEntities) : base(bufferSize, subEntities)
        {
        }

        public InputJack(params BaseJack[] subEntities) : this(0, subEntities)
        {
        }
    }
}