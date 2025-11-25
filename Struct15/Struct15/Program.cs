using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Struct15
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = File.ReadAllLines("input.txt");
            Console.WriteLine(String.Join(" ", file));
            Console.WriteLine();
            ArrayDeque<string> intStrings = new ArrayDeque<string>();
            intStrings.Add(file[0]);
            int maxIntCount = 0;
            for (int i = 0; i < file[0].Length; ++i)
            {
                if (Char.IsDigit(file[0][i]))
                {
                    ++maxIntCount;
                }
            }
            for (int i = 1; i < file.Length; ++i)
            {
                int intCount = 0;
                for (int j = 0; j < file[i].Length; ++j)
                {
                    if (Char.IsDigit(file[0][i]))
                    {
                        ++intCount;
                    }
                }
                if (intCount > maxIntCount)
                {
                    intStrings.AddLast(file[i]);
                }
                else
                {
                    intStrings.AddFirst(file[i]);
                    maxIntCount = intCount;
                }
            }

            string[] dequeArray = intStrings.ToArray();
            Console.WriteLine(String.Join(" ", dequeArray));
            Console.WriteLine();
            using (StreamWriter sorted = new StreamWriter("sorted.txt", false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < intStrings.Size(); ++i)
                {
                    sorted.WriteLine(dequeArray[i]);
                }
            }
            Console.Write("Введите предельное количество пробелов в строке >> ");
            int n = Convert.ToInt32(Console.ReadLine());
            ArrayDeque<string> wrongStringsDeque = new ArrayDeque<string>();
            for (int i = 0; i < intStrings.Size(); ++i)
            {
                int spaceCount = 0;
                for (int j = 0; j < dequeArray.Length; ++j)
                {
                    if (dequeArray[i][j] == ' ')
                    {
                        ++spaceCount;
                    }
                }
                if (spaceCount > n)
                {
                    wrongStringsDeque.Add(dequeArray[i]);
                }
            }
            string[] wrongStringsArray = wrongStringsDeque.ToArray();
            intStrings.RemoveAll(wrongStringsArray);
            string[] dequeChangedArray = intStrings.ToArray();
            Console.WriteLine(String.Join(" ", dequeChangedArray));
        }
    }
}
