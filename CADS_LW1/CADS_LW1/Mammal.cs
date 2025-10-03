using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADS_LW1
{
    //наследование от класса Animal
    internal class Mammal : Animal
    {
        //конструкторы
        public Mammal() { }
        public Mammal(string name, string gender, int age) : base(name, gender, age)
        {
        }
    }
}
