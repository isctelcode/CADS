using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct29
{
    class NullArrayDequeException : Exception
    {
        public NullArrayDequeException() : base("Дек пуст") { }
    }

    class OutOfMemoryArrayDequeException : OutOfMemoryException
    {
        public OutOfMemoryArrayDequeException() : base("Недостаточно памяти для хранения дека") { }
    }

    class IndexOutOfRangeArrayDequeException : Exception
    {
        public IndexOutOfRangeArrayDequeException() : base("Индекс вне границ дека") { }
    }

    class InvalidIntervalArgumentArrayDequeException : Exception
    {
        public InvalidIntervalArgumentArrayDequeException() : base("Индексы интервала заданы некорректно") { }
    }
}
