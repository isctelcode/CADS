using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct29
{
    interface MyList<T> : MyCollection<T>
    {
        void Add(int index, T element);
        void AddAll(int index, T[] elements);
        T Get(int index);
        int IndexOf(T element);
        int LastIndexOf(T element);
        void RemoveElementAt(int index);
        T[] SubList(int fromIndex, int toIndex);
        void Set(int index, T element);
    }
}
