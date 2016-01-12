using System;
using System.Globalization;

namespace ConsoleApplication11.Model
{
    public struct Intelligence
    {
        private readonly double _value;
        
        public Intelligence(double value)
        {
            if(value < 0 || value > 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "value must be between 0 and 1, inclusive");
            }
            _value = value;
        }

        public double Value => _value;

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }
}