using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularPolygonLibrary
{
    public class RegularPolygonException : Exception
    {
        public RegularPolygonException(string message) : base(message)
        {
        }
    }
}
