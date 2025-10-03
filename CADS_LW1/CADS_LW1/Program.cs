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

namespace CADS_LW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //инициализация массивов объектов классов Animal, Bird и Artiodactyl
            Animal[] zoo = { 
                new Animal("tortoise", "male", 143), 
                new Animal(), 
                new Animal("python", "female", 23), 
                new Animal("tarantula", "male", 17), 
                new Animal("jackal", "male", 20) 
            };
            Bird[] poultry = { 
                new Bird("parrot", "female", 31), 
                new Bird("phoenix", "male", 4236), 
                new Bird("ostrich", "female", 13) 
            };
            Artiodactyl[] stable = { 
                new Artiodactyl("deer", "male", 32), 
                new Artiodactyl("deer", "female", 27), 
                new Artiodactyl("horse", "male", 21), 
                new Artiodactyl("mule", "male", 9) 
            };

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
