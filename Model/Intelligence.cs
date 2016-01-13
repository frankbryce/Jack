using System;
using System.Globalization;

namespace Jack.Model
{
    public struct Intelligence
    {
        private double Value { get; }
        
        public Intelligence(double value)
        {
            Value = value;
        }

        public static Intelligence FromDouble(double d)
        {
            if(double.IsNaN(d))
            {
                throw new ArgumentException("double.NaN is not a valid Intelligence Value");
            }

            if(d < 0 || d > 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(d),
                    "value must be between 0 and 1, inclusive");
            }

            return new Intelligence(d);
        }

        #region Casts
        //public static implicit operator double(Intelligence value) => value.Value;
        public static implicit operator Intelligence(double value) => new Intelligence(value);
        #endregion Casts

        #region Arithmetic Operators
        public static Intelligence operator +(Intelligence r1, Intelligence r2)
            => new Intelligence(r1.Value + r2.Value);
        public static Intelligence operator -(Intelligence r1, Intelligence r2)
            => new Intelligence(r1.Value - r2.Value);
        public static Intelligence operator *(Intelligence r1, Intelligence r2)
            => new Intelligence(r1.Value * r2.Value);
        public static Intelligence operator /(Intelligence r1, Intelligence r2)
            => new Intelligence(r1.Value / r2.Value);
        #endregion Arithmetic Operators

        #region Comparison Operators
        public static bool operator <(Intelligence x, Intelligence y) => CompareTo(x, y) < 0;
        public static bool operator >(Intelligence x, Intelligence y) => CompareTo(x, y) > 0;
        public static bool operator <=(Intelligence x, Intelligence y) => CompareTo(x, y) <= 0;
        public static bool operator >=(Intelligence x, Intelligence y) => CompareTo(x, y) >= 0;
        public static bool operator ==(Intelligence x, Intelligence y) => CompareTo(x, y) == 0;
        public static bool operator !=(Intelligence x, Intelligence y) => CompareTo(x, y) != 0;
        #endregion Comparison Operators

        #region Comparisons
        public override bool Equals(object obj) =>
          (obj is Intelligence) && (CompareTo(this, (Intelligence)obj) == 0);
        public override int GetHashCode() => Value.GetHashCode();
        public int CompareTo(Intelligence x) => CompareTo(this, x);
        public bool Equals(Intelligence x) => CompareTo(this, x) == 0;
        public static int CompareTo(Intelligence x, Intelligence y) => x.Value.CompareTo(y.Value);
        #endregion Comparisons

        public override string ToString() => string.Format("{0:0.###}%", Value * 100);
    }
}