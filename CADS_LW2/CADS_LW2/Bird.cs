using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADS_LW2
{
    //наследование от класса Animal
    internal class Bird : Animal
    {
        //дополнительные поля
        public string Plumage { get; set; }

        //конструкторы
        public Bird() { }
        public Bird(string name, string gender, int age, string plumage) : base(name, gender, age)
        {
            Plumage = plumage;
        }

        public override void getInformation()
        {
            Console.WriteLine($"Наименование: {name}");
            Console.WriteLine($"Пол: {gender}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"Тип оперения: {Plumage}");
            Console.WriteLine();
        }

        public override void weWillLeaveTheZoo()
        {
            Console.WriteLine($"Данные о {name} потеряны");
            name = "Unknown";
            gender = "Unknown";
            age = 0;
            Plumage = "Unknown";
        }
    }
}