using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility = RegularPolygonLibrary.RegularPolygonUtility;

namespace RegularPolygonLibrary
{
    public struct Vertex
    {
        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public double GetDistanceFrom(Vertex secondVertex)
        {
            double distance = Math.Pow((X - secondVertex.X), 2);
            distance += Math.Pow((Y - secondVertex.Y), 2);
            distance = Math.Sqrt(distance);
            return distance;
        }

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
