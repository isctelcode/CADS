using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct29
{
    class OutOfMemoryHashMapException : OutOfMemoryException
    {
        public OutOfMemoryHashMapException() : base("Недостаточно памяти для хранения отображения") { }
    }
}
