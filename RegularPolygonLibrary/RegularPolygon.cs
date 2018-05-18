using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility = RegularPolygonLibrary.RegularPolygonUtility;

namespace RegularPolygonLibrary
{
    public class RegularPolygon
    {
        private Vertex[] vertices;

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

            // distance between first and last will be used as reference value for other points distances
            double newSideLength = newVertices[0].GetDistanceFrom(newVertices.Last());
            for (int i = 0; i < newVertices.Length - 1; i++) 
            {
                if(! Utility.CompareDouble(newSideLength, newVertices[i].GetDistanceFrom(newVertices[i+1])))
                {
                    throw new RegularPolygonException("Cannot create regular polygon with unequal side lengths.");
                }
            }
            //if achieved this point, parameters are correct
            vertices = newVertices;
            SideLength = newSideLength;
        }

        /// <summary>
        /// Always returns a copy of vertices array.
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
        public int NumberOfVertices
        {
            get
            {
                return vertices.Length;
            }
        }
        public double SideLength { get; private set; }

        public double CalculateArea()
        {
            double area = 1.0 / 4 * vertices.Length;
            area *= Math.Pow(SideLength, 2);
            area *= 1.0 / Math.Tan(Math.PI / vertices.Length);
            return area;
        }
    }
}
