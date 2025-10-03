using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADS_LW2
{
    //наследование от класса Animal
    internal class Mammal : Animal
    {
        //дополнительные поля
        public bool Sterilize { get; set; }

        //конструкторы
        public Mammal() { }
        public Mammal(string name, string gender, int age, bool sterilize) : base(name, gender, age)
        {
            Sterilize = sterilize;
        }

        public override void getInformation()
        {
            Console.WriteLine($"Наименование: {name}");
            Console.WriteLine($"Пол: {gender}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"Стерилизовано: {Sterilize}");
            Console.WriteLine();
        }

        public override void weWillLeaveTheZoo()
        {
            Console.WriteLine($"Данные о {name} потеряны");
            name = "Unknown";
            gender = "Unknown";
            age = 0;
            Sterilize = false;
        }
}
}