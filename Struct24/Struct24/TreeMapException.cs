using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct24
{
    class OutOfMemoryTreeMapException : OutOfMemoryException
    {
        public OutOfMemoryTreeMapException() : base("Недостаточно памяти для хранения отображения") { }
    }
}
