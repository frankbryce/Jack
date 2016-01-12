using System;
using System.Globalization;

namespace Jack.Model
{
    public struct Contentment
    {
        public double Value;

        public Contentment(double value)
        {
            if (value < 0 || value > 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "value must be between 0 and 1, inclusive");
            }
            Value = value;
        }

        public static implicit operator Contentment(double value) =>
            new Contentment(value);

        public static Contentment operator *(double d, Contentment r)
            => new Contentment(d) * r;
        public static Contentment operator *(Contentment r, double d)
            => d*r;
        public static Contentment operator *(Contentment r1, Contentment r2)
            => new Contentment(r1.Value * r2.Value);
        public static Contentment operator +(Contentment r1, Contentment r2)
            => new Contentment(r1.Value + r2.Value);
        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }
}