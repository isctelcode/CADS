using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct29
{
    public interface MyNavigableSet<T> : MySortedSet<T>
    {
        T Ceiling(T value);
        T Floor(T value);
        T Higher(T value);
        T Lower(T value);
        T PollFirst();
        T PollLast();
    }
}
