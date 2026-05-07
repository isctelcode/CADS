using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct29
{
    public interface MyQueue<T> : MyCollection<T>
    {
        bool Offer(T element);
        T Peek();
        T Poll();
    }
}
