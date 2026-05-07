using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct29
{
    public interface MySet<T> : MyCollection<T>
    {
        T First();
        T Last();
        MyLinkedList<T> SubSet(T fromElement, T toElement);
        MyLinkedList<T> HeadSet(T toElement);
        MyLinkedList<T> TailSet(T fromElement);
    }
}
