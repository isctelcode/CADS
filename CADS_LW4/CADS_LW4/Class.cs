using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADS_LW4
{
    internal class Class
    {
        private string name;
        private int mark;

        public string Name { get { return name; } set { name = value; } }
        public int Mark { get { return mark; } set { if (2 <= value && value <= 5) mark = value; } }

        public Class()
        {
            name = "Математический анализ";
            mark = 5;
        }

        public Class(string name, int mark)
        {
            this.Name = name;
            this.Mark = mark;
        }
    }
}
