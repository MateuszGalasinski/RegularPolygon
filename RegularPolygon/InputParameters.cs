using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularPolygonConsoleApplication
{
    /// <summary>
    /// Represents input parameters for console application in organized, objective manner.
    /// </summary>
    internal class InputParameters
    {
        public int NumberOfVertices { get; set; }
        public double SideLength { get; set; }
        public ApplicationMode Mode { get; set; }
    }
}
