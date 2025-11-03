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

        public class Node
        {
            public int value;
            public Node left, right;

            public Node(int value)
            {
                this.value = value;
                left = null;
                right = null;   
            }
        }

        public Node TreeInsert(Node root, int value)
        {
            if (root == null)
            {
                root = new Node(value);
                return root;
            }

            if (value < root.value)
                root.left = TreeInsert(root.left, value);
            else
                root.right = TreeInsert(root.right, value);

            return root;
        }

        public void TreeOutput(Node root, int[] array)
        {
            if (root != null)
            {
                TreeOutput(root.left, array);
                array[i] = root.value;
                ++i;
                TreeOutput(root.right, array);
            }
        }

        public Node TreeInit(int[] array)
        {
            Node root = null;
            for (int i = 0; i < array.Length; i++)
                root = TreeInsert(root, array[i]);
            return root;
        }

        static int i = 0;
        public void TreeSort(int[] array)
        {
            Node root = TreeInit(array);
            if (root == null) Console.WriteLine("rjfk");
            TreeOutput(root, array);
            i = 0;
        }

        public void Heapify(int[] array)
        {
            int n = array.Length, startIndex = n / 2 - 1;
            for (int i = startIndex; i >= 0; i--)
                SiftDownMax(array, i, n);
        }

        public void SiftDownMax(int[] array, int index, int size)
        {
            while (index * 2 + 1 < size)
            {
                int leftIndex = 2 * index + 1;
                int rightIndex = 2 * index + 2;
                int maxChildIndex = leftIndex;

                if (rightIndex < size && array[rightIndex] > array[leftIndex])
                    maxChildIndex = rightIndex;

                if (array[index] >= array[maxChildIndex]) break;
                else
                {
                    (array[index], array[maxChildIndex]) = (array[maxChildIndex], array[index]);
                    index = maxChildIndex;
                }
            }
        }

        public void HeapSort(int[] array)
        {
            int n = array.Length;

            Heapify(array);

            for (int i = n - 1; i > 0; --i)
            {
                (array[0], array[i]) = (array[i], array[0]);
                SiftDownMax(array, 0, i);
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

        public int Partition(int[] array, int low, int high)
        {
            int pivot = array[high], i = low - 1;

            for (int j = low; j < high; ++j)
            {
                if (array[j] < pivot)
                {
                    ++i;
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }

            (array[i + 1], array[high]) = (array[high], array[i + 1]);
            return i + 1;
        }

        public void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        public void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(array, low, high);

                QuickSort(array, low, pivot - 1);
                QuickSort(array, pivot + 1, high);
            }
        }

        public void Merge(int[] array, int left, int right, int middle)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            int i, j;

            for (i = 0; i < n1; ++i)
                leftArray[i] = array[left + i];
            for (j = 0; j < n2; ++j)
                rightArray[j] = array[middle + 1 + j];

            i = 0; j = 0; int k = left;

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
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

        public void MergeSort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }

        public void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);

                Merge(array, left, right, middle);
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
