using CADS_LW2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//иерархия классов
//животное:
//  птица
//  млекопитающее:
//      парнокопытное

namespace CADS_LW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //инициализация массивов объектов классов Mammal, Bird и Artiodactyl
            Mammal[] zoo = {
                new Mammal("killer whale", "male", 43, false),
                new Mammal(),
                new Mammal("tiger", "female", 23, true),
                new Mammal("grizzly", "male", 17, false),
                new Mammal("jackal", "male", 20, false)
            };
            Bird[] poultry = {
                new Bird("parrot", "female", 31, "contour"),
                new Bird("phoenix", "male", 4236, "crystal"),
                new Bird("ostrich", "female", 13, "downy")
            };
            Artiodactyl[] stable = {
                new Artiodactyl("deer", "male", 32, true, false),
                new Artiodactyl("deer", "female", 27, false, true),
                new Artiodactyl("horse", "male", 21, false, true),
                new Artiodactyl("mule", "male", 9, false, true)
            };

            //получение информации о животных
            for (int i = 0; i < zoo.Length; i++)
                zoo[i].getInformation();
            for (int i = 0; i < poultry.Length; i++)
                poultry[i].getInformation();
            for (int i = 0; i < stable.Length; i++)
                stable[i].getInformation();

            //побег животных
            for (int i = 0; i < zoo.Length; i++)
                zoo[i].weWillLeaveTheZoo();
            for (int i = 0; i < poultry.Length; i++)
                poultry[i].weWillLeaveTheZoo();
            for (int i = 0; i < stable.Length; i++)
                stable[i].weWillLeaveTheZoo();
        }
    }
}