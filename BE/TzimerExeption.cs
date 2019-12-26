using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class TzimerException : Exception
    {
        public TzimerException(string message)
        : base(message) { }

        public TzimerException(string message, string layer)
        : base(message) { }
    }
}
