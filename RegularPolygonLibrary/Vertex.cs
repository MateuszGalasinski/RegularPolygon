using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility = RegularPolygonLibrary.RegularPolygonUtility;

namespace RegularPolygonLibrary
{
    /// <summary>
    /// Represents single point on plane using two cartesian coordinates : x and y.
    /// </summary>
    public struct Vertex
    {
        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        /// <summary>
        /// Calculates euclidean distance between this vertex and given vertex.
        /// </summary>
        /// <param name="secondVertex"> Vertex to calculate distance from</param>
        /// <returns>Distance value as double</returns>
        public double GetDistanceFrom(Vertex secondVertex)
        {
            double distance = Math.Pow((X - secondVertex.X), 2);
            distance += Math.Pow((Y - secondVertex.Y), 2);
            distance = Math.Sqrt(distance);
            return distance;
        }

        /// <summary>
        /// Checks objects equality.
        /// Uses CompareDouble from RegularPolygonUtilityUtility class when comparing X and Y values.
        /// <see cref="RegularPolygonUtility.CompareDouble(double, double)"/>
        /// </summary>
        /// <param name="obj"> Object for comparison</param>
        /// <returns>True, if objects meet equality requirements. Otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vertex))
                return false;

            Vertex second = (Vertex)obj;
            if(Utility.CompareDouble(X, second.X) && Utility.CompareDouble(Y, second.Y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
