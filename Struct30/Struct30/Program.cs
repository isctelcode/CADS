using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct30
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyString str = new MyString(new char[] {'a', 'b', 'a', 'c', 'a', 'b', 'a'});
            MyString substr = new MyString(new char[] { 'c', 'a', 'b' });
            Console.WriteLine(str.IndexOf(substr));
            MyString[] split = str.Split('b');
            str.ToUpperCase();
            MyString intStr = str.ValueOf(9327);
            MyString boolStr = str.ValueOf(true);
            MyString doubleStr = str.ValueOf(-8.923);
        }
    }
}
