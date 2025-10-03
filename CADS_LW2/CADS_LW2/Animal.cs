using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADS_LW2
{
    abstract internal class Animal
    {
        //поле данных
        protected string name = "Unknown";
        protected string gender = "Unknown";
        protected int age = 0;

        //геттеры и сеттеры для поля данных с проверкой на корректность
        public string Name { get; set; }
        public string Gender
        {
            get
            { return gender; }
            set
            {
                while (true)
                {
                    if (value != "Male" || value != "Female") { Console.Write("Wrong gender, try again: "); }
                    else
                    {
                        gender = value;
                        break;
                    }
                }
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                while (true)
                {
                    if (value < 0) { Console.Write("Wrong gender, try again: "); }
                    else
                    {
                        age = value;
                        break;
                    }
                }
            }
        }

        //конструкторы
        public Animal() { }
        public Animal(string name, string gender, int age)
        {
            this.name = name;
            this.gender = gender;
            this.age = age;
        }

        //метод для вывода данных объекта   
        public abstract void getInformation();

        public abstract void weWillLeaveTheZoo();
    }
}