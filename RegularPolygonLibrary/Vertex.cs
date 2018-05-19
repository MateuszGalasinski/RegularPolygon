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
    public struct Vertex : IEquatable<Vertex>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get;}
        public double Y { get;}

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
        /// <param name="other">Vertex for comparison</param>
        /// <returns>True, if objects meet equality requirements. Otherwise, false.</returns>
        public bool Equals(Vertex other)
        {
            if (Utility.CompareDouble(X, other.X) && Utility.CompareDouble(Y, other.Y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Default implementation for future uses.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}
