using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility = RegularPolygonLibrary.RegularPolygonUtility;

namespace RegularPolygonLibrary
{
    /// <summary>
    /// Represents regular convex polygon byarray of vertices on plane.
    /// </summary>
    public class RegularPolygon
    {
        /// <summary>
        /// Array of consecutive vertices representing polygon.
        /// </summary>
        private Vertex[] vertices;

        /// Vertices order in "newVertices" matters, because every neighbouring pair of vertices in array,
        /// including also pair: first and last, determine one side of polygon.
        /// Thus these vertices must determine sides with equal lengths or an exception will be thrown.
        public RegularPolygon(Vertex[] newVertices)
        {
            ValidateVertices(newVertices);

            vertices = newVertices;
            SideLength = newVertices[0].GetDistanceFrom(newVertices[1]); // distance between vertices is equal, so can choose first side.
        }

        /// <summary>
        /// Returns a copy of vertices array in order to ensure correct polygon state.
        /// </summary>
        public Vertex[] Vertices
        {
            get
            {
                Vertex[] copyVertices = new Vertex[vertices.Length];
                Array.Copy(vertices, copyVertices, vertices.Length);
                return copyVertices;
            }
        }

        /// <summary>
        /// Readonly property returns length of inside array of vertices.
        /// </summary>
        public int NumberOfVertices => vertices.Length;
 
        /// <summary>
        /// Readonly property that stores single side length. It is set during polygon construction.
        /// </summary>
        public double SideLength { get;}

        /// <summary>
        /// Calculates polygon area.
        /// </summary>
        /// <returns>Polygon area</returns>
        public double CalculateArea()
        {
            double area = 1.0 / 4 * vertices.Length;
            area *= Math.Pow(SideLength, 2);
            area *= 1.0 / Math.Tan(Math.PI / vertices.Length);
            return area;
        }

        /// <summary>
        /// Creates polygon full description.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Regular polygon with {vertices.Length.ToString(CultureInfo.InvariantCulture)} vertices: ");
            builder.AppendLine($"Side length = {SideLength.ToString("f2", CultureInfo.InvariantCulture)}");
            builder.AppendLine($"Area = {CalculateArea().ToString("f2", CultureInfo.InvariantCulture)}");
            for (int i = 0; i < vertices.Length; i++)
            {
                builder.AppendLine($"{i}. X = {vertices[i].X.ToString("f2", CultureInfo.InvariantCulture)}" +
                                      $", Y = {vertices[i].Y.ToString("f2", CultureInfo.InvariantCulture)}");
            }
            string description = builder.ToString();
            return description;
        }

        private bool ValidateVertices(Vertex[] vertices)
        {
            if (vertices == null)
            {
                throw new RegularPolygonException("Cannot create polygon without vertices.");
            }
            if (vertices.Length <= 2)
            {
                throw new RegularPolygonException($"Cannot create polygon with {vertices.Length} vertices, at least 3 are needed.");
            }

            // check if vertices are unique;
            for (int i = 0; i < vertices.Length; i++)
            {
                if (vertices.Count(v => v.Equals(vertices[i])) > 1) // if there are two equals vertices
                {
                    throw new RegularPolygonException("Cannot create polygon with duplicated vertices.");
                }
            }

            // check if sides lenghts are equal;
            // distance between first and last will be used as reference side length value for other vertices distances.
            double firstSideLength = vertices[0].GetDistanceFrom(vertices.Last());
            for (int i = 0; i < vertices.Length - 1; i++)
            {
                double currentSideLength = vertices[i].GetDistanceFrom(vertices[i + 1]);
                if (!Utility.CompareDouble(firstSideLength, currentSideLength))
                {
                    throw new RegularPolygonException("Cannot create regular polygon with unequal side lengths.");
                }
            }

            // check if vertices determine polygon that can be inscribed in a circle.;
            double avgX = vertices.Average(v => v.X);
            double avgY = vertices.Average(v => v.Y);
            Vertex circleCenter = new Vertex(avgX, avgY);
            double circleRadius = circleCenter.GetDistanceFrom(vertices[0]); // distance from first vertex as reference distance value
            for (int i = 1; i < vertices.Length; i++)
            {
                if (! Utility.CompareDouble(circleCenter.GetDistanceFrom(vertices[i]), circleRadius))
                {
                    throw new RegularPolygonException("Cannot create regular polygon that cannot be inscribed in circle.");
                }
            }

            return true;
        }
    }
}
