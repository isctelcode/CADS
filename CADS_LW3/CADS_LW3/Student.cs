using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADS_LW3
{
    internal class Student
    {
        private string name, surname;
        private int age;
        private University university;
        private string faculty;
        private int group;
        private Class[] classes;

        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public int Age { get { return age; } set { age = value; } }
        public University University { get { return university; } set { university = value; } }
        public string Faculty { get { return faculty; } set  { faculty = value; } }
        public int Group { get { return group; } set { group = value; } }
        public Class[] Classes { get { return classes; } set { classes = value; } }

        public Student()
        {
            name = "Иван";
            surname = "Иванов";
            age = 18;
            university = new University();
            faculty = "ФКТиПМ";
            group = 11;
            classes = new Class[] { new Class() };
        }

        public Student(string name, string surname, int age, University university, string faculty, int group, Class[] classes)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.university = university;
            this.faculty = faculty;
            this.group = group;
            this.classes = classes;
        }
    }
}
