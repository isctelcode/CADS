using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADS_LW1
{
    //наследование от класса Mammal
    internal class Artiodactyl : Mammal
    {
        //конструкторы
        public Artiodactyl() { }
        public Artiodactyl(string name, string gender, int age) : base(name, gender, age)
        {
        }
    }
}
