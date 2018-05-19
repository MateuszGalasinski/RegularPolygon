using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegularPolygonLibrary;
using Utility = RegularPolygonLibrary.RegularPolygonUtility;

namespace RegularPolygonTests
{
    [TestClass]
    public class RegularPolygonTest
    {
        [TestMethod]
        public void CreatePolygon_CorrectVertices_CheckArea()
        {
            Vertex[] vertices = new Vertex[]
            {
                new Vertex(0, 0),
                new Vertex(3, 0),
                new Vertex(3.927, 2.853),
                new Vertex(1.5, 4.617),
                new Vertex(-0.927, 2.853),
            };
            RegularPolygon polygon = new RegularPolygon(vertices);
            double correctArea = 15.484;
            Assert.IsTrue(Utility.CompareDouble(correctArea, polygon.CalculateArea()));
        }

        [TestMethod]
        public void CreatePolygon_CorrectVertices_CheckSideLength()
        {
            Vertex[] vertices = new Vertex[]
            {
                new Vertex(0, 0),
                new Vertex(3, 0),
                new Vertex(3.927, 2.853),
                new Vertex(1.5, 4.617),
                new Vertex(-0.927, 2.853),
            };
            RegularPolygon polygon = new RegularPolygon(vertices);
            double correctSideLength = 3;
            Assert.IsTrue(Utility.CompareDouble(correctSideLength, polygon.SideLength));
        }

        [TestMethod]
        [ExpectedException(typeof(RegularPolygonException))]
        public void CreatePolygon_IncorrectVertices_ShouldThrow()
        {
            Vertex[] vertices = new Vertex[]
            {
                new Vertex(0, 0),
                new Vertex(0, 0),
                new Vertex(3.927, 2.853),
                new Vertex(1.5, 4.617),
                new Vertex(-0.927, 2.853),
            };
            RegularPolygon polygon = new RegularPolygon(vertices);
        }

        [TestMethod]
        [ExpectedException(typeof(RegularPolygonException))]
        public void CreatePolygon_NotEnoughVertices_ShouldThrow()
        {
            Vertex[] vertices = new Vertex[]
            {
                new Vertex(0, 0),
                new Vertex(1, 0),
            };
            RegularPolygon polygon = new RegularPolygon(vertices);
        }

        [TestMethod]
        [ExpectedException(typeof(RegularPolygonException))]
        public void CreatePolygon_NullVertices_ShouldThrow()
        {
            RegularPolygon polygon = new RegularPolygon(null);
        }
    }
}
