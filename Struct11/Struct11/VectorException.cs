using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct11
{
    class NullVectorException : Exception
    {
        public NullVectorException() : base("Динамический массив пуст") { }
    }

    class OutOfMemoryVectorException : OutOfMemoryException
    {
        public OutOfMemoryVectorException() : base("Недостаточно памяти для хранения динамического массива") { }
    }

    class IndexOutOfRangeVectorException : Exception
    {
        public IndexOutOfRangeVectorException() : base("Индекс вне границ динамического массива") { }
    }

    class InvalidIntervalArgumentException : Exception
    {
        public InvalidIntervalArgumentException() : base("Индексы интервала заданы некорректно") { }
    }
}
