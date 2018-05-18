using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularPolygonLibrary
{
    public class RegularPolygonFactory
    {
        public RegularPolygon CreatePolygon(int numberOfVertices, double sideLength, Vertex startingVertex)
        {
            if(numberOfVertices <= 2)
            {
                throw new RegularPolygonFactoryException($"Cannot create polygon with {numberOfVertices} vertices, at least 3 are needed.");
            }
            if(sideLength <= 0)
            {
                throw new RegularPolygonFactoryException($"Given side length = {sideLength} is incorrect. It has to be greater than 0.");
            }

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
            RegularPolygon resultPolygon = new RegularPolygon(vertices);
            return resultPolygon;
        }
    }
}
