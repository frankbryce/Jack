using Jack.Model;
using System;

namespace Jack.Environment.Entity
{
    public class StatefulEnvironment2 : EnvironmentEntity<int, bool>
    {
        private InternalState state = InternalState.SadPlace;
        private readonly bool[] outputs = { false, false, true, true };
        private int goodidx = 0;
        private readonly int numStates = Enum.GetValues(typeof(InternalState)).Length;

        protected override IntelligenceInput NextInput()
        {
            if (Output.Object == outputs[goodidx]) {
                state = (InternalState)(Math.Min((int)(state + 1), numStates));
            }
            else
            {
                state = (InternalState)(Math.Max((int)(state - 1), 1));
            }
            // toggle it
            goodidx = (goodidx + 1) % outputs.Length;

            switch (state)
            {
                //case InternalState.Intermediate1:
                //case InternalState.Intermediate3:
                //case InternalState.Intermediate2:
                //case InternalState.Intermediate4:
                //    return new IntelligenceInput { Object = 5, Contentment = 0.5 };

                case InternalState.HappyPlace:
                    return new IntelligenceInput { Object = 1, Contentment = 1.0 };

                case InternalState.SadPlace:
                default:
                    return new IntelligenceInput { Object = 9, Contentment = 0.0 };
            }
        }

        public override void Reset()
        {
            state = InternalState.SadPlace;
            goodidx = 0;
        }

        private enum InternalState
        {
            SadPlace=1,
            //Intermediate1,
            //Intermediate2,
            //Intermediate3,
            //Intermediate4,
            HappyPlace
        }
    }
}
