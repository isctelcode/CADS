using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct29
{
    public interface MyNavigableMap<T> : MySortedMap<T>
    {
        T[] LowerEntry(T key);
        T[] FloorEntry(T key);
        T[] HigherEntry(T key);
        T[] CeilingEntry(T key);
        T LowerKey(T key);
        T FloorKey(T key);
        T HigherKey(T key);
        T CeilingKey(T key);
        T[] PollFirstEntry();
        T[] PollLastEntry();
        T[] FirstEntry();
        T[] LastEntry();
    }
}
