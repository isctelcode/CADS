using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct29
{
    public interface MyDeque<T> : MyCollection<T>
    {
        void AddFirst(T element);
        void AddLast(T element);
        T GetFirst();
        T GetLast();
        bool OfferFirst(T element);
        bool OfferLast(T element);
        T Pop();
        void Push(T element);
        T PeekFirst();
        T PeekLast();
        T PollFirst();
        T PollLast();
        T RemoveFirst();
        T RemoveLast();
        bool RemoveFirstOccurrence(T element);
        bool RemoveLastOccurrence(T element);
    }
}
