using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Struct23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = File.ReadAllLines("input.txt");
            string fileString = "";
            for (int i = 0; i < strings.Length; ++i)
            {
                fileString = fileString + strings[i];
            }
            HashMap<string> vars = new HashMap<string>();
            MatchCollection declars = Regex.Matches(fileString, @"\w+\s\w+[\s]=[\s][0-9,]+;");
            using (StreamWriter input = new StreamWriter("output.txt", false, System.Text.Encoding.Default))
            {
                foreach (Match match in declars)
                {
                    string var = match.Value;
                    if (Regex.IsMatch(var, @"int\s[a-zA-Z]+\w*[\s]=[\s][1-9]+[0-9]*;")
                        || Regex.IsMatch(var, @"float\s[a-zA-Z]+\w*[\s]=[\s][1-9]+[0-9]*[,][0-9]*[1-9]+;")
                        || Regex.IsMatch(var, @"double\s[a-zA-Z]+\w*[\s]=[\s][1-9]+[0-9]*[,][0-9]*[1-9]+;"))
                    {
                        string[] comps = var.Split('=');
                        string[] typeName = comps[0].Split(' ');
                        if (vars.ContainsKey(typeName[1]))
                        {
                            Console.WriteLine("Переопределение переменной " + typeName[1]);
                        }
                        vars.Put(typeName[1], typeName[0] + " " + comps[1].Replace(" ", "").Replace(";", ""));
                        input.WriteLine(typeName[0] + " => " + typeName[1] + "(" + comps[1].Replace(" ", "").Replace(";", "") + ")");
                    }
                    else
                    {
                        Console.WriteLine("Некорректное определение: " + var);
                    }
                }
                Console.WriteLine();
                vars.EntrySet();
            }
        }
    }
}
