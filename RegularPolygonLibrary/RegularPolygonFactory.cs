using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularPolygonLibrary
{
    /// <summary>
    /// Factory that can create RegularPolygon objects, given number of vertices, side length and starting point.
    /// </summary>
    public class RegularPolygonFactory
    {
        /// <summary>
        /// Creates polygon with attrbiutes specified in arguments.
        /// Polygon is created using following algorithm:
        ///     Starting from angle = 0 and first vertex given:
        ///      1. Save current vertex in vertices array.
        ///      2. Calculate another vertex coordinates by moving distance equal to side length in direction specified by current angle.
        ///      3. Update current angle by adding "angle step" = 2 * PI divided by numberOfVertices. (in other words, rotate counter-clockwise by "angle step")
        ///      4. Repeat steps 1-3 until all vertexes were generated.
        /// </summary>
        /// <exception cref="RegularPolygonFactoryException">
        /// Thrown when input parameters are incorrect:
        ///  numberOfVertices - has to be greater than 2.
        ///  sideLength - has to be greater than 0
        /// </exception>
        /// <param name="numberOfVertices"> How many vertices should polygon has.</param>
        /// <param name="sideLength"> How long should one side of polygon be.</param>
        /// <param name="startingVertex">Starting vertex for polygon generation.</param>
        /// <returns>Newly created polygon.</returns>
        public RegularPolygon CreatePolygon(int numberOfVertices, double sideLength, Vertex startingVertex)
        {
            CheckArgumentCorrecntess();

            //create vertices for polygon
            Vertex[] vertices = new Vertex[numberOfVertices];
            vertices[0] = startingVertex;
            double x = startingVertex.X, y = startingVertex.Y;
            double currentAngle = 0;
            for (int i = 1; i < numberOfVertices; i++)
            {
                x += Math.Cos(currentAngle) * sideLength;
                y += Math.Sin(currentAngle) * sideLength;
                vertices[i] = new Vertex(x,y);
                currentAngle += 2.0 * Math.PI / numberOfVertices;
            }
            //create polygon with generated vertices
            RegularPolygon resultPolygon = new RegularPolygon(vertices);
            return resultPolygon;

            //local methods
            void CheckArgumentCorrecntess()
            {
                if (numberOfVertices <= 2)
                {
                    throw new RegularPolygonFactoryException($"Cannot create polygon with {numberOfVertices} vertices, at least 3 are needed.");
                }
                if (sideLength <= 0)
                {
                    throw new RegularPolygonFactoryException($"Given side length = {sideLength} is incorrect. It has to be greater than 0.");
                }
            }
        }
    }
}
