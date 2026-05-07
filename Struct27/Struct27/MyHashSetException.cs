using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct27
{
    class OutOfMemoryHashSetException : OutOfMemoryException
    {
        public OutOfMemoryHashSetException() : base("Недостаточно памяти для хранения множества") { }
    }
}
