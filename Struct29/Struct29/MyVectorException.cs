using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct29
{
    class NullVectorException : Exception
    {
        public NullVectorException() : base("Вектор пуст") { }
    }

    class OutOfMemoryVectorException : OutOfMemoryException
    {
        public OutOfMemoryVectorException() : base("Недостаточно памяти для хранения вектора") { }
    }

    class IndexOutOfRangeVectorException : Exception
    {
        public IndexOutOfRangeVectorException() : base("Индекс вне границ вектора") { }
    }

    class InvalidIntervalArgumentVectorException : Exception
    {
        public InvalidIntervalArgumentVectorException() : base("Индексы интервала заданы некорректно") { }
    }
}
