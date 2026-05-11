using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct30
{
    class IndexOutOfRangeStringException : Exception
    {
        public IndexOutOfRangeStringException() : base("Индекс вне границ строки") { }
    }
}
