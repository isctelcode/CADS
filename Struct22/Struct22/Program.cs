using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Struct22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyHashMap<string> hashMap = new MyHashMap<string>();
            string[] strings = File.ReadAllLines("input.txt");
            for (int i = 0; i < strings.Length; i++)
            {
                MatchCollection tags = Regex.Matches(strings[i], @"</{0,1}[a-zA-z]+\w*>");
                foreach (Match match in tags)
                {
                    string tag = match.Value.ToLower();
                    if (tag[1] == '/')
                    {
                        tag = tag.Remove(1, 1);
                    }
                    if (!hashMap.ContainsKey(tag))
                    {
                        hashMap.Put(tag, "1");
                    }
                    else
                    {
                        int quantity = Convert.ToInt32(hashMap.Get(tag));
                        hashMap.Put(tag, (quantity + 1).ToString());
                    }
                }
            }
            hashMap.EntrySet();
        }
    }
}
