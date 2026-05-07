using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct28
{
    namespace Collections1
    {
        public interface MyIterator<T>
        {
            bool HasNext();
            T Next();
            void Reset();
        }
    }
    
    namespace Collections2
    {
        public interface MyIterator<T>
        {
            bool HasNext();
            T Next();
            bool HasPrevious();
            T Previous();
            int NextIndex();
            int PreviousIndex();
            void Reset();
        }
    }
}
