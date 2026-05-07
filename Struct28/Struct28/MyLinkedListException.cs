using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct28
{
    class NullLinkedListException : Exception
    {
        public NullLinkedListException() : base("Двунаправленный список пуст") { }
    }

    class OutOfMemoryLinkedListException : OutOfMemoryException
    {
        public OutOfMemoryLinkedListException() : base("Недостаточно памяти для хранения двунаправленного списка") { }
    }

    class IndexOutOfRangeLinkedListException : Exception
    {
        public IndexOutOfRangeLinkedListException() : base("Индекс вне границ двунаправленного списка") { }
    }

    class InvalidIntervalArgumentLinkedListException : Exception
    {
        public InvalidIntervalArgumentLinkedListException() : base("Индексы интервала заданы некорректно") { }
    }
}
