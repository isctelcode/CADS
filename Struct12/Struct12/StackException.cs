using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct12
{
    class NullStackException : Exception
    {
        public NullStackException() : base("Динамический массив пуст") { }
    }

    class OutOfMemoryStackException : OutOfMemoryException
    {
        public OutOfMemoryStackException() : base("Недостаточно памяти для хранения динамического массива") { }
    }
}