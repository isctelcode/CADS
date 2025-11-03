using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct3
{
    public class Data
    {
        public int Numbers { get; set; }
        public double DoubleNumbers { get; set; }
        public char Letters { get; set; }
        public string Words { get; set; }
        public DateTime Datetime { get; set; }

        public Data()
        {
            Numbers = 0;
            DoubleNumbers = 0.0;
            Letters = ' ';
            Words = string.Empty;
            Datetime = DateTime.MinValue;
        }

        public Data(int numbers, double doubleNumbers, char letters, string words, DateTime datetime)
        {
            Numbers = numbers;
            DoubleNumbers = doubleNumbers;
            Letters = letters;
            Words = words;
            Datetime = datetime;
        }

        public string Output()
        {
            return $"{Convert.ToString(Numbers)} {Convert.ToString(DoubleNumbers)} {Convert.ToString(Letters)} {Words} {Convert.ToString(Datetime)}";
        }
    }
}
