using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct29
{
    public interface MyCollection<T>
    {
        void Add(T element);
        void AddAll(T[] elements);
        void Clear();
        bool Contains(T element);
        bool ContainsAll(T[] elements);
        bool IsEmpty();
        void Remove(T element);
        void RemoveAll(T[] elements);
        void RetainAll(T[] elements);
        int Size();
        T[] ToArray();
    }
}
