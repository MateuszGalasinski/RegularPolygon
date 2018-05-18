using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegularPolygonLibrary;
using Utility = RegularPolygonLibrary.RegularPolygonUtility;

namespace RegularPolygonTests
{
    [TestClass]
    public class VertexTest
    {
        private Vertex firstVertex;

        [TestInitialize]
        public void Initialize()
        {
            firstVertex = new Vertex(2, 0);
        }

        [TestMethod]
        public void EqualityComparison_ShouldBeEqual_Test()
        {
            Vertex sameVertex = new Vertex(firstVertex.X, firstVertex.Y);
            Assert.IsTrue(firstVertex.Equals(sameVertex));
        }
        [TestMethod]
        public void EqualityComparison_ShouldBeUnequal_Test()
        {
            Vertex otherVertex = new Vertex(2, -4);
            Assert.IsFalse(firstVertex.Equals(otherVertex));
        }
        [TestMethod]
        public void EqualityComparison_Null_ShouldBeUnequal_Test()
        {
            Assert.IsFalse(firstVertex.Equals(null));
        }
        [TestMethod]
        public void Distance_Zero_ShouldBeCorrect_Test()
        {
            double distance = firstVertex.GetDistanceFrom(firstVertex);
            Assert.IsTrue(Utility.CompareDouble(distance, 0));
        }
        [TestMethod]
        public void Distance_ShouldReturnCorrect_Test()
        {
            Vertex secondVertex = new Vertex(0, -2);
            double distance = firstVertex.GetDistanceFrom(secondVertex);
            double correctDistance = 2.83;
            Assert.IsTrue(Utility.CompareDouble(distance, correctDistance));
        }
    }
}
