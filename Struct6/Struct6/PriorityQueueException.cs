using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct6
{
    class NullPriorityQueueException : Exception
    {
        public NullPriorityQueueException() : base("Бинарная куча пуста") { }
    }

    class OutOfMemoryPriorityQueueException : OutOfMemoryException
    {
        public OutOfMemoryPriorityQueueException() : base("Недостаточно памяти для хранения бинарной кучи") { }
    }
}
