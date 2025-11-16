using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADS_LW3
{
    internal class University
    {
        private string name;
        private string[] course;
        private int[] group;

        public string Name { get { return name; } set { name = value; } }
        public string[] Course { get { return course; } set { course = value; } }
        public int[] Group { get { return group; } set { group = value; } }

        public University()
        {
            name = "КубГУ";
            course = new string[] { "ФКТиПМ" };
            group = new int[] { 11, 12, 13, 14, 15, 16 };
        }

        public University(string name, string[] course)
        {
            this.name = name;
            this.course = course;
            group = new int[] { 11, 12, 13, 14, 15, 16 };
        }

        public University(string name, string[] course, int[] group)
        {
            this.name = name;
            this.course = course;
            this.group = group;
        }
    }
}
