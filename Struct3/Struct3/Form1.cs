using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;
using ZedGraph;
using System.Diagnostics;
using System.IO;
using System.Globalization;

namespace Struct3
{
    public partial class Form1 : Form
    {
        int[][][] testData, unsortedData;
        int[][][][] sortedData;
        int dataGroup = 0, algorithmGroup = 0, generatedGroup = 0, generatedDataGroup = 0;
        bool generated = false, sorted = false;
        SortAlgorithms sorting = new SortAlgorithms();
        ArrayGenerate generating = new ArrayGenerate();
        public delegate void Sorting(int[] array);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void data_SelectedIndexChanged(object sender, EventArgs e)
        {
            string group = data.SelectedItem.ToString();
            switch (group)
            {
                case "Случайные числа":
                    dataGroup = 1;
                    break;
                case "Кусочно отсортированные":
                    dataGroup = 2;
                    break;
                case "Несколько замен чисел":
                    dataGroup = 3;
                    break;
                case "Отсортированные":
                    dataGroup = 4;
                    break;
                case "В обратном порядке":
                    dataGroup = 5;
                    break;
                case "Несколько перестановок чисел":
                    dataGroup = 6;
                    break;
                case "Повторение 10%":
                    dataGroup = 7;
                    break;
                case "Повторение 25%":
                    dataGroup = 8;
                    break;
                case "Повторение 50%":
                    dataGroup = 9;
                    break;
                case "Повторение 75%":
                    dataGroup = 10;
                    break;
                case "Повторение 90%":
                    dataGroup = 11;
                    break;
            }
        }

        private void algorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string group = algorithm.SelectedItem.ToString();
            switch (group) {
                case "Первая группа":
                    algorithmGroup = 1;
                    break;
                case "Вторая группа":
                    algorithmGroup = 2;
                    break;
                case "Третья группа":
                    algorithmGroup = 3;
                    break;
            }
        }

