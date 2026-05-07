using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Struct27
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyHashSet<string> uniqueWords = new MyHashSet<string>();
            string[] strings = File.ReadAllLines("input.txt");
            string[][] words = new string[strings.Length][];
            for (int i = 0; i < strings.Length; ++i)
            {
                words[i] = strings[i].Split(' ').ToArray();
            }

            for (int i = 0; i < words.Length; ++i)
            {
                for (int j = 0; j < words[i].Length; ++j)
                {
                    if (!Regex.IsMatch(words[i][j], @"\d"))
                    {
                        uniqueWords.Add(words[i][j].ToLower());
                    }
                }
            }

            Console.WriteLine(String.Join(" ", uniqueWords.ToArray()));
        }
    }
}
