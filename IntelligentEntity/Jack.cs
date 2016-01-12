using System;
using System.Collections;
using ConsoleApplication11.Model;

namespace ConsoleApplication11.IntelligentEntity
{
    /// <summary>
    /// stupid stupid stupid... constant behavior with no adaptability.
    /// 
    /// Yet this is the FIRST intelligent software!  Weird.
    /// </summary>
    public class Jack : IntelligentEntity<uint, bool>
    {
        protected override IntelligenceOutput<bool> NextOutput()
        {
            return new IntelligenceOutput<bool> {Object = Input.Object==0};
        }

        public override string ToString() => Output.Object ? "dodge" : "straight";
    }
}