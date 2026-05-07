using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyHashSet<string> fileSet = new MyHashSet<string>(File.ReadAllLines("input.txt"));
            string[] strings = fileSet.ToArray();
            string[][] words = new string[strings.Length][];
            for (int i = 0; i < strings.Length; ++i)
            {
                words[i] = strings[i].Split(' ').ToArray();
            }

            for (int i = 0; i < words.Length; ++i)
            {
                for (int j = 0; j < words[i].Length - 1; ++j)
                {
                    for (int k = 0; k < words[i].Length - j - 1; ++k)
                    {
                        if (words[i][k].Length > words[i][k + 1].Length || (words[i][k].Length == words[i][k + 1].Length && Comparer<string>.Default.Compare(words[i][k], words[i][k + 1]) > 0))
                        {
                            (words[i][k], words[i][k + 1]) = (words[i][k + 1], words[i][k]);
                        }
                    }
                }
            }

            List<string>[] wordsList = new List<string>[words.Length];
            for (int i = 0; i < words.Length; ++i)
            {
                wordsList[i] = new List<string>();
                for (int j = 0; j < words[i].Length; ++j)
                {
                    wordsList[i].Add(words[i][j]);
                }
            }

            for (int i = 0; i < wordsList.Length; ++i)
            {
                foreach (string word in wordsList[i])
                {
                    Console.Write(word + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
