using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADS_LW4
{
    internal interface IMarkData
    {
        Class[] Classes { get; set; }

        void GetMarks();
    }
}
