using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegularPolygonLibrary;

namespace RegularPolygonTests
{
    [TestClass]
    public class RegularPolygonFactoryTest
    {
        private RegularPolygonFactory factory;

        [TestInitialize]
        public void Initialize()
        {
            factory = new RegularPolygonFactory();
        }

        [TestMethod]
        public void CreateTriangle_Starting_In_0_0()
        {
            int numberOfVertices = 3;
            double sideLength = 2;
            RegularPolygon triangle = factory.CreatePolygon(numberOfVertices, sideLength, new Vertex(0, 0));
            Assert.AreEqual(numberOfVertices, triangle.Vertices.Length);
            Assert.AreEqual(new Vertex(0, 0), triangle.Vertices[0]);
            Assert.AreEqual(new Vertex(2, 0), triangle.Vertices[1]);
            Assert.AreEqual(new Vertex(1, 1.73), triangle.Vertices[2]);
        }

        [TestMethod]
        public void CreatePentagon_Starting_In_0_0()
        {
            int numberOfVertices = 5;
            double sideLength = 1;
            RegularPolygon pentagon = factory.CreatePolygon(numberOfVertices, sideLength, new Vertex(0, 0));
            Assert.AreEqual(numberOfVertices, pentagon.Vertices.Length);
            Assert.AreEqual(new Vertex(0, 0), pentagon.Vertices[0]);
            Assert.AreEqual(new Vertex(1, 0), pentagon.Vertices[1]);
            Assert.AreEqual(new Vertex(1.31, 0.95), pentagon.Vertices[2]);
            Assert.AreEqual(new Vertex(0.5, 1.54), pentagon.Vertices[3]);
            Assert.AreEqual(new Vertex(-0.31, 0.96), pentagon.Vertices[4]);
        }
        [TestMethod]
        [ExpectedException(typeof(RegularPolygonFactoryException))]
        public void CreatePolygon_InvalidSideLength_ShouldThrow()
        {
            int numberOfVertices = 3;
            double sideLength = 0;
            RegularPolygon polygon = factory.CreatePolygon(numberOfVertices, sideLength, new Vertex(0, 0));
        }
        [TestMethod]
        [ExpectedException(typeof(RegularPolygonFactoryException))]
        public void CreatePolygon_InvalidVerticesNumber_ShouldThrow()
        {
            int numberOfVertices = 2;
            double sideLength = 1;
            RegularPolygon polygon = factory.CreatePolygon(numberOfVertices, sideLength, new Vertex(0, 0));
        }
    }
}
