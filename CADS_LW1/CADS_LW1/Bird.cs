using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADS_LW1
{
    //наследование от класса Animal
    internal class Bird : Animal
    {
        //конструкторы
        public Bird() { }
        public Bird(string name, string gender, int age) : base(name, gender, age)
        {
        }
    }
}