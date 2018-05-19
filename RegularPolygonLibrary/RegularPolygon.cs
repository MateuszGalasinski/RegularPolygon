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
    /// Represents regular polygon by array of vertices on plane.
    /// </summary>
    public class RegularPolygon
    {
        private Vertex[] vertices;

        /// Vertices order in "newVertices" matters, because every neighbouring pair of vertices in array,
        /// including also pair: first and last, determine one side of polygon.
        /// Thus these vertices must determine sides with equal lengths or an exception will be thrown.
        public RegularPolygon(Vertex[] newVertices)
        {
            if (newVertices == null)
            {
                throw new RegularPolygonException("Cannot create polygon without vertices.");
            }
            if(newVertices.Length <=2)
            {
                throw new RegularPolygonException($"Cannot create polygon with {newVertices.Length} vertices, at least 3 are needed.");
            }

            // distance between first and last will be used as reference side length value for other vetices distances.
            double firstSideLength = newVertices[0].GetDistanceFrom(newVertices.Last());
            for (int i = 0; i < newVertices.Length - 1; i++) 
            {
                double currentSideLength = newVertices[i].GetDistanceFrom(newVertices[i + 1]);
                if (! Utility.CompareDouble(firstSideLength, currentSideLength))
                {
                    throw new RegularPolygonException("Cannot create regular polygon with unequal side lengths.");
                }
            }
            //if achieved this point, parameters are correct
            vertices = newVertices;
            SideLength = firstSideLength;
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
    }
}
