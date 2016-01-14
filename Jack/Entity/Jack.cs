﻿using Jack.Model;

namespace Jack.Entity
{
    /// <summary>
    /// stupid stupid stupid... constant behavior with no adaptability.
    /// 
    /// Yet this is the FIRST intelligent software!  Weird.
    /// </summary>
    public class Jack : IntelligentEntity<uint, bool>
    {
        protected override IntelligenceOutput NextOutput()
        {
            return new IntelligenceOutput<bool> {Object = Input.Object==0};
        }

        public override string ToString() => Output.Object ? "dodge" : "straight";
    }
}