using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularPolygonLibrary
{
    public class RegularPolygonFactoryException : Exception
    {
        public RegularPolygonFactoryException(string message) : base(message)
        {
        }
    }
}
