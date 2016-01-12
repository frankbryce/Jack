using System.Collections.Generic;
using System.Linq;
using ConsoleApplication11.Model;

namespace ConsoleApplication11.IntelligentEntity
{
    /// <summary>
    /// Looks at it's history of answers, and decides what to
    /// do based on how it's past decisions have helped or hurt
    /// itself.  If a decision (based on input X, output Y) returned
    /// good contentment then we'll do it again.  Sometimes
    /// the behavior isn't always the same, but we can still choose
    /// based on how often it hurts/helps us.  (only store so
    /// much history)
    /// </summary>
    public class Jack2 : IntelligentEntity<uint, bool>
    {
        private readonly List<Tuple<OutTuple, bool?>> outs;
        private const int maxSize = 100;

        public Jack2()
        {
            outs = new List<Tuple<OutTuple, bool?>>();
        }

        protected override IntelligenceOutput<bool> NextOutput()
        {
            if (outs.Count > 1)
            {
                outs[outs.Count-2].Item2 = Input.Contentment.Value >= CurrentContentment.Value;
            }

            var listPositive = outs
                .Where(x => x.Item2.HasValue && 
                            x.Item2.Value && 
                            x.Item1.@in == Input.Object)
                .ToList();
            var listNegative = outs
                .Where(x => x.Item2.HasValue &&
                            !x.Item2.Value &&
                            x.Item1.@in == Input.Object)
                .ToList();
            var trueCount = listPositive.Count(x => x.Item1.@out) +
                            listNegative.Count(x => !x.Item1.@out);
            var falseCount = listPositive.Count(x => !x.Item1.@out) +
                             listNegative.Count(x => x.Item1.@out);
            var output = trueCount >= falseCount;

            outs.Add(
                new Tuple<OutTuple, bool?>
                {
                    Item1 = new OutTuple {@in = Input.Object, @out = output},
                    Item2 = null
                });

            if (outs.Count > maxSize)
            {
                outs.RemoveAt(0);
            }

            return new IntelligenceOutput<bool> {Object = output};
        }

        public override string ToString() => Output.Object ? "dodge" : "straight";

        private class OutTuple
        {
            public bool @out;
            public uint @in;
        }

        private class Tuple<T1, T2>
        {
            public T1 Item1;
            public T2 Item2;
        }
    }
}