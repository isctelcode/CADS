using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct16
{
    class NullLinkedListException : Exception
    {
        public NullLinkedListException() : base("Двунаправленный список") { }
    }

    class OutOfMemoryLinkedListException : OutOfMemoryException
    {
        public OutOfMemoryLinkedListException() : base("Недостаточно памяти для хранения двунаправленного списка") { }
    }

    class IndexOutOfRangeLinkedListException : Exception
    {
        public IndexOutOfRangeLinkedListException() : base("Индекс вне границ двунаправленного списка") { }
    }

    class InvalidIntervalArgumentException : Exception
    {
        public InvalidIntervalArgumentException() : base("Индексы интервала заданы некорректно") { }
    }
}
