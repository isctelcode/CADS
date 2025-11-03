using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Struct3
{
    internal class ArrayGenerate
    {
        public string RandomWord(int length)
        {
            string word = string.Empty, alphabet = "abcdefghijklmnopqrstuvwxyz";
            Random rand = new Random();
            for (int i = 0; i < length; i++)
                word = word + alphabet[rand.Next(0, 26)];
            return word;
        }

        public int[] RandomArray(int size)
        {
            int[] array = new int[size];
            Random rand = new Random();

            for (int i = 0; i < size; ++i)
                array[i] = rand.Next(0, 1000);

            return array;
        }

        public Data[] RandomDataArray(int size)
        {
            Data[] array = new Data[size];
            Random rand = new Random();

            for (int i = 0; i < size; ++i)
            {
                int numbers = rand.Next(0, 1000);
                double doubleNumbers = rand.NextDouble() * 1000;
                char letters = Convert.ToChar(RandomWord(1));
                string words = RandomWord(5);
                DateTime datetime = new DateTime(rand.Next(1900, 2025), rand.Next(1, 12), rand.Next(1, 28));
                array[i] = new Data(numbers, doubleNumbers, letters, words, datetime);
            }

            return array;
        }

        public int[] PartiallySortedArray(int size)
        {
            int[] array = new int[size];
            Random rand = new Random();
            int subarraySize = rand.Next(1, size);
            int subarrayCount = size / subarraySize, subarrayTail = size - subarraySize * subarrayCount;
            for (int t = 0; t < subarrayCount; ++t)
            {
                array[subarraySize * t] = 1;
                for (int i = subarraySize * t + 1; i < subarraySize * (t + 1); ++i)
                    array[i] = array[i - 1] + 1;
            }
            array[subarraySize * subarrayCount] = 1;
            for (int i = subarraySize * subarrayCount + 1; i < size; ++i)
                array[i] = array[i - 1] + 1;
            return array;
        }

        public Data[] PartiallySortedDataArray(int size)
        {
            Data[] array = new Data[size];
            Random rand = new Random();
            int subarraySize = rand.Next(1, size);
            int subarrayCount = size / subarraySize, subarrayTail = size - subarraySize * subarrayCount;
            int[] row = new int[size];
            for (int t = 0; t < subarrayCount; ++t)
            {
                row[subarraySize * t] = 1;
                for (int i = subarraySize * t + 1; i < subarraySize * (t + 1); ++i)
                    row[i] = row[i - 1] + 1;
            }
            row[subarraySize * subarrayCount] = 1;
            for (int i = subarraySize * subarrayCount + 1; i < size; ++i)
                row[i] = row[i - 1] + 1;

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int startLetter = 1, startDate = 1;

            for (int i = 0; i < size; ++i)
            {
                int numbers = row[i];
                if (numbers == 1)
                {
                    startLetter = 1; startDate = 1;
                }
                double doubleNumbers = rand.NextDouble() * row[i];
                char letters = Convert.ToChar(alphabet[startLetter]);
                string words = string.Empty;
                for (int j = 0; j < 5; ++j)
                    words = words + Convert.ToString(alphabet[startLetter]);
                if (startLetter < 25)
                    ++startLetter;
                DateTime datetime = new DateTime(2025, 1, startDate);
                if (startDate < 28)
                    ++startDate;
                array[i] = new Data(numbers, doubleNumbers, letters, words, datetime);
            }
            return array;
        }

        public int[] SortedArray(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < size; ++i)
                array[i] = i + 1;

            return array;
        }

        public Data[] SortedDataArray(int size)
        {
            Data[] array = new Data[size];
            Random rand = new Random();

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int startLetter = 1, startDate = 1;

            for (int i = 0; i < size; ++i)
            {
                int numbers = i + 1;
                double doubleNumbers = rand.NextDouble() * (i + 1);
                char letters = Convert.ToChar(alphabet[startLetter]);
                string words = string.Empty;
                for (int j = 0; j < 5; ++j)
                    words = words + Convert.ToString(alphabet[startLetter]);
                if (startLetter < 25)
                    ++startLetter;
                DateTime datetime = new DateTime(2025, 1, startDate);
                if (startDate < 28)
                    ++startDate;
                array[i] = new Data(numbers, doubleNumbers, letters, words, datetime);
            }
            return array;
        }

        public int[] ReversedArray(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < size; ++i)
                array[size - i - 1] = i + 1;

            return array;
        }

        public Data[] ReversedDataArray(int size)
        {
            Data[] array = new Data[size];
            Random rand = new Random();

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int startLetter = 1, startDate = 1;

            for (int i = 0; i < size; ++i)
            {
                int numbers = i + 1;
                double doubleNumbers = rand.NextDouble() * (i + 1);
                char letters = Convert.ToChar(alphabet[startLetter]);
                string words = string.Empty;
                for (int j = 0; j < 5; ++j)
                    words = words + Convert.ToString(alphabet[startLetter]);
                if (startLetter < 25)
                    ++startLetter;
                DateTime datetime = new DateTime(2025, 1, startDate);
                if (startDate < 28)
                    ++startDate;
                array[size - i - 1] = new Data(numbers, doubleNumbers, letters, words, datetime);
            }

            return array;
        }

        public int[] SomePermutationsArray(int size)
        {
            int[] array = SortedArray(size);
            Random rand = new Random();

            int count = size / 10;

            while (count != 0)
            {
                int i = rand.Next(0, size - 1), j = rand.Next(0, size - 1);
                (array[i], array[j]) = (array[j], array[i]);
                --count;
            }
            return array;
        }

        public Data[] SomePermutationsDataArray(int size)
        {
            Data[] array = SortedDataArray(size);
            Random rand = new Random();

            int count = size / 10;

            while (count != 0)
            {
                int i = rand.Next(0, size - 1), j = rand.Next(0, size - 1);
                (array[i], array[j]) = (array[j], array[i]);
                --count;
            }
            return array;
        }

        public int[] SomeReplacementsArray(int size)
        {
            int[] array = SortedArray(size);
            int replacements = size / 10;
            Random rand = new Random();

            for (int i = 0; i < replacements; ++i)
                array[rand.Next(size - 1)] = rand.Next(1, size);

            return array;
        }

        public Data[] SomeReplacementsDataArray(int size)
        {
            Data[] array = SortedDataArray(size);
            int replacements = size / 10;
            Random rand = new Random();

            for (int i = 0; i < replacements; ++i)
            {
                int numbers = rand.Next(0, 1000);
                double doubleNumbers = rand.NextDouble() * 1000;
                char letters = Convert.ToChar(RandomWord(1));
                string words = RandomWord(5);
                DateTime datetime = new DateTime(rand.Next(1900, 2025), rand.Next(1, 12), rand.Next(1, 28));
                array[rand.Next(size - 1)] = new Data(numbers, doubleNumbers, letters, words, datetime);
            }

            return array;
        }

        public int[] RepeatArray(int size, int percentage)
        {
            int[] array = new int[size], index = SortedArray(size);
            int repeating = size * percentage / 100;

            Random rand = new Random();

            for (int i = 0; i < size; ++i)
            {
                int j = rand.Next(i + 1);
                (index[i], index[j]) = (index[j], index[i]);
            }

            int repeatingNumber = rand.Next(1, size);
            for (int i = 0; i < repeating; ++i)
                array[index[i] - 1] = repeatingNumber;

            for (int i = 0; i < size - repeating; ++i)
                array[index[i + repeating] - 1] = (repeatingNumber + i + 1) % size;

            return array;
        }

        public Data[] RepeatDataArray(int size, int percentage)
        {
            Data[] array = SortedDataArray(size); int[] index = SortedArray(size);
            int repeating = size * percentage / 100;

            Random rand = new Random();

            for (int i = 0; i < size; ++i)
            {
                int j = rand.Next(i + 1);
                (index[i], index[j]) = (index[j], index[i]);
            }

            int numbers = rand.Next(0, 1000);
            double doubleNumbers = rand.NextDouble() * 1000;
            char letters = Convert.ToChar(RandomWord(1));
            string words = RandomWord(5);
            DateTime datetime = new DateTime(rand.Next(1900, 2025), rand.Next(1, 12), rand.Next(1, 28));
            Data repeatingData = new Data(numbers, doubleNumbers, letters, words, datetime);
            for (int i = 0; i < repeating; ++i)
                array[index[i] - 1] = repeatingData;

            return array;
        }
    }
}
