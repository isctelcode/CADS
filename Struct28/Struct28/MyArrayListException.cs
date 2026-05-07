using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct28
{
    class NullArrayListException : Exception
    {
        public NullArrayListException() : base("Динамический массив пуст") { }
    }

    class OutOfMemoryArrayListException : OutOfMemoryException
    {
        public OutOfMemoryArrayListException() : base("Недостаточно памяти для хранения динамического массива") { }
    }

    class IndexOutOfRangeArrayListException : Exception
    {
        public IndexOutOfRangeArrayListException() : base("Индекс вне границ динамического массива") { }
    }

    class InvalidIntervalArgumentArrayListException : Exception
    {
        public InvalidIntervalArgumentArrayListException() : base("Индексы интервала заданы некорректно") { }
    }
}
