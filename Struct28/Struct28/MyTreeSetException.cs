using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct28
{
    class OutOfMemoryTreeSetException : OutOfMemoryException
    {
        public OutOfMemoryTreeSetException() : base("Недостаточно памяти для хранения множества") { }
    }
}
