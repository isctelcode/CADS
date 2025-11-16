using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CADS_LW4
{
    internal interface IStudentData
    {
        string Name { get; set; }
        string Surname { get; set; }
        int Age { get; set; }
        University University { get; set; }
        string Faculty { get; set; }
        int Group { get; set; }

        void GetInfo();
    }
}
