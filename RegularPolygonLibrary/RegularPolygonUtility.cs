using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularPolygonLibrary
{
    /// <summary>
    /// Helper class that stores constants and methods common for whole library project.
    /// </summary>
    public static class RegularPolygonUtility
    {
        private static readonly double _calculationPrecision = 0.01;

        /// <summary>
        /// Compares if difference between two given values is small enough to assume they are the same numbers.
        /// Maximum difference is stored in  _calculationPrecision field.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>True, if difference between arguments is small enough. Otherwise, returns false.</returns>
        public static bool CompareDouble(double first, double second)
        {
            return Math.Abs((first - second)) <= _calculationPrecision;
        }
    }
}
