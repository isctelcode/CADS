using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct13
{
    class NullStackException : Exception
    {
        public NullStackException() : base("Стек пуст") { }
    }

    class OutOfMemoryStackException : OutOfMemoryException
    {
        public OutOfMemoryStackException() : base("Недостаточно памяти для хранения стека") { }
    }
}