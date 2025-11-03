using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct3
{
    internal class ArrayGenerate
    {
        public int[] RandomArray(int size)
        {
            int[] array = new int[size];
            Random rand = new Random();

            for (int i = 0; i < size; ++i)
                array[i] = rand.Next(0, 1000);

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

        public int[] SomePermutationsArray(int size)
        {
            int[] array = new int[size];
            Random rand = new Random();

            for (int i = 0; i < size; ++i)
                array[i] = i + 1;

            int count = size / 10;

            while (count != 0)
            {
                int i = rand.Next(0, size - 1), j = rand.Next(0, size - 1);
                (array[i], array[j]) = (array[j], array[i]);
                --count;
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

        public int[] ReversedArray(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < size; ++i)
                array[size - i - 1] = i + 1;

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
    }
}
