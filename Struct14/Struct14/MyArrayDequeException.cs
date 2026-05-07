using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct14
{
    class NullArrayDequeException : Exception
    {
        public NullArrayDequeException() : base("Динамический массив пуст") { }
    }

    class OutOfMemoryArrayDequeException : OutOfMemoryException
    {
        public OutOfMemoryArrayDequeException() : base("Недостаточно памяти для хранения динамического массива") { }
    }

    class IndexOutOfRangeArrayDequeException : Exception
    {
        public IndexOutOfRangeArrayDequeException() : base("Индекс вне границ динамического массива") { }
    }

    class InvalidIntervalArgumentException : Exception
    {
        public InvalidIntervalArgumentException() : base("Индексы интервала заданы некорректно") { }
    }
}