        private void generate_Click(object sender, EventArgs e)
        {
            if (dataGroup == 0 || algorithmGroup == 0)
            {
                MessageBox.Show(
                "Выберите тестовые данные и группу сортировок",
                "I AM ERROR",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return;
            }

            int groupSize = algorithmGroup + 3, testCount = 20;
            testData = new int[groupSize][][];
            unsortedData = new int[groupSize][][];
            for (int i = 0; i < groupSize; ++i)
            {
                testData[i] = new int[testCount][];
                unsortedData[i] = new int[testCount][];
                for (int j = 0; j < testCount; ++j)
                {
                    testData[i][j] = new int[Convert.ToInt32(Pow(10, i + 1))];
                    unsortedData[i][j] = new int[Convert.ToInt32(Pow(10, i + 1))];
                }
            }

            for (int i = 0; i < groupSize; ++i)
                for (int j = 0; j < 20; ++j)
                    switch (dataGroup)
                    {
                        case 1:
                            testData[i][j] = generating.RandomArray(Convert.ToInt32(Pow(10, i + 1)));
                            break;
                        case 2:
                            testData[i][j] = generating.PartiallySortedArray(Convert.ToInt32(Pow(10, i + 1)));
                            break;
                        case 3:
                            testData[i][j] = generating.SomePermutationsArray(Convert.ToInt32(Pow(10, i + 1)));
                            break;
                        case 4:
                            testData[i][j] = generating.SortedArray(Convert.ToInt32(Pow(10, i + 1)));
                            break;
                        case 5:
                            testData[i][j] = generating.ReversedArray(Convert.ToInt32(Pow(10, i + 1)));
                            break;
                        case 6:
                            testData[i][j] = generating.SomeReplacementsArray(Convert.ToInt32(Pow(10, i + 1)));
                            break;
                        case 7:
                            testData[i][j] = generating.RepeatArray(Convert.ToInt32(Pow(10, i + 1)), 10);
                            break;
                        case 8:
                            testData[i][j] = generating.RepeatArray(Convert.ToInt32(Pow(10, i + 1)), 25);
                            break;
                        case 9:
                            testData[i][j] = generating.RepeatArray(Convert.ToInt32(Pow(10, i + 1)), 50);
                            break;
                        case 10:
                            testData[i][j] = generating.RepeatArray(Convert.ToInt32(Pow(10, i + 1)), 75);
                            break;
                        case 11:
                            testData[i][j] = generating.RepeatArray(Convert.ToInt32(Pow(10, i + 1)), 90);
                            break;
                    }
            for (int i = 0; i < groupSize; ++i)
                for (int j = 0; j < 20; ++j)
                    for (int elem = 0; elem < Convert.ToInt32(Pow(10, i + 1)); ++elem)
                        unsortedData[i][j][elem] = testData[i][j][elem];
            generatedDataGroup = dataGroup;
            generatedGroup = algorithmGroup;
            generated = true;
            sorted = false;
            MessageBox.Show(
                "Тестовые данные сгенерированы",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }

        private void run_Click(object sender, EventArgs e)
        {
            if (!generated)
            {
                MessageBox.Show(
                "Сгенерируйте тестовые данные",
                "I AM ERROR",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return;
            }

            Sorting[] sortings = new Sorting[] {};
            int sortingsCount = 0, testDataSize = 0, sortingsCounter = 0;

            switch (generatedGroup)
            {
                case 1:
                    sortings = new Sorting[]
                    {
                        sorting.BubbleSort,
                        sorting.InsertionSort,
                        sorting.SelectionSort,
                        sorting.ShakerSort,
                        sorting.GnomeSort
                    };
                    sortedData = new int[5][][][];
                    for (int i = 0; i < 5; ++i)
                        sortedData[i] = testData;
                    sortingsCount = 5;
                    testDataSize = 4;
                    break;
                case 2:
                    sortings = new Sorting[]
                    {
                        sorting.BitonicSort,
                        sorting.ShellSort,
                        sorting.TreeSort
                    };
                    sortedData = new int[3][][][];
                    for (int i = 0; i < 3; ++i)
                        sortedData[i] = testData;
                    sortingsCount = 3;
                    testDataSize = 5;
                    break;
                case 3:
                    sortings = new Sorting[]
                    {
                        sorting.CombSort,
                        sorting.HeapSort,
                        sorting.QuickSort,
                        sorting.MergeSort,
                        sorting.RadixSort
                    };
                    sortedData = new int[5][][][];
                    for (int i = 0; i < 5; ++i)
                        sortedData[i] = testData;
                    sortingsCount = 5;
                    testDataSize = 6;
                    break;
            }

            double[,] algorithmTime = new double[sortingsCount, testDataSize];
            Stopwatch timer;

            foreach (Sorting sort in sortings)
            {
                if (sort != sorting.TreeSort && sort != sorting.QuickSort)
                {
                    for (int i = 0; i < testDataSize; ++i)
                    {
                        timer = new Stopwatch();
                        timer.Start();
                        for (int j = 0; j < 20; ++j)
                            sort(sortedData[sortingsCounter][i][j]);
                        timer.Stop();
                        algorithmTime[sortingsCounter, i] = timer.ElapsedMilliseconds / 20;
                    }
                    ++sortingsCounter;
                }
                else
                {

                    for (int i = 0; i < 3; ++i)
                    {
                        timer = new Stopwatch();
                        timer.Start();
                        for (int j = 0; j < 20; ++j)
                            sort(sortedData[sortingsCounter][i][j]);
                        timer.Stop();
                        algorithmTime[sortingsCounter, i] = timer.ElapsedMilliseconds / 20;
                    }
                    ++sortingsCounter;
                }
            }

            sortingsCounter = 0;

            GraphPane pane = graph.GraphPane;
            pane.Title.Text = "График";
            pane.XAxis.Title.Text = "Количество элементов";
            pane.YAxis.Title.Text = "Скорость работы (мс)";
            pane.CurveList.Clear();
            PointPairList pointList;

            switch(generatedGroup)
            {
                case 1:
                    pane.Title.Text = "Первая группа сортировок";
                    pointList = new PointPairList();
                    for (int i = 0; i < testDataSize; ++i)
                        pointList.Add(Pow(10, i + 1), algorithmTime[0, i]);
                    pane.AddCurve("Пузырьковая сортировка", pointList, Color.Red, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < testDataSize; ++i)
                        pointList.Add(Pow(10, i + 1), algorithmTime[1, i]);
                    pane.AddCurve("Сортировка вставками", pointList, Color.Green, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < testDataSize; ++i)
                        pointList.Add(Pow(10, i + 1), algorithmTime[2, i]);
                    pane.AddCurve("Сортировка выбором", pointList, Color.Blue, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < testDataSize; ++i)
                        pointList.Add(Pow(10, i + 1), algorithmTime[3, i]);
                    pane.AddCurve("Шейкерная сортировка", pointList, Color.Purple, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < testDataSize; ++i)
                        pointList.Add(Pow(10, i + 1), algorithmTime[4, i]);
                    pane.AddCurve("Гномья сортировка", pointList, Color.Brown, SymbolType.Default);
                    break;
                case 2:
                    pane.Title.Text = "Вторая группа сортировок";
                    pointList = new PointPairList();
                    for (int i = 0; i < testDataSize; ++i)
                        pointList.Add(Pow(10, i + 1), algorithmTime[0, i]);
                    pane.AddCurve("Битонная сортировка", pointList, Color.Red, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < testDataSize; ++i)
                        pointList.Add(Pow(10, i + 1), algorithmTime[1, i]);
                    pane.AddCurve("Сортировка Шелла", pointList, Color.Green, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < 3; ++i)
                        pointList.Add(Pow(10, i + 1), algorithmTime[2, i]);
                    pane.AddCurve("Сортировка деревом", pointList, Color.Blue, SymbolType.Default);
                    break;
                case 3:
                    pane.Title.Text = "Третья группа сортировок";
                    pointList = new PointPairList();
                    for (int i = 0; i < testDataSize; ++i)
                        pointList.Add(Pow(10, i + 1), algorithmTime[0, i]);
                    pane.AddCurve("Сортировка расчёской", pointList, Color.Red, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < testDataSize; ++i)
                        pointList.Add(Pow(10, i + 1), algorithmTime[1, i]);
                    pane.AddCurve("Пирамидальная сортировка", pointList, Color.Green, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < 3; ++i)
                        pointList.Add(Pow(10, i + 1), algorithmTime[2, i]);
                    pane.AddCurve("Быстрая сортировка", pointList, Color.Blue, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < testDataSize; ++i)
                        pointList.Add(Pow(10, i + 1), algorithmTime[3, i]);
                    pane.AddCurve("Сортировка слиянием", pointList, Color.Purple, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < testDataSize; ++i)
                        pointList.Add(Pow(10, i + 1), algorithmTime[4, i]);
                    pane.AddCurve("Пораздрядная сортировка", pointList, Color.Brown, SymbolType.Default);
                    break;
            }
            graph.AxisChange();
            graph.Invalidate();
            sorted = true;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (!generated)
            {
                MessageBox.Show(
                "Сгенерируйте тестовые данные",
                "I AM ERROR",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            else if (!sorted)
            {
                MessageBox.Show(
                "Отсортируйте сгенерированные данные",
                "I AM ERROR",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            else
            {
                StreamWriter input = new StreamWriter("data.txt");
                for (int i = 0; i < unsortedData.Length; ++i)
                {
                    for (int j = 0; j < 20; ++j)
                    {
                        input.WriteLine(String.Join(" ", unsortedData[i][j]));
                        input.WriteLine(String.Join(" ", sortedData[0][i][j]));
                        input.WriteLine();
                    }
                }
                MessageBox.Show(
                "Результаты сортировок сохранены",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}