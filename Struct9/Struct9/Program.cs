using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct9
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = File.ReadAllLines("data.txt");
            ArrayList<string> tags = new ArrayList<string>();

            foreach (string line in file)
            {
                string[] splitLine = line.Split('<');
                for (int i = 1; i < splitLine.Length; ++i)
                {
                    string tag = "<";
                    for (int j = 0; j < splitLine[i].Length; ++j)
                    {
                        if (tag == "<" && splitLine[i][j] == '/')
                        {
                            tag = tag + "/";
                        }
                        else if (splitLine[i][j] == '>')
                        {
                            tag = tag + ">";
                            tags.Add(tag.ToLower());
                            break;
                        }
                        else if (Char.IsLetter(splitLine[i][j]) || Char.IsDigit(splitLine[i][j]))
                        {
                            tag = tag + splitLine[i][j];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(String.Join(" ", tags.ToArray()));

            for (int i = 0; i < tags.Size() - 1; ++i)
            {
                for (int j = i + 1; j < tags.Size(); ++j)
                {
                    if (tags.Get(i) == (tags.Get(j).Replace("/", "")))
                    {
                        tags.RemoveReturn(j);
                        tags.RemoveReturn(i);
                    }
                }
            }

            Console.WriteLine(String.Join(" ", tags.ToArray()));
        }
    }
}
