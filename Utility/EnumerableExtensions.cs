using System.Collections.Generic;
using System.Linq;

namespace Jack.Utility
{
    public static class EnumerableExtensions
    {
        public static double AverageOrDefault(this IEnumerable<double> e, double @default = 0.0)
        {
            var list = e.ToList();
            return list.Any() ? list.Average() : @default;
        }
    }
}
