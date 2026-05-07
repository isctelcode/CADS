using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct29
{
    public interface MySortedMap<T> : MyMap<T>
    {
        T FirstKey();
        T LastKey();
        MyLinkedList<T[]> HeadMap(T end);
        MyLinkedList<T[]> SubMap(T start, T end);
        MyLinkedList<T[]> TailMap(T start);
    }
}
