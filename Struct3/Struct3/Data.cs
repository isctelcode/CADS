using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct3
{
    class Data
    {
        public int Numbers { get; set; }
        public double DoubleNumbers { get; set; }
        public string Letters { get; set; }
        public DateTime Datetime { get; set; }

        public Data()
        {
            Numbers = 0;
            DoubleNumbers = 0.0;
            Letters = string.Empty;
            Datetime = DateTime.MinValue;
        }

        public Data(int numbers, double doubleNumbers, string letters, DateTime datetime)
        {
            Numbers = numbers;
            DoubleNumbers = doubleNumbers;
            Letters = letters;
            Datetime = datetime;
        }
    }
}
