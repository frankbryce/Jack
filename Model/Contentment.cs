using System;

namespace Jack.Model
{
    public struct Contentment
    {
        public double Value { get; }

        private Contentment(double value)
        {
            Value = value;
        }

        public static Contentment FromDouble(double d)
        {
            if (double.IsNaN(d))
            {
                throw new ArgumentException("double.NaN is not a valid Contentment Value");
            }

            if(d < 0 || d > 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(d),
                    "value must be between 0 and 1, inclusive");
            }

            return new Contentment(d);
        }

        #region Casts
        //public static implicit operator double(Contentment value) => value.Value;
        public static implicit operator Contentment(double value) => new Contentment(value);
        #endregion Casts

        #region Arithmetic Operators
        public static Contentment operator +(Contentment r1, Contentment r2)
            => new Contentment(r1.Value + r2.Value);
        public static Contentment operator -(Contentment r1, Contentment r2)
            => new Contentment(r1.Value - r2.Value);
        public static Contentment operator *(Contentment r1, Contentment r2)
            => new Contentment(r1.Value * r2.Value);
        public static Contentment operator /(Contentment r1, Contentment r2)
            => new Contentment(r1.Value / r2.Value);
        #endregion Arithmetic Operators

        #region Comparison Operators
        public static bool operator <(Contentment x, Contentment y) => CompareTo(x, y) < 0;
        public static bool operator >(Contentment x, Contentment y) => CompareTo(x, y) > 0;
        public static bool operator <=(Contentment x, Contentment y) => CompareTo(x, y) <= 0;
        public static bool operator >=(Contentment x, Contentment y) => CompareTo(x, y) >= 0;
        public static bool operator ==(Contentment x, Contentment y) => CompareTo(x, y) == 0;
        public static bool operator !=(Contentment x, Contentment y) => CompareTo(x, y) != 0;
        #endregion Comparison Operators

        #region Comparisons
        public override bool Equals(object obj) =>
          (obj is Contentment) && (CompareTo(this, (Contentment)obj) == 0);
        public override int GetHashCode() => Value.GetHashCode();
        public int CompareTo(Contentment x) => CompareTo(this, x);
        public bool Equals(Contentment x) => CompareTo(this, x) == 0;
        public static int CompareTo(Contentment x, Contentment y) => x.Value.CompareTo(y.Value);
        #endregion Comparisons

        public override string ToString() => string.Format("{0:0.###}%", Value * 100);
    }
}