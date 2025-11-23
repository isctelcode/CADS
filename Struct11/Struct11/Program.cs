using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = File.ReadAllLines("input.txt");
            Vector<string> strings = new Vector<string>(file);
            Vector<string> addresses = new Vector<string>();
            Vector<string> correctAddresses = new Vector<string>();
            string piece = "";

            for (int i = 0; i < strings.Size(); ++i)
            {
                piece += strings.Get(i) + " ";
            }

            addresses.AddAll(piece.Split(' '));
            using (StreamWriter output = new StreamWriter("output.txt", false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < addresses.Size(); ++i)
                {
                    string[] strAddressComp = addresses.Get(i).Split('.');
                    if (strAddressComp.Length == 4)
                    {
                        int[] intAddressComp = new int[4];
                        bool flag = true;
                        for (int j = 0; j < 4; ++j)
                        {
                            if (!int.TryParse(strAddressComp[j], out intAddressComp[j]))
                            {
                                flag = false;
                                break;
                            }
                            if (intAddressComp[j] < 0 || intAddressComp[j] > 255)
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            correctAddresses.Add(addresses.Get(i));
                            output.WriteLine(addresses.Get(i));
                        }
                    }
                }
            }
        }
    }
}
