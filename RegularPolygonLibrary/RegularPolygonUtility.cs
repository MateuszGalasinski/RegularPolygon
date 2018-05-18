using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularPolygonLibrary
{
    public static class RegularPolygonUtility
    {
        private static readonly double calculationPrecision = 0.01;

        public static bool CompareDouble(double first, double second)
        {
            return Math.Abs((first - second)) <= calculationPrecision;
        }
    }
}
