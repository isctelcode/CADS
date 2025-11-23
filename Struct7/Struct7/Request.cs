using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct7
{
    class Request : IComparable<Request>
    {
        private int iteration;
        private int id;
        private int priority;

        public int Iteration { get { return iteration; } }
        public int Id { get { return id; } }
        public int Priority { get { return priority; } }

        public Request(int iteration, int id, int priority)
        {
            this.iteration = iteration;
            this.id = id;
            this.priority = priority;
        }

        public int CompareTo(Request other)
        {
            if (other.priority > this.priority || (other.priority == this.priority && other.id > this.id)) return 1;
            else if (other.priority == this.priority) return 0;
            else return -1;
        }
    }
}