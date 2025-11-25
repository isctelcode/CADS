using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct11
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

    class InvalidIntervalArgumentException : Exception
    {
        public InvalidIntervalArgumentException() : base("Индексы интервала заданы некорректно") { }
    }
}
