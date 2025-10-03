using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADS_LW2
{
    //наследование от класса Mammal
    internal class Artiodactyl : Mammal
    {
        //дополнительные поля
        public bool Horseshoe { get; set; }

        //конструкторы
        public Artiodactyl() { }
        public Artiodactyl(string name, string gender, int age, bool sterilize, bool horseshoe) : base(name, gender, age, sterilize)
        {
            Horseshoe = horseshoe;
        }

        public override void getInformation()
        {
            Console.WriteLine($"Наименование: {name}");
            Console.WriteLine($"Пол: {gender}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"Подковано: {Horseshoe}");
            Console.WriteLine();
        }

        public override void weWillLeaveTheZoo()
        {
            Console.WriteLine($"Данные о {name} потеряны");
            name = "Unknown";
            gender = "Unknown";
            age = 0;
            Horseshoe = false;
        }
    }
}