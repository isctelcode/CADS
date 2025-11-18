using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct5
{
    class NullHeapException : Exception
    {
        public NullHeapException() : base("Бинарная куча пуста") { }
    }

    class OutOfMemoryHeapException : OutOfMemoryException
    {
        public OutOfMemoryHeapException() : base("Недостаточно памяти для хранения бинарной кучи") { }
    }

    class IndexOutOfRangeHeapException : Exception
    {
        public IndexOutOfRangeHeapException() : base("Индекс вне границ бинарной кучи") { }
    }
}
