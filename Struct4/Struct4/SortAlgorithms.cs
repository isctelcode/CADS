using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace Struct3
{
    class DataNumbersComparer : IComparer<Data>
    {
        public int Compare(Data data1, Data data2)
        {
            return data1.Numbers.CompareTo(data2.Numbers);
        }
    }

    class DataDoubleNumbersComparer : IComparer<Data>
    {
        public int Compare(Data data1, Data data2)
        {
            return data1.DoubleNumbers.CompareTo(data2.DoubleNumbers);
        }
    }
    class DataLettersComparer : IComparer<Data>
    {
        public int Compare(Data data1, Data data2)
        {
            return data1.Letters.CompareTo(data2.Letters);
        }
    }
    class DataWordsComparer : IComparer<Data>
    {
        public int Compare(Data data1, Data data2)
        {
            return data1.Words.CompareTo(data2.Words);
        }
    }
    class DataDatetimeComparer : IComparer<Data>
    {
        public int Compare(Data data1, Data data2)
        {
            return data1.Datetime.CompareTo(data2.Datetime);
        }
    }

    internal class SortAlgorithms
    {
        public void BubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n - 1; ++j)
                    if (array[j] > array[j + 1])
                        (array[j], array[j + 1]) = (array[j + 1],  array[j]);
        }

        public void BubbleDataSort(Data[] array, IComparer<Data> comparer)
        {
            int n = array.Length;
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n - 1; ++j)
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
        }

        public void ShakerSort(int[] array)
        {
            int n = array.Length, left = 0, right = n - 1;
            bool flag = true;

            while (flag && left < right)
            {
                flag = false;
                for (int i = left; i < right; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                        flag = true;
                    }
                }
                right--;

                for (int i = right; i > left; --i)
                {
                    if (array[i] < array[i - 1])
                    {
                        (array[i], array[i - 1]) = (array[i - 1], array[i]);
                        flag = true;
                    }
                }
                left++;
            }
        }

        public void ShakerDataSort(Data[] array, IComparer<Data> comparer)
        {
            int n = array.Length, left = 0, right = n - 1;
            bool flag = true;

            while (flag && left < right)
            {
                flag = false;
                for (int i = left; i < right; ++i)
                {
                    if (comparer.Compare(array[i], array[i + 1]) > 0)
                    {
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                        flag = true;
                    }
                }
                right--;

                for (int i = right; i > left; --i)
                {
                    if (comparer.Compare(array[i], array[i - 1]) < 0)
                    {
                        (array[i], array[i - 1]) = (array[i - 1], array[i]);
                        flag = true;
                    }
                }
                left++;
            }
        }

        public int NextGap(int gap)
        {
            gap = (gap * 10) / 13;
            if (gap < 1) return 1;
            return gap;
        }

        public void CombSort(int[] array)
        {
            int n = array.Length, gap = n;
            bool flag = true;

            while (flag && gap != 1)
            {
                gap = NextGap(gap);
                flag = false;

                for (int i = 0; i < n - gap; ++i)
                {
                    if (array[i] > array[i + gap])
                    {
                        (array[i], array[i + gap]) = (array[i + gap], array[i]);
                        flag = true;
                    }
                }
            }
        }

        public void CombDataSort(Data[] array, IComparer<Data> comparer)
        {
            int n = array.Length, gap = n;
            bool flag = true;

            while (flag && gap != 1)
            {
                gap = NextGap(gap);
                flag = false;

                for (int i = 0; i < n - gap; ++i)
                {
                    if (comparer.Compare(array[i], array[i + gap]) > 0)
                    {
                        (array[i], array[i + gap]) = (array[i + gap], array[i]);
                        flag = true;
                    }
                }
            }
        }

        public void InsertionSort(int[] array)
        {
            int n = array.Length;
            bool flag = true;

            for (int i = 0; i < n; ++i)
            {
                flag = true;
                for (int j = i; j > 0 && flag; --j)
                {
                    if (array[j - 1] > array[j])
                        (array[j], array[j - 1]) = (array[j - 1], array[j]);
                    else flag = false;
                }
            }
        }

        public void InsertionDataSort(Data[] array, IComparer<Data> comparer)
        {
            int n = array.Length;
            bool flag = true;

            for (int i = 0; i < n; ++i)
            {
                flag = true;
                for (int j = i; j > 0 && flag; --j)
                {
                    if (comparer.Compare(array[j - 1], array[j]) > 0)
                        (array[j], array[j - 1]) = (array[j - 1], array[j]);
                    else flag = false;
                }
            }
        }

        public void ShellSort(int[] array)
        {
            int n = array.Length;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; ++i)
                {
                    int tmp = array[i];
                    int j = i;

                    while (j >= gap && array[j - gap] > tmp)
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }

                    array[j] = tmp;
                }
            }
        }

        public void ShellDataSort(Data[] array, IComparer<Data> comparer)
        {
            int n = array.Length;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; ++i)
                {
                    Data tmp = array[i];
                    int j = i;

                    while (j >= gap && comparer.Compare(array[j - gap], tmp) > 0)
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }

                    array[j] = tmp;
                }
            }
        }

        public class Node
        {
            public Data value;
            public Node left, right;

            public Node(Data value)
            {
                this.value = value;
                left = null;
                right = null;   
            }
        }

        public Node TreeInsert(Node root, Data value, IComparer<Data> comparer)
        {
            if (root == null)
            {
                root = new Node(value);
                return root;
            }

            if (comparer.Compare(value, root.value) < 0)
                root.left = TreeInsert(root.left, value, comparer);
            else
                root.right = TreeInsert(root.right, value, comparer);

            return root;
        }

        public void TreeOutput(Node root, Data[] array)
        {
            if (root != null)
            {
                TreeOutput(root.left, array);
                array[i] = root.value;
                ++i;
                TreeOutput(root.right, array);
            }
        }

        public Node TreeInit(Data[] array, IComparer<Data> comparer)
        {
            Node root = null;
            for (int i = 0; i < array.Length; i++)
                root = TreeInsert(root, array[i], comparer);
            return root;
        }

        static int i = 0;
        public void TreeDataSort(Data[] array, IComparer<Data> comparer)
        {
            Node root = TreeInit(array, comparer);
            if (root == null) Console.WriteLine("rjfk");
            TreeOutput(root, array);
            i = 0;
        }

        public void Heapify(Data[] array, IComparer<Data> comparer)
        {
            int n = array.Length, startIndex = n / 2 - 1;
            for (int i = startIndex; i >= 0; i--)
                SiftDownMax(array, i, n, comparer);
        }

        public void SiftDownMax(Data[] array, int index, int size, IComparer<Data> comparer)
        {
            while (index * 2 + 1 < size)
            {
                int leftIndex = 2 * index + 1;
                int rightIndex = 2 * index + 2;
                int maxChildIndex = leftIndex;

                if (rightIndex < size && comparer.Compare(array[rightIndex], array[leftIndex]) > 0)
                    maxChildIndex = rightIndex;

                if (comparer.Compare(array[index], array[maxChildIndex]) >= 0) break;
                else
                {
                    (array[index], array[maxChildIndex]) = (array[maxChildIndex], array[index]);
                    index = maxChildIndex;
                }
            }
        }

        public void HeapDataSort(Data[] array, IComparer<Data> comparer)
        {
            int n = array.Length;

            Heapify(array, comparer);

            for (int i = n - 1; i > 0; --i)
            {
                (array[0], array[i]) = (array[i], array[0]);
                SiftDownMax(array, 0, i, comparer);
            }
        }

        public void GnomeSort(int[] array)
        {
            int n = array.Length;

            for (int i = 1; i < n;)
            {
                if (i == 0) ++i;
                else if (array[i - 1] > array[i])
                {
                    (array[i - 1], array[i]) = (array[i], array[i - 1]);
                    --i;
                }
                else ++i;
            }
        }

        public void GnomeDataSort(Data[] array, IComparer<Data> comparer)
        {
            int n = array.Length;

            for (int i = 1; i < n;)
            {
                if (i == 0) ++i;
                else if (comparer.Compare(array[i - 1], array[i]) > 0)
                {
                    (array[i - 1], array[i]) = (array[i], array[i - 1]);
                    --i;
                }
                else ++i;
            }
        }

        public void SelectionSort(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n; ++i)
            {
                int mn = array[i], mnIndex = i;
                for (int j = i + 1; j < n; ++j)
                    if (array[j] < mn)
                    {
                        mn = array[j];
                        mnIndex = j;
                    }
                (array[i], array[mnIndex]) = (array[mnIndex], array[i]);
            }
        }

        public void SelectionDataSort(Data[] array, IComparer<Data> comparer)
        {
            int n = array.Length;

            for (int i = 0; i < n; ++i)
            {
                Data mn = array[i]; int mnIndex = i;
                for (int j = i + 1; j < n; ++j)
                    if (comparer.Compare(array[j], mn) < 0)
                    {
                        mn = array[j];
                        mnIndex = j;
                    }
                (array[i], array[mnIndex]) = (array[mnIndex], array[i]);
            }
        }

        public int Partition(Data[] array, int low, int high, IComparer<Data> comparer)
        {
            Data pivot = array[high]; int i = low - 1;

            for (int j = low; j < high; ++j)
            {
                if (comparer.Compare(array[j], pivot) < 0)
                {
                    ++i;
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }

            (array[i + 1], array[high]) = (array[high], array[i + 1]);
            return i + 1;
        }

        public void QuickDataSort(Data[] array, IComparer<Data> comparer)
        {
            QuickDataSort(array, 0, array.Length - 1, comparer);
        }

        public void QuickDataSort(Data[] array, int low, int high, IComparer<Data> comparer)
        {
            if (low < high)
            {
                int pivot = Partition(array, low, high, comparer);

                QuickDataSort(array, low, pivot - 1, comparer);
                QuickDataSort(array, pivot + 1, high, comparer);
            }
        }

        public void Merge(Data[] array, int left, int right, int middle, IComparer<Data> comparer)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            Data[] leftArray = new Data[n1];
            Data[] rightArray = new Data[n2];

            int i, j;

            for (i = 0; i < n1; ++i)
                leftArray[i] = array[left + i];
            for (j = 0; j < n2; ++j)
                rightArray[j] = array[middle + 1 + j];

            i = 0; j = 0; int k = left;

            while (i < n1 && j < n2)
            {
                if (comparer.Compare(leftArray[i], rightArray[j]) <= 0)
                {
                    array[k] = leftArray[i];
                    ++i;
                }
                else
                {
                    array[k] = rightArray[j];
                    ++j;
                }
                ++k;
            }

            while (i < n1)
            {
                array[k] = leftArray[i];
                ++i;
                ++k;
            }

            while (j < n2)
            {
                array[k] = rightArray[j];
                ++j;
                ++k;
            }
        }

        public void MergeDataSort(Data[] array, IComparer<Data> comparer)
        {
            MergeDataSort(array, 0, array.Length - 1, comparer);
        }

        public void MergeDataSort(Data[] array, int left, int right, IComparer<Data> comparer)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                MergeDataSort(array, left, middle, comparer);
                MergeDataSort(array, middle + 1, right, comparer);

                Merge(array, left, right, middle, comparer);
            }
        }

        public void CountSort(int[] array, int digit)
        {
            int n = array.Length;
            int[] digitSorted = new int[n];
            int[] count = new int[10];

            for (int i = 0; i < 10; ++i)
                count[i] = 0;

            for (int i = 0; i < n; ++i)
                ++count[(array[i] / digit) % 10];

            for (int i = 1; i < 10; ++i)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; --i)
            {
                digitSorted[count[(array[i] / digit) % 10] - 1] = array[i];
                --count[(array[i] / digit) % 10];
            }

            for (int i = 0; i < n; ++i)
                array[i] = digitSorted[i];
        }

        public void RadixSort(int[] array)
        {
            int n = array.Length, mxDigit = array[i];

            for (int i = 1; i < n; ++i)
                if (mxDigit < array[i])
                    mxDigit = array[i];

            for (int i = 1; mxDigit / i > 0; i *= 10)
                CountSort(array, i);
        }

        public void BitonicMerge(int[] array, int low, int length, bool direction)
        {
            if (length > 1)
            {
                int gap = length / 2;
                for (int i = low; i < low + gap; ++i)
                {
                    if (direction && array[i] > array[i + gap])
                        (array[i], array[i + gap]) = (array[i + gap], array[i]);
                    else if (!direction && array[i] < array[i + gap])
                        (array[i], array[i + gap]) = (array[i + gap], array[i]);
                }
                
                BitonicMerge(array, low, gap, direction);
                BitonicMerge(array, low + gap, gap, direction);
            }
        }

        public void BitonicSort(int[] array)
        {
            int n = array.Length, newN = 1;
            while (newN < n) newN *= 2;
            int[] newArray = new int[newN];
            for (int i = 0; i < n; ++i) newArray[i] = array[i];
            for (int i = n; i < newN; ++i) newArray[i] = 1000000;
            BitonicSort(newArray, 0, newArray.Length, true);
            for (int i = 0; i < n; ++i) array[i] = newArray[i];
        }

        public void BitonicSort(int[] array, int low, int length, bool direction)
        {
            int gap = length / 2;
            if (length > 1)
            {
                BitonicSort(array, low, gap, true);
                BitonicSort(array, low + gap, gap, false);

                BitonicMerge(array, low, length, direction);
            }
        }
    }
}
