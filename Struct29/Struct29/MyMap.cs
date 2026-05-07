using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct29
{
    public interface MyMap<T>
    {
        bool ContainsKey(T key);
        bool ContainsValue(T value);
        MyLinkedList<T[]> EntrySet();
        MyLinkedList<T> KeySet();
        MyLinkedList<T> Values();
        T Get(T key);
        bool IsEmpty();
        void Put(T key, T value);
        void PutAll(MyMap<T> map);
        void Remove(T key);
        int Size();
    }
}
